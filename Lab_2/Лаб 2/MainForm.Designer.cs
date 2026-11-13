using System.Windows.Forms;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;      // <-- ЭТОЙ СТРОЧКИ, СКОРЕЕ ВСЕГО, НЕТ


namespace Лаб_2
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            txtDriver = new TextBox();
            btnAdd = new Button();
            lblTitle = new Label();
            label1 = new Label();
            btnDelete = new Button();
            btnClear = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtSeconds = new TextBox();
            lblStatus = new Label();
            cmbCar = new ComboBox();
            cmbTrack = new ComboBox();
            gridResults = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colDriver = new DataGridViewTextBoxColumn();
            colCar = new DataGridViewTextBoxColumn();
            colTrack = new DataGridViewTextBoxColumn();
            colLapSeconds = new DataGridViewTextBoxColumn();
            source = new BindingSource(components);
            txtSearch = new TextBox();
            cmbTrackFilter = new ComboBox();
            btnFilter = new Button();
            btnResetFilter = new Button();
            lblStorage = new Label();
            btnUpdate = new Button();
            btnSaveJson = new Button();
            btnSaveXml = new Button();
            btnLoadJson = new Button();
            btnLoadXml = new Button();
            ((System.ComponentModel.ISupportInitialize)gridResults).BeginInit();
            ((System.ComponentModel.ISupportInitialize)source).BeginInit();
            SuspendLayout();
            // 
            // txtDriver
            // 
            txtDriver.Location = new Point(106, 82);
            txtDriver.Name = "txtDriver";
            txtDriver.Size = new Size(198, 23);
            txtDriver.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 379);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 32);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(321, 37);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Учебный автосимулятор";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(12, 46);
            label1.Name = "label1";
            label1.Size = new Size(230, 19);
            label1.TabIndex = 4;
            label1.Text = "Второй прототип журнала заездов";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(224, 379);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 32);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(330, 379);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 32);
            btnClear.TabIndex = 8;
            btnClear.Text = "Очистить поля";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 90);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 9;
            label2.Text = "Пилот";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 119);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 10;
            label3.Text = "Автомобиль";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 154);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 11;
            label4.Text = "Трасса";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 193);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 12;
            label5.Text = "Время, с";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(344, 101);
            label6.Name = "label6";
            label6.Size = new Size(69, 15);
            label6.TabIndex = 13;
            label6.Text = "Результаты";
            // 
            // txtSeconds
            // 
            txtSeconds.Location = new Point(106, 185);
            txtSeconds.Name = "txtSeconds";
            txtSeconds.Size = new Size(198, 23);
            txtSeconds.TabIndex = 14;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(22, 461);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(45, 15);
            lblStatus.TabIndex = 15;
            lblStatus.Text = "Готово";
            // 
            // cmbCar
            // 
            cmbCar.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCar.FormattingEnabled = true;
            cmbCar.Location = new Point(106, 119);
            cmbCar.Name = "cmbCar";
            cmbCar.Size = new Size(198, 23);
            cmbCar.TabIndex = 16;
            // 
            // cmbTrack
            // 
            cmbTrack.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrack.FormattingEnabled = true;
            cmbTrack.Location = new Point(106, 154);
            cmbTrack.Name = "cmbTrack";
            cmbTrack.Size = new Size(198, 23);
            cmbTrack.TabIndex = 17;
            // 
            // gridResults
            // 
            gridResults.AllowUserToAddRows = false;
            gridResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridResults.Columns.AddRange(new DataGridViewColumn[] { colId, colDriver, colCar, colTrack, colLapSeconds });
            gridResults.Location = new Point(344, 119);
            gridResults.Name = "gridResults";
            gridResults.ReadOnly = true;
            gridResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridResults.Size = new Size(420, 250);
            gridResults.TabIndex = 18;
            gridResults.SelectionChanged += gridResults_SelectionChanged;
            // 
            // colId
            // 
            colId.DataPropertyName = "Id";
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colDriver
            // 
            colDriver.DataPropertyName = "Driver";
            colDriver.HeaderText = "Пилот";
            colDriver.Name = "colDriver";
            colDriver.ReadOnly = true;
            // 
            // colCar
            // 
            colCar.DataPropertyName = "Car";
            colCar.HeaderText = "Автомобиль";
            colCar.Name = "colCar";
            colCar.ReadOnly = true;
            // 
            // colTrack
            // 
            colTrack.DataPropertyName = "Track";
            colTrack.HeaderText = "Трасса";
            colTrack.Name = "colTrack";
            colTrack.ReadOnly = true;
            // 
            // colLapSeconds
            // 
            colLapSeconds.DataPropertyName = "LapSeconds";
            colLapSeconds.HeaderText = "Время, с";
            colLapSeconds.Name = "colLapSeconds";
            colLapSeconds.ReadOnly = true;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(373, 65);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(100, 23);
            txtSearch.TabIndex = 19;
            // 
            // cmbTrackFilter
            // 
            cmbTrackFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrackFilter.FormattingEnabled = true;
            cmbTrackFilter.Items.AddRange(new object[] { "Все трассы", "Учебный овал", "Городское кольцо", "Спринт" });
            cmbTrackFilter.Location = new Point(479, 65);
            cmbTrackFilter.Name = "cmbTrackFilter";
            cmbTrackFilter.Size = new Size(121, 23);
            cmbTrackFilter.TabIndex = 20;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(606, 64);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(75, 23);
            btnFilter.TabIndex = 21;
            btnFilter.Text = "Найти";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnResetFilter
            // 
            btnResetFilter.Location = new Point(687, 64);
            btnResetFilter.Name = "btnResetFilter";
            btnResetFilter.Size = new Size(77, 23);
            btnResetFilter.TabIndex = 22;
            btnResetFilter.Text = "Сброс";
            btnResetFilter.UseVisualStyleBackColor = true;
            btnResetFilter.Click += btnResetFilter_Click;
            // 
            // lblStorage
            // 
            lblStorage.AutoSize = true;
            lblStorage.Location = new Point(22, 500);
            lblStorage.Name = "lblStorage";
            lblStorage.Size = new Size(69, 15);
            lblStorage.TabIndex = 23;
            lblStorage.Text = "Путь к базе";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(118, 379);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 32);
            btnUpdate.TabIndex = 24;
            btnUpdate.Text = "Сохранить правку";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnSaveJson
            // 
            btnSaveJson.Location = new Point(12, 417);
            btnSaveJson.Name = "btnSaveJson";
            btnSaveJson.Size = new Size(100, 32);
            btnSaveJson.TabIndex = 25;
            btnSaveJson.Text = "В JSON";
            btnSaveJson.UseVisualStyleBackColor = true;
            btnSaveJson.Click += btnSaveJson_Click;
            // 
            // btnSaveXml
            // 
            btnSaveXml.Location = new Point(118, 417);
            btnSaveXml.Name = "btnSaveXml";
            btnSaveXml.Size = new Size(100, 32);
            btnSaveXml.TabIndex = 26;
            btnSaveXml.Text = "В XML";
            btnSaveXml.UseVisualStyleBackColor = true;
            btnSaveXml.Click += btnSaveXml_Click;
            // 
            // btnLoadJson
            // 
            btnLoadJson.Location = new Point(224, 417);
            btnLoadJson.Name = "btnLoadJson";
            btnLoadJson.Size = new Size(100, 32);
            btnLoadJson.TabIndex = 27;
            btnLoadJson.Text = "Из JSON";
            btnLoadJson.UseVisualStyleBackColor = true;
            btnLoadJson.Click += btnLoadJson_Click;
            // 
            // btnLoadXml
            // 
            btnLoadXml.Location = new Point(330, 417);
            btnLoadXml.Name = "btnLoadXml";
            btnLoadXml.Size = new Size(100, 32);
            btnLoadXml.TabIndex = 28;
            btnLoadXml.Text = "Из XML";
            btnLoadXml.UseVisualStyleBackColor = true;
            btnLoadXml.Click += btnLoadXml_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 530);
            Controls.Add(lblStorage);
            Controls.Add(btnResetFilter);
            Controls.Add(btnFilter);
            Controls.Add(cmbTrackFilter);
            Controls.Add(txtSearch);
            Controls.Add(gridResults);
            Controls.Add(cmbTrack);
            Controls.Add(cmbCar);
            Controls.Add(lblStatus);
            Controls.Add(txtSeconds);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(label1);
            Controls.Add(lblTitle);
            Controls.Add(btnLoadXml);
            Controls.Add(btnLoadJson);
            Controls.Add(btnSaveXml);
            Controls.Add(btnSaveJson);
            Controls.Add(btnAdd);
            Controls.Add(txtDriver);
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)gridResults).EndInit();
            ((System.ComponentModel.ISupportInitialize)source).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDriver;
        private Button btnAdd;
        private Label lblTitle;
        private Label label1;
        private Button btnDelete;
        private Button btnClear;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtSeconds;
        private Label lblStatus;
        private ComboBox cmbCar;
        private ComboBox cmbTrack;
        private DataGridView gridResults;
        private BindingSource source;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colDriver;
        private DataGridViewTextBoxColumn colCar;
        private DataGridViewTextBoxColumn colTrack;
        private DataGridViewTextBoxColumn colLapSeconds;
        private TextBox txtSearch;
        private ComboBox cmbTrackFilter;
        private Button btnFilter;
        private Button btnResetFilter;
        private Label lblStorage;
        private Button btnUpdate;
        private Button btnSaveJson;
        private Button btnSaveXml;
        private Button btnLoadJson;
        private Button btnLoadXml;
    }
}