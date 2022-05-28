namespace Quan_Ly_Chuyen_Bay
{
    partial class fChartByYear
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartColumn = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartColumn)).BeginInit();
            this.SuspendLayout();
            // 
            // chartPie
            // 
            chartArea1.Name = "ChartArea1";
            this.chartPie.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPie.Legends.Add(legend1);
            this.chartPie.Location = new System.Drawing.Point(1124, 13);
            this.chartPie.Name = "chartPie";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "VND";
            this.chartPie.Series.Add(series1);
            this.chartPie.Size = new System.Drawing.Size(1033, 963);
            this.chartPie.TabIndex = 1;
            this.chartPie.Text = "chart2";
            // 
            // chartColumn
            // 
            chartArea2.Name = "ChartArea1";
            this.chartColumn.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartColumn.Legends.Add(legend2);
            this.chartColumn.Location = new System.Drawing.Point(13, 13);
            this.chartColumn.Name = "chartColumn";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartColumn.Series.Add(series2);
            this.chartColumn.Size = new System.Drawing.Size(1105, 963);
            this.chartColumn.TabIndex = 0;
            this.chartColumn.Text = "chart1";
            // 
            // fChartByYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2183, 1044);
            this.Controls.Add(this.chartPie);
            this.Controls.Add(this.chartColumn);
            this.Name = "fChartByYear";
            this.Text = "fChartByYear";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fChartByYear_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartColumn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartPie;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartColumn;
    }
}