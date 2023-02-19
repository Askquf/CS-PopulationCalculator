using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestLinearAlgebra;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using DemographicFileOperations;
using System.Threading;

namespace DemographicWinForms
{
    public partial class Form1 : Form
    {
        Controller _controller;
        string _filepathDeath;
        string _filepathStart;
        const int _numberCharts = 2;
        int[] _parametrs;
        delegate void DrawingSpline(List<int> data, int year);
        delegate void DrawReady();
        delegate void DrawingBar(List<List<int>> data);
        Thread _workThread;

        public Form1()
        {
            InitializeComponent();
            ClearChart(chart1);
            ClearChart(bar_m);
            ClearChart(bar_w);
            _parametrs = new int[3];
        }

        /// <summary>
        /// Метод, вызывающий диалоговое окно для открытия файла
        /// </summary>
        /// <returns>Имя выбранного пользователем файла</returns>
        public string FileAsking()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Comma separeted files (*.csv)|*.csv"; //фильтр, чтобы нельзя было открыть ничего кроме csv
            dialog.ShowDialog();
            return dialog.FileName;
        }

        /// <summary>
        /// Обрабатывает нажатием на кнопку "Death Rate"
        /// Запрашивает у пользователя файл для считывания.
        /// </summary>
        private void death_take_Click(object sender, EventArgs e)
        {
            _filepathDeath = FileAsking();
            filepathboxdeath.Text = _filepathDeath;
        }

        /// <summary>
        /// Обрабатывает нажатием на кнопку "Start Position"
        /// Запрашивает у пользователя файл для считывания.
        /// </summary>
        private void start_take_Click(object sender, EventArgs e)
        {
            _filepathStart = FileAsking();
            filepathboxinitial.Text = _filepathStart;
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку старт.
        /// Запускает движок для расчета населения, рисует нужные чарты.
        /// Обрабатывает возникающие ошибки.
        /// </summary>
        private void start_Click(object sender, EventArgs e)
        {
            if (CheckThread())
            {
                _controller = new Controller();
                if (CheckAll())
                {
                    SetParametrs();
                    try
                    {
                        _controller.GetLists(_filepathDeath, _filepathStart, _parametrs[0], _parametrs[2]);
                    }
                    catch (FileNotFoundException)
                    {
                        ShowProblemMessage("File not found!");
                        return;
                    }
                    catch (FileLoadException)
                    {
                        ShowProblemMessage("Too big file!");
                        return;
                    }
                    catch (Exception)
                    {
                        ShowProblemMessage("Wrong data!");
                        return;
                    }
                    _workThread = new Thread(CountDraw);
                    _workThread.Start();
                }
                else
                    MessageBox.Show("Wrong parametrs!");
            }
        }

        public void ShowProblemMessage(string boxText)
        {
            MessageBox.Show(boxText);
        }

        private void abortation_Click(object sender, EventArgs e)
        {
            DisposeProgramm();
        }

        private void DisposeProgramm()
        {
            if (!CheckThread())
            {
                if (_workThread.ThreadState == ThreadState.Suspended)
                    _workThread.Resume();
                _workThread.Abort();
                _controller.DisposeEngine();
            }
        }

        private void pause_Click(object sender, EventArgs e)
        {
            if (!CheckThread())
            {
                _workThread.Suspend();
                unpause.Enabled = true;
            }
        }

        private void unpause_Click(object sender, EventArgs e)
        {
            _workThread.Resume();
            unpause.Enabled = false;
        }

        private bool CheckThread ()
        {
            return (_workThread == null || !_workThread.IsAlive);
        }

        /// <summary>
        /// Проверка параметров, задаваемых пользователем.
        /// </summary>
        public bool CheckAll()
        {
            Checker checker = new Checker();
            bool res;
            res = Check(checker, population.Text) && Check(checker, year_end.Text) && Check(checker, year_st.Text);
            if (year_end.Text == "0" || population.Text == "0" || year_st.Text == "0")
                res = false;
            if (res == true && year_end.Text != "" && year_st.Text != "")
            {
                if (Convert.ToInt32(year_end.Text) <= Convert.ToInt32(year_st.Text))
                    res = false;
            }
            return res;
        }
        /// <summary>
        /// СОздание массива пользовательских паратметров.
        /// </summary>
        /// <returns>Массив с параметрами пользователя.</returns>
        public void SetParametrs()
        {
            if (year_st.Text == "")
                _parametrs[0] = 1970;
            else
                _parametrs[0] = Convert.ToInt32(year_st.Text);
            if (year_end.Text == "")
                _parametrs[1] = 2021;
            else
                _parametrs[1] = Convert.ToInt32(year_end.Text);
            if (population.Text == "")
                _parametrs[2] = 130000;
            else
                _parametrs[2] = Convert.ToInt32(population.Text);
        }

        /// <summary>
        /// Проверка одной строки на целое число.
        /// </summary>
        /// <param name="checker">Объект проверяльщика</param>
        /// <param name="to_check">Строка, которая должна содержать целое число</param>
        public bool Check(Checker checker, string to_check)
        {
            checker.ChangeCheck(to_check);
            return checker.IntCheck();
        }

        /// <summary>
        /// Получение от контроллера информации о количестве население.
        /// Запуск отрисовки.
        /// </summary>
        /// <param name="parametrs">Массив с параметрами пользователя</param>
        public void CountDraw()
        {
            int year = _parametrs[0];
            BeginInvoke(new DrawReady(GetReadyforDrawing));
            for (int i = 0; i < _parametrs[1] - _parametrs[0]; i++)
            {
                List<int> tmp = _controller.ControllerStep();
                BeginInvoke(new DrawingSpline(DrawOneStepSpline), tmp, year);
                BeginInvoke(new DrawingBar(DrawOneStepColumn), _controller.GiveDividedPopulation());
                Thread.Sleep(300);
                year++;
            }
            
        }

        public void DrawOneStepSpline(List<int> tmp, int year)
        {
            for (int i = 0; i < 3; i++)
                chart1.Series[i].Points.AddXY(year, tmp[i]);
        }

        public void DrawOneStepColumn(List<List<int>> tmp)
        {
            string[] titles = { "Men Age Composition", "Women Age Composition" };
            Chart[] charts = new Chart[_numberCharts];
            charts[0] = bar_m; charts[1] = bar_w;
            for (int j = 0; j < _numberCharts; j++)
            {
                ClearChart(charts[j]);
                charts[j].Titles.Add(titles[j]);
                AxisCreate(charts[j], "Ages", "Population (thou.)" );
            }
            string[] speciesNames = { "0-18", "19-44", "45-65", "66-100" };
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    charts[i].Series.Add(speciesNames[j]);
                    charts[i].Series[j].Points.Add(tmp[i][j]);
                    charts[i].Series[j].IsValueShownAsLabel = true;
                    charts[i].Series[j].SmartLabelStyle.Enabled = false;
                }
            }
        }

        public void GetReadyforDrawing()
        {
            chart1.Series.Clear();
            string[] legendTitle = new string[3];
            legendTitle[0] = "People Number"; legendTitle[1] = "Man Number"; legendTitle[2] = "Woman Number";
            AxisCreate(chart1, "Year", "Population(thous.)");
            for (int i = 0; i < 3; i++)
            {
                Series series = chart1.Series.Add(legendTitle[i]);
                series.ChartType = SeriesChartType.Spline;
            }

        }

        /// <summary>
        /// Создание осей чарта.
        /// </summary>
        /// <param name="charttofill">Чарт, в котором нужно создать оси</param>
        /// <param name="titleX">Заголовок для оси Х.</param>
        /// <param name="titleY">Заголовок для оси Y.</param>
        public void AxisCreate(Chart charttofill, string titleX, string titleY)
        {
            Axis ax = new Axis();
            ax.Title = titleX;
            ax.IsMarginVisible = false;
            charttofill.ChartAreas[0].AxisX = ax;
            Axis ay = new Axis();
            ay.Title = titleY;
            charttofill.ChartAreas[0].AxisY = ay;
        }

        /// <summary>
        /// Отчистка элемента для дальнейшей работы с ним.
        /// </summary>
        /// <param name="chart_to_clear">Элемент, который нужно отчистить</param>
        public void ClearChart(Chart chart_to_clear)
        {
            chart_to_clear.Series.Clear();
            chart_to_clear.Titles.Clear();
        }
    }
}




 
