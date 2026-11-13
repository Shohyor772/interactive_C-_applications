using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Лаб_2;

namespace Лаб_2
{
    public partial class MainForm : Form
    {
        private List<RaceResult> allResults = new List<RaceResult>();
        private RaceRepository repository;

        public MainForm()
        {
            InitializeComponent();

            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RaceLogLab2");
            Directory.CreateDirectory(folder);
            string dbPath = Path.Combine(folder, "races.db");
            lblStorage.Text = dbPath;

            repository = new RaceRepository(dbPath);
            repository.Initialize();

            gridResults.AutoGenerateColumns = false;

            cmbCar.Items.Add("Prototype");
            cmbCar.Items.Add("Street");
            cmbCar.Items.Add("Sport");
            cmbCar.SelectedIndex = 0;

            cmbTrack.Items.Add("Городское кольцо");
            cmbTrack.Items.Add("Учебный овал");
            cmbTrack.Items.Add("Спринт");
            cmbTrack.SelectedIndex = 0;

            cmbTrackFilter.Items.Add("Все трассы");
            cmbTrackFilter.Items.Add("Учебный овал");
            cmbTrackFilter.Items.Add("Городское кольцо");
            cmbTrackFilter.Items.Add("Спринт");
            cmbTrackFilter.SelectedIndex = 0;

            source.DataSource = allResults;
            gridResults.DataSource = source;

            Reload();
        }

        private RaceResult ReadInput(long id)
        {
            var result = new RaceResult
            {
                Id = id,
                Driver = txtDriver.Text.Trim(),
                Car = cmbCar.SelectedItem?.ToString() ?? "",
                Track = cmbTrack.SelectedItem?.ToString() ?? "",
            };

            if (!int.TryParse(txtSeconds.Text, out int seconds))
            {
                throw new ArgumentException("Время должно быть целым числом.");
            }
            result.LapSeconds = seconds;

            RaceRules.Validate(result);
            return result;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var newResult = ReadInput(0);
                repository.Add(newResult);
                Reload();
                ClearInput();
                lblStatus.Text = $"Добавлено. Всего записей: {allResults.Count}";
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (gridResults.SelectedRows.Count == 0)
            {
                lblStatus.Text = "Выберите строку для изменения";
                return;
            }

            var selected = gridResults.SelectedRows[0].DataBoundItem as RaceResult;
            if (selected == null) return;

            try
            {
                var updated = ReadInput(selected.Id);
                repository.Update(updated);
                Reload();
                ClearInput();
                lblStatus.Text = $"Запись Id={updated.Id} обновлена.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridResults.SelectedRows.Count == 0)
            {
                lblStatus.Text = "Выберите строку для удаления";
                return;
            }

            var selected = gridResults.SelectedRows[0].DataBoundItem as RaceResult;
            if (selected == null) return;

            var answer = MessageBox.Show(
                $"Удалить запись Id={selected.Id} ({selected.Driver})?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer != DialogResult.Yes) return;

            try
            {
                repository.Delete(selected.Id);
                Reload();
                lblStatus.Text = $"Удалено. Осталось записей: {allResults.Count}";
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInput();
            gridResults.ClearSelection();
            lblStatus.Text = "Поля очищены";
        }

        private void ClearInput()
        {
            txtDriver.Clear();
            txtSeconds.Clear();
            txtDriver.Focus();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbTrackFilter.SelectedIndex = 0;
            ApplyFilter();
        }

        private void Reload()
        {
            allResults = repository.GetAll();
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string searchText = txtSearch.Text;
            string selectedTrack = cmbTrackFilter.SelectedItem?.ToString() ?? "Все трассы";

            var filtered = RaceQuery.Apply(allResults, searchText, selectedTrack);

            source.DataSource = filtered;
            gridResults.ClearSelection();

            lblStatus.Text = $"Показано: {filtered.Count}. Всего: {allResults.Count}";
        }

        private void gridResults_SelectionChanged(object sender, EventArgs e)
        {
            if (gridResults.SelectedRows.Count == 0) return;

            var selected = gridResults.SelectedRows[0].DataBoundItem as RaceResult;
            if (selected == null) return;

            txtDriver.Text = selected.Driver;
            cmbCar.SelectedItem = selected.Car;
            cmbTrack.SelectedItem = selected.Track;
            txtSeconds.Text = selected.LapSeconds.ToString();
        }

        // ===== ЭТАП 7: СОХРАНЕНИЕ КОПИЙ =====
        private void btnSaveJson_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                Title = "Сохранить журнал в JSON"
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                var all = repository.GetAll();
                RaceTransfer.SaveJson(dialog.FileName, all);
                lblStatus.Text = $"Сохранено в JSON: {dialog.FileName}";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Ошибка сохранения: {ex.Message}";
            }
        }

        private void btnSaveXml_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog
            {
                Filter = "XML files (*.xml)|*.xml",
                Title = "Сохранить журнал в XML"
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                var all = repository.GetAll();
                RaceTransfer.SaveXml(dialog.FileName, all);
                lblStatus.Text = $"Сохранено в XML: {dialog.FileName}";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Ошибка сохранения: {ex.Message}";
            }
        }

        // ===== ЭТАП 8: ВОССТАНОВЛЕНИЕ ЖУРНАЛА =====
        private void btnLoadJson_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                Title = "Загрузить журнал из JSON"
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                var imported = RaceTransfer.LoadJson(dialog.FileName);
                RaceRules.ValidateImport(imported);

                var answer = MessageBox.Show(
                    $"Весь текущий журнал ({allResults.Count} записей) будет заменён на {imported.Count} записей. Продолжить?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (answer != DialogResult.Yes) return;

                repository.ReplaceAll(imported);
                txtSearch.Clear();
                cmbTrackFilter.SelectedIndex = 0;
                Reload();
                lblStatus.Text = $"Импортировано из JSON: {imported.Count} записей.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Ошибка импорта: {ex.Message}";
            }
        }

        private void btnLoadXml_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "XML files (*.xml)|*.xml",
                Title = "Загрузить журнал из XML"
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                var imported = RaceTransfer.LoadXml(dialog.FileName);
                RaceRules.ValidateImport(imported);

                var answer = MessageBox.Show(
                    $"Весь текущий журнал ({allResults.Count} записей) будет заменён на {imported.Count} записей. Продолжить?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (answer != DialogResult.Yes) return;

                repository.ReplaceAll(imported);
                txtSearch.Clear();
                cmbTrackFilter.SelectedIndex = 0;
                Reload();
                lblStatus.Text = $"Импортировано из XML: {imported.Count} записей.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Ошибка импорта: {ex.Message}";
            }
        }
    }
}