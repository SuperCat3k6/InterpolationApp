namespace InterpolationApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.plotViewLagrange = new OxyPlot.WindowsForms.PlotView();
            this.plotViewNewton = new OxyPlot.WindowsForms.PlotView();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.plotViewLagrangeCh = new OxyPlot.WindowsForms.PlotView();
            this.plotViewNewtonEq = new OxyPlot.WindowsForms.PlotView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 616);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(785, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // plotViewLagrange
            // 
            this.plotViewLagrange.Location = new System.Drawing.Point(12, 12);
            this.plotViewLagrange.Name = "plotViewLagrange";
            this.plotViewLagrange.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotViewLagrange.Size = new System.Drawing.Size(571, 287);
            this.plotViewLagrange.TabIndex = 3;
            this.plotViewLagrange.Text = "Лагранж по равноудаленным";
            this.plotViewLagrange.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotViewLagrange.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotViewLagrange.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // plotViewNewton
            // 
            this.plotViewNewton.Location = new System.Drawing.Point(589, 305);
            this.plotViewNewton.Name = "plotViewNewton";
            this.plotViewNewton.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotViewNewton.Size = new System.Drawing.Size(563, 305);
            this.plotViewNewton.TabIndex = 4;
            this.plotViewNewton.Text = "Ньютон по оптимальным";
            this.plotViewNewton.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotViewNewton.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotViewNewton.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(903, 658);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(202, 57);
            this.btnCalculate.TabIndex = 5;
            this.btnCalculate.Text = "Вычисление (обновит графики)";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // plotViewLagrangeCh
            // 
            this.plotViewLagrangeCh.Location = new System.Drawing.Point(12, 305);
            this.plotViewLagrangeCh.Name = "plotViewLagrangeCh";
            this.plotViewLagrangeCh.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotViewLagrangeCh.Size = new System.Drawing.Size(571, 305);
            this.plotViewLagrangeCh.TabIndex = 6;
            this.plotViewLagrangeCh.Text = "Лагранж по оптимальным";
            this.plotViewLagrangeCh.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotViewLagrangeCh.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotViewLagrangeCh.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // plotViewNewtonEq
            // 
            this.plotViewNewtonEq.Location = new System.Drawing.Point(589, 5);
            this.plotViewNewtonEq.Name = "plotViewNewtonEq";
            this.plotViewNewtonEq.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotViewNewtonEq.Size = new System.Drawing.Size(563, 294);
            this.plotViewNewtonEq.TabIndex = 7;
            this.plotViewNewtonEq.Text = "Ньютон по равноудаленным";
            this.plotViewNewtonEq.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotViewNewtonEq.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotViewNewtonEq.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 778);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.plotViewNewtonEq);
            this.Controls.Add(this.plotViewLagrangeCh);
            this.Controls.Add(this.plotViewNewton);
            this.Controls.Add(this.plotViewLagrange);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Интерполирование функции";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private OxyPlot.WindowsForms.PlotView plotViewLagrange;
        private OxyPlot.WindowsForms.PlotView plotViewNewton;
        private System.Windows.Forms.Button btnCalculate;
        private OxyPlot.WindowsForms.PlotView plotViewLagrangeCh;
        private OxyPlot.WindowsForms.PlotView plotViewNewtonEq;
    }
}

