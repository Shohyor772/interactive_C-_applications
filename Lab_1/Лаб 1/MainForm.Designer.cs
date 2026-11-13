namespace Лаб_1
{
    partial class ГлавнаяФорма
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            txtDriver = new TextBox();
            btnAdd = new Button();
            lstResults = new ListBox();
            lblTitle = new Label();
            label1 = new Label();
            btnDelete = new Button();
            btnClear = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtTime = new TextBox();
            lblStatus = new Label();
            cmbCar = new ComboBox();
            cmbTrack = new ComboBox();
            SuspendLayout();
            // 
            // txtDriver
            // 
            txtDriver.Font = new Font("Segoe UI", 25F);
            txtDriver.Location = new Point(256, 261);
            txtDriver.Name = "txtDriver";
            txtDriver.Size = new Size(318, 52);
            txtDriver.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 17F);
            btnAdd.Location = new Point(21, 626);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(379, 61);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Добавить результат";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lstResults
            // 
            lstResults.Font = new Font("Segoe UI", 17F);
            lstResults.FormattingEnabled = true;
            lstResults.ItemHeight = 31;
            lstResults.Location = new Point(631, 230);
            lstResults.Name = "lstResults";
            lstResults.Size = new Size(500, 283);
            lstResults.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 30F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(470, 54);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Учебный автосимулятор";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F);
            label1.Location = new Point(12, 63);
            label1.Name = "label1";
            label1.Size = new Size(574, 46);
            label1.TabIndex = 4;
            label1.Text = "Первый прототип журнала заездов";
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 17F);
            btnDelete.Location = new Point(406, 626);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(379, 61);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Удалить выбранное";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 17F);
            btnClear.Location = new Point(791, 626);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(363, 61);
            btnClear.TabIndex = 8;
            btnClear.Text = "Очистить поля";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 25F);
            label2.Location = new Point(22, 267);
            label2.Name = "label2";
            label2.Size = new Size(116, 46);
            label2.TabIndex = 9;
            label2.Text = "Пилот";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 25F);
            label3.Location = new Point(22, 319);
            label3.Name = "label3";
            label3.Size = new Size(213, 46);
            label3.TabIndex = 10;
            label3.Text = "Автомобиль";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 25F);
            label4.Location = new Point(21, 378);
            label4.Name = "label4";
            label4.Size = new Size(124, 46);
            label4.TabIndex = 11;
            label4.Text = "Трасса";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 25F);
            label5.Location = new Point(22, 437);
            label5.Name = "label5";
            label5.Size = new Size(150, 46);
            label5.TabIndex = 12;
            label5.Text = "Время, с";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 25F);
            label6.Location = new Point(631, 181);
            label6.Name = "label6";
            label6.Size = new Size(192, 46);
            label6.TabIndex = 13;
            label6.Text = "Результаты";
            // 
            // txtTime
            // 
            txtTime.Font = new Font("Segoe UI", 25F);
            txtTime.Location = new Point(256, 437);
            txtTime.Name = "txtTime";
            txtTime.Size = new Size(318, 52);
            txtTime.TabIndex = 14;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 25F);
            lblStatus.Location = new Point(22, 701);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(128, 46);
            lblStatus.TabIndex = 15;
            lblStatus.Text = "Готово";
            // 
            // cmbCar
            // 
            cmbCar.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCar.Font = new Font("Segoe UI", 25F);
            cmbCar.FormattingEnabled = true;
            cmbCar.Location = new Point(256, 319);
            cmbCar.Name = "cmbCar";
            cmbCar.Size = new Size(318, 53);
            cmbCar.TabIndex = 16;
            // 
            // cmbTrack
            // 
            cmbTrack.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrack.Font = new Font("Segoe UI", 25F);
            cmbTrack.FormattingEnabled = true;
            cmbTrack.Location = new Point(256, 378);
            cmbTrack.Name = "cmbTrack";
            cmbTrack.Size = new Size(318, 53);
            cmbTrack.TabIndex = 17;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 781);
            Controls.Add(cmbTrack);
            Controls.Add(cmbCar);
            Controls.Add(lblStatus);
            Controls.Add(txtTime);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(label1);
            Controls.Add(lblTitle);
            Controls.Add(lstResults);
            Controls.Add(btnAdd);
            Controls.Add(txtDriver);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDriver;
        private Button btnAdd;
        private ListBox lstResults;
        private Label lblTitle;
        private Label label1;
        private Button btnDelete;
        private Button btnClear;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtTime;
        private Label lblStatus;
        private ComboBox cmbCar;
        private ComboBox cmbTrack;
    }
}
