
namespace DemographicWinForms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            this.DisposeProgramm();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend13 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend14 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea15 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend15 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.death_take = new System.Windows.Forms.Button();
            this.start_take = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.population = new System.Windows.Forms.TextBox();
            this.year_end = new System.Windows.Forms.TextBox();
            this.year_st = new System.Windows.Forms.TextBox();
            this.bar_m = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bar_w = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.filepathboxdeath = new System.Windows.Forms.TextBox();
            this.filepathboxinitial = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.abortation = new System.Windows.Forms.Button();
            this.pause = new System.Windows.Forms.Button();
            this.unpause = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar_m)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar_w)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea13.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea13);
            legend13.Name = "Legend1";
            this.chart1.Legends.Add(legend13);
            this.chart1.Location = new System.Drawing.Point(445, 12);
            this.chart1.Name = "chart1";
            series13.ChartArea = "ChartArea1";
            series13.Legend = "Legend1";
            series13.Name = "Series1";
            this.chart1.Series.Add(series13);
            this.chart1.Size = new System.Drawing.Size(880, 426);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // death_take
            // 
            this.death_take.Location = new System.Drawing.Point(12, 272);
            this.death_take.Name = "death_take";
            this.death_take.Size = new System.Drawing.Size(101, 58);
            this.death_take.TabIndex = 1;
            this.death_take.Text = "Death Rules";
            this.death_take.UseVisualStyleBackColor = true;
            this.death_take.Click += new System.EventHandler(this.death_take_Click);
            // 
            // start_take
            // 
            this.start_take.Location = new System.Drawing.Point(12, 336);
            this.start_take.Name = "start_take";
            this.start_take.Size = new System.Drawing.Size(101, 57);
            this.start_take.TabIndex = 2;
            this.start_take.Text = "Initial Age";
            this.start_take.UseVisualStyleBackColor = true;
            this.start_take.Click += new System.EventHandler(this.start_take_Click);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(12, 399);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(101, 59);
            this.start.TabIndex = 3;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Year start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Year end";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Population (thou.)";
            // 
            // population
            // 
            this.population.Location = new System.Drawing.Point(303, 174);
            this.population.Name = "population";
            this.population.Size = new System.Drawing.Size(100, 26);
            this.population.TabIndex = 7;
            // 
            // year_end
            // 
            this.year_end.Location = new System.Drawing.Point(303, 105);
            this.year_end.Name = "year_end";
            this.year_end.Size = new System.Drawing.Size(100, 26);
            this.year_end.TabIndex = 7;
            // 
            // year_st
            // 
            this.year_st.Location = new System.Drawing.Point(303, 47);
            this.year_st.Name = "year_st";
            this.year_st.Size = new System.Drawing.Size(100, 26);
            this.year_st.TabIndex = 7;
            // 
            // bar_m
            // 
            chartArea14.Name = "ChartArea1";
            this.bar_m.ChartAreas.Add(chartArea14);
            legend14.Name = "Legend1";
            this.bar_m.Legends.Add(legend14);
            this.bar_m.Location = new System.Drawing.Point(30, 464);
            this.bar_m.Name = "bar_m";
            series14.ChartArea = "ChartArea1";
            series14.Legend = "Legend1";
            series14.Name = "Series1";
            this.bar_m.Series.Add(series14);
            this.bar_m.Size = new System.Drawing.Size(583, 484);
            this.bar_m.TabIndex = 8;
            this.bar_m.Text = "bar_w";
            // 
            // bar_w
            // 
            chartArea15.Name = "ChartArea1";
            this.bar_w.ChartAreas.Add(chartArea15);
            legend15.Name = "Legend1";
            this.bar_w.Legends.Add(legend15);
            this.bar_w.Location = new System.Drawing.Point(639, 464);
            this.bar_w.Name = "bar_w";
            series15.ChartArea = "ChartArea1";
            series15.Legend = "Legend1";
            series15.Name = "Series1";
            this.bar_w.Series.Add(series15);
            this.bar_w.Size = new System.Drawing.Size(583, 484);
            this.bar_w.TabIndex = 8;
            this.bar_w.Text = "bar_w";
            // 
            // filepathboxdeath
            // 
            this.filepathboxdeath.Location = new System.Drawing.Point(120, 293);
            this.filepathboxdeath.Name = "filepathboxdeath";
            this.filepathboxdeath.ReadOnly = true;
            this.filepathboxdeath.Size = new System.Drawing.Size(319, 26);
            this.filepathboxdeath.TabIndex = 9;
            // 
            // filepathboxinitial
            // 
            this.filepathboxinitial.Location = new System.Drawing.Point(120, 351);
            this.filepathboxinitial.Name = "filepathboxinitial";
            this.filepathboxinitial.ReadOnly = true;
            this.filepathboxinitial.Size = new System.Drawing.Size(319, 26);
            this.filepathboxinitial.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "default: 2021";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 20);
            this.label5.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(166, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "default: 1970";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(162, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "default: 130 000";
            // 
            // abortation
            // 
            this.abortation.Location = new System.Drawing.Point(120, 399);
            this.abortation.Name = "abortation";
            this.abortation.Size = new System.Drawing.Size(102, 59);
            this.abortation.TabIndex = 14;
            this.abortation.Text = "Abort";
            this.abortation.UseVisualStyleBackColor = true;
            this.abortation.Click += new System.EventHandler(this.abortation_Click);
            // 
            // pause
            // 
            this.pause.Location = new System.Drawing.Point(229, 399);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(102, 59);
            this.pause.TabIndex = 15;
            this.pause.Text = "Pause";
            this.pause.UseVisualStyleBackColor = true;
            this.pause.Click += new System.EventHandler(this.pause_Click);
            // 
            // unpause
            // 
            this.unpause.Enabled = false;
            this.unpause.Location = new System.Drawing.Point(337, 399);
            this.unpause.Name = "unpause";
            this.unpause.Size = new System.Drawing.Size(102, 59);
            this.unpause.TabIndex = 16;
            this.unpause.Text = "Unpause";
            this.unpause.UseVisualStyleBackColor = true;
            this.unpause.Click += new System.EventHandler(this.unpause_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 1050);
            this.Controls.Add(this.unpause);
            this.Controls.Add(this.pause);
            this.Controls.Add(this.abortation);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.filepathboxinitial);
            this.Controls.Add(this.filepathboxdeath);
            this.Controls.Add(this.bar_w);
            this.Controls.Add(this.bar_m);
            this.Controls.Add(this.year_st);
            this.Controls.Add(this.year_end);
            this.Controls.Add(this.population);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.start);
            this.Controls.Add(this.start_take);
            this.Controls.Add(this.death_take);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar_m)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar_w)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button death_take;
        private System.Windows.Forms.Button start_take;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox population;
        private System.Windows.Forms.TextBox year_end;
        private System.Windows.Forms.TextBox year_st;
        private System.Windows.Forms.DataVisualization.Charting.Chart bar_m;
        private System.Windows.Forms.DataVisualization.Charting.Chart bar_w;
        private System.Windows.Forms.TextBox filepathboxdeath;
        private System.Windows.Forms.TextBox filepathboxinitial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button abortation;
        private System.Windows.Forms.Button pause;
        private System.Windows.Forms.Button unpause;
    }
}

