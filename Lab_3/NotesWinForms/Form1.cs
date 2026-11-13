using PilotNotes.Core;
using System.ComponentModel;

namespace NotesWinForms
{
    public partial class Form1 : Form
    {
        private NotesViewModel _vm;

        public Form1()
        {
            InitializeComponent();
            
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PilotNotes.WinForms", "notes.json");
            var store = new JsonNoteStore(path);
            _vm = new NotesViewModel(store);

            _vm.PropertyChanged += Vm_PropertyChanged;

            // Первичная привязка (ручная, т.к. WinForms без BindingSource)
            UpdateUI();
        }

        private void Vm_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            txtDraft.Text = _vm.Draft;
            txtQuery.Text = _vm.Query;
            
            // Чтобы не сбрасывать выбор при каждом чихе, обновляем только если список изменился
            if (lstNotes.Items.Count != _vm.VisibleNotes.Count || 
                (lstNotes.SelectedItem as Note)?.Id != _vm.SelectedNote?.Id)
            {
                lstNotes.DataSource = null;
                lstNotes.DataSource = _vm.VisibleNotes.ToList(); // Копия для ListBox
                lstNotes.DisplayMember = nameof(Note.Text);
            }

            lblCount.Text = _vm.CountText;
            lblSaveState.Text = _vm.SaveState;
            lblStatus.Text = _vm.Status;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _vm.Draft = txtDraft.Text;
            _vm.AddCommand.Execute(null);
            txtDraft.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _vm.DeleteCommand.Execute(null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _vm.Query = txtQuery.Text;
            _vm.SearchCommand.Execute(null);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _vm.ResetSearchCommand.Execute(null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _vm.SaveCommand.Execute(null);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            _vm.LoadCommand.Execute(null);
        }

        private void lstNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstNotes.SelectedItem is Note selected)
            {
                _vm.SelectedNote = selected;
            }
        }
    }
}