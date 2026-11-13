using System;
using System.Windows.Forms;

namespace Лаб_1
{
    public partial class ГлавнаяФорма : Form
    {
        public ГлавнаяФорма()
        {
            InitializeComponent();

            // Заполнение cmb транспортом
            cmbCar.Items.Add("БМВ");
            cmbCar.Items.Add("Москвич");
            cmbCar.Items.Add("Феррари");
            cmbCar.SelectedIndex = 0;

            // Заполнение cmb трассами
            cmbTrack.Items.Add("Городское кольцо");
            cmbTrack.Items.Add("Учебный овал");
            cmbTrack.Items.Add("Спринт");
            cmbTrack.SelectedIndex = 0;
        }

        // Кнопка "Добавить"
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string driver = txtDriver.Text.Trim();
            if (driver.Length == 0)
            {
                lblStatus.Text = "Введите имя пилота";
                txtDriver.Focus();
                return;
            }

            if (cmbCar.SelectedIndex == -1 || cmbTrack.SelectedIndex == -1)
            {
                lblStatus.Text = "Выберите автомобиль и трассу";
                return;
            }

            string car = cmbCar.SelectedItem.ToString();
            string track = cmbTrack.SelectedItem.ToString();

            if (car == "Феррари" && driver != "Коваленко" && driver != "Шиян" && driver != "Колотий")
            {
                lblStatus.Text = "Феррари разрешена только пилотам: Коваленко, Шиян, Колотий";
                return;
            }

            if (driver == "Студент ФПМ")
            {
                lblStatus.Text = "Поезжай на трамвае, нищий студент!";
                return;
            }

            string timeText = txtTime.Text.Trim();
            if (!int.TryParse(timeText, out int time))
            {
                lblStatus.Text = "Время должно быть целым числом";
                txtTime.Focus();
                return;
            }

            if (time < 30 || time > 600)
            {
                lblStatus.Text = "Время должно быть от 30 до 600 секунд";
                txtTime.Focus();
                return;
            }

            string result = $"{driver} | {car} | {track} | {time} с";
            lstResults.Items.Add(result);

            ClearInput();
            lblStatus.Text = $"Добавлено. Всего записей: {lstResults.Items.Count}";
        }

        // Кнопка "Удалить" 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstResults.SelectedIndex == -1)
            {
                lblStatus.Text = "Выберите строку для удаления";
                return;
            }

            lstResults.Items.RemoveAt(lstResults.SelectedIndex);

            lblStatus.Text = $"Удалено. Осталось записей: {lstResults.Items.Count}";
        }

        // Кнопка "Очистить"
        private void btnClear_Click(object sender, EventArgs e)
        {

            ClearInput();

            lblStatus.Text = "Поля очищены";
        }

        private void ClearInput()
        {
            txtDriver.Clear();
            txtTime.Clear();
            cmbCar.SelectedIndex = 0;
            cmbTrack.SelectedIndex = 0;
            txtDriver.Focus();
        }
    }
}