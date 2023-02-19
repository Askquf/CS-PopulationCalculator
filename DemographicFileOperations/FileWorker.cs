using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLinearAlgebra;
using System.IO;

namespace DemographicFileOperations
{
    public class FileWorker
    {
        string _path;
        const int _maxFileSizeByte = 10240; //размер файла в байтах 
        int _flag;

        /// <summary>
        /// Конструктор обработчика файлов
        /// </summary>
        /// <param name="fileName">Путь к файлу</param>
        /// <param name="parametrs">Количество параметров, которые необходимо считать</param>
        /// <exception cref="FileNotFoundException">Вызывается при отстутсвии нужного файла</exception>
        /// <exception cref="FileLoadException">Вызывается при слишком большом файла</exception>
        public FileWorker(string fileName, int parametrs)
        {
            _path = fileName;
            if (fileName == "" || fileName == null)
            {
                throw new FileNotFoundException();
            }
            FileInfo file = new FileInfo(_path);
            if (file.Length >= _maxFileSizeByte)
            {
                throw new FileLoadException();
            }
            _flag = parametrs;
        }

        /// <summary>
        /// Считывает файла, записывает данные в список вектор
        /// Одна вектор списка - одна строка файла.
        /// Изначально передает данные в массив строк.
        /// </summary>
        /// <returns>Возвращает cписок с данным файла</returns>
        public List<MathVector> ReadFullFile()
        {
            List<MathVector> data = new List<MathVector>();
            string[] filestrings = File.ReadAllLines(_path);
            AllVectorsCreate(filestrings, data);
            return data;
        }

        /// <summary>
        /// Перерабатывает данные в список векторов
        /// </summary>
        /// <param name="fileInStrings">Массив строк, которые необходимо преобразовать в векторы</param>
        /// <param name="data">Матрица для записи получившихся векторов</param>
        public void AllVectorsCreate(string[] fileInStrings, List<MathVector> data)
        {
            for (int i = 1; i < fileInStrings.Length; i++)
            {
                MathVector tmp = new MathVector(_flag);
                string[] subs = fileInStrings[i].Split(',');
                SplitNumberCheck(subs);
                VectorCreate(tmp, subs);
                data.Add(tmp);
            }
        }

        /// <summary>
        /// Проверяет количество параметров в строке
        /// </summary>
        /// <param name="strings">Строка для проверки</param>
        /// <exception cref="Exception("Wrong number parametrs!")>Ошибка, возвращаемая в случае, если количество параметров больше или меньше нужного</exception>"
        public void SplitNumberCheck(string[] strings)
        {
            if (strings.Length != _flag && strings.Length != _flag + 1)
                throw new Exception("Wrong number parametrs!");
        }

        /// <summary>
        /// Записывает данные в один вектор.
        /// </summary>
        /// <param name="tmp">Вектор для записи</param>
        /// <param name="subs"></param>
        public void VectorCreate(MathVector tmp, string[] subs)
        {
            Checker checker = new Checker();
            for (int j = 0; j < _flag; j++)
            {
                checker.ChangeCheck(subs[j]);
                if ((_flag == 4 && (j == 2 || j == 3) || ((_flag == 2) && (j == 1))) && checker.DoubleCheck())
                {
                    tmp[j] = ConvertString(subs[j]);
                }
                else if (checker.IntCheck())
                {
                    tmp[j] = ConvertString(subs[j]);
                }
                else
                    throw new Exception("Parametr not a number");
            }
        }

        /// <summary>
        /// Конвертация строки в число.
        /// </summary>
        /// <param name="number">Строка, которую необходимо конвертировать.</param>
        /// <returns>Получившееся число.</returns>
        public double ConvertString(string number)
        {
            return Convert.ToDouble(number, System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
