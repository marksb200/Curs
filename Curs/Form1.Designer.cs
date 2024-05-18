namespace Curs
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
            this.mode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.actionButton = new System.Windows.Forms.Button();
            this.answerSpace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.createTable = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.numericCountGuests = new System.Windows.Forms.NumericUpDown();
            this.alg = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCountGuests)).BeginInit();
            this.SuspendLayout();
            // 
            // mode
            // 
            this.mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mode.FormattingEnabled = true;
            this.mode.Items.AddRange(new object[] {
            "Автозаполнение",
            "Ввод в ручную"});
            this.mode.Location = new System.Drawing.Point(892, 133);
            this.mode.Name = "mode";
            this.mode.Size = new System.Drawing.Size(143, 24);
            this.mode.TabIndex = 0;
            this.mode.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(889, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Режим ввода данных:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(889, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Количество гостей:";
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(12, 12);
            this.DGV.Name = "DGV";
            this.DGV.RowHeadersWidth = 51;
            this.DGV.RowTemplate.Height = 24;
            this.DGV.Size = new System.Drawing.Size(874, 409);
            this.DGV.TabIndex = 4;
            this.DGV.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DGV_CellValidating);
            // 
            // actionButton
            // 
            this.actionButton.Location = new System.Drawing.Point(609, 460);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(75, 40);
            this.actionButton.TabIndex = 5;
            this.actionButton.Text = "Решить задачу";
            this.actionButton.UseVisualStyleBackColor = true;
            this.actionButton.Click += new System.EventHandler(this.actionButton_Click);
            // 
            // answerSpace
            // 
            this.answerSpace.Location = new System.Drawing.Point(84, 469);
            this.answerSpace.Name = "answerSpace";
            this.answerSpace.Size = new System.Drawing.Size(494, 22);
            this.answerSpace.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 472);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ответ:";
            // 
            // createTable
            // 
            this.createTable.Location = new System.Drawing.Point(892, 246);
            this.createTable.Name = "createTable";
            this.createTable.Size = new System.Drawing.Size(94, 43);
            this.createTable.TabIndex = 8;
            this.createTable.Text = "Построить таблицу";
            this.createTable.UseVisualStyleBackColor = true;
            this.createTable.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(892, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 55);
            this.button1.TabIndex = 9;
            this.button1.Text = "Проверка данных";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // numericCountGuests
            // 
            this.numericCountGuests.Location = new System.Drawing.Point(892, 206);
            this.numericCountGuests.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericCountGuests.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericCountGuests.Name = "numericCountGuests";
            this.numericCountGuests.Size = new System.Drawing.Size(120, 22);
            this.numericCountGuests.TabIndex = 10;
            this.numericCountGuests.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // alg
            // 
            this.alg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.alg.FormattingEnabled = true;
            this.alg.Items.AddRange(new object[] {
            "Полный перебор",
            "Жадный алгоритм"});
            this.alg.Location = new System.Drawing.Point(892, 67);
            this.alg.Name = "alg";
            this.alg.Size = new System.Drawing.Size(143, 24);
            this.alg.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(893, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Алгоритм:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.alg);
            this.Controls.Add(this.numericCountGuests);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.createTable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.answerSpace);
            this.Controls.Add(this.actionButton);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mode);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCountGuests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox mode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button actionButton;
        private System.Windows.Forms.TextBox answerSpace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button createTable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericCountGuests;
        private System.Windows.Forms.ComboBox alg;
        private System.Windows.Forms.Label label4;
    }
}

