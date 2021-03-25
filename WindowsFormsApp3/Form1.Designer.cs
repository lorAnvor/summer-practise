namespace WindowsFormsApp3
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
            this.btn_Build = new System.Windows.Forms.Button();
            this.label_order = new System.Windows.Forms.Label();
            this.tb_order = new System.Windows.Forms.TextBox();
            this.btn_addGruphic = new System.Windows.Forms.Button();
            this.btn_saveChart = new System.Windows.Forms.Button();
            this.tb_leftX = new System.Windows.Forms.TextBox();
            this.label_interval = new System.Windows.Forms.Label();
            this.tb_rightX = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Build
            // 
            this.btn_Build.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Build.Location = new System.Drawing.Point(800, 96);
            this.btn_Build.Name = "btn_Build";
            this.btn_Build.Size = new System.Drawing.Size(100, 23);
            this.btn_Build.TabIndex = 0;
            this.btn_Build.Text = "Построить";
            this.btn_Build.UseVisualStyleBackColor = true;
            this.btn_Build.Click += new System.EventHandler(this.btn_Build_Click);
            // 
            // label_order
            // 
            this.label_order.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_order.AutoSize = true;
            this.label_order.Location = new System.Drawing.Point(800, 9);
            this.label_order.Name = "label_order";
            this.label_order.Size = new System.Drawing.Size(100, 13);
            this.label_order.TabIndex = 1;
            this.label_order.Text = "Порядок функции:";
            // 
            // tb_order
            // 
            this.tb_order.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_order.Location = new System.Drawing.Point(800, 25);
            this.tb_order.Name = "tb_order";
            this.tb_order.Size = new System.Drawing.Size(100, 20);
            this.tb_order.TabIndex = 2;
            this.tb_order.Text = "0";
            this.tb_order.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tb_order_MouseClick);
            // 
            // btn_addGruphic
            // 
            this.btn_addGruphic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addGruphic.Location = new System.Drawing.Point(800, 125);
            this.btn_addGruphic.Name = "btn_addGruphic";
            this.btn_addGruphic.Size = new System.Drawing.Size(100, 23);
            this.btn_addGruphic.TabIndex = 3;
            this.btn_addGruphic.Text = "Добавить";
            this.btn_addGruphic.UseVisualStyleBackColor = true;
            this.btn_addGruphic.Visible = false;
            this.btn_addGruphic.Click += new System.EventHandler(this.btn_addGruphic_Click);
            // 
            // btn_saveChart
            // 
            this.btn_saveChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_saveChart.Location = new System.Drawing.Point(800, 154);
            this.btn_saveChart.Name = "btn_saveChart";
            this.btn_saveChart.Size = new System.Drawing.Size(100, 34);
            this.btn_saveChart.TabIndex = 4;
            this.btn_saveChart.Text = "Сохранить график";
            this.btn_saveChart.UseVisualStyleBackColor = true;
            this.btn_saveChart.Visible = false;
            this.btn_saveChart.Click += new System.EventHandler(this.btn_saveChart_Click);
            // 
            // tb_leftX
            // 
            this.tb_leftX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_leftX.Location = new System.Drawing.Point(800, 69);
            this.tb_leftX.Name = "tb_leftX";
            this.tb_leftX.Size = new System.Drawing.Size(45, 20);
            this.tb_leftX.TabIndex = 6;
            this.tb_leftX.Text = "0";
            this.tb_leftX.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tb_leftX_MouseClick);
            // 
            // label_interval
            // 
            this.label_interval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_interval.AutoSize = true;
            this.label_interval.Location = new System.Drawing.Point(800, 53);
            this.label_interval.Name = "label_interval";
            this.label_interval.Size = new System.Drawing.Size(78, 13);
            this.label_interval.TabIndex = 5;
            this.label_interval.Text = "Отрезок по Х:";
            // 
            // tb_rightX
            // 
            this.tb_rightX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_rightX.Location = new System.Drawing.Point(849, 69);
            this.tb_rightX.Name = "tb_rightX";
            this.tb_rightX.Size = new System.Drawing.Size(45, 20);
            this.tb_rightX.TabIndex = 7;
            this.tb_rightX.Text = "25";
            this.tb_rightX.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tb_rightX_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 535);
            this.Controls.Add(this.tb_rightX);
            this.Controls.Add(this.tb_leftX);
            this.Controls.Add(this.label_interval);
            this.Controls.Add(this.btn_saveChart);
            this.Controls.Add(this.btn_addGruphic);
            this.Controls.Add(this.tb_order);
            this.Controls.Add(this.label_order);
            this.Controls.Add(this.btn_Build);
            this.Name = "Form1";
            this.Text = "Функция Бесселя";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Build;
        private System.Windows.Forms.Label label_order;
        private System.Windows.Forms.TextBox tb_order;
        private System.Windows.Forms.Button btn_addGruphic;
        private System.Windows.Forms.Button btn_saveChart;
        private System.Windows.Forms.TextBox tb_leftX;
        private System.Windows.Forms.Label label_interval;
        private System.Windows.Forms.TextBox tb_rightX;
    }
}

