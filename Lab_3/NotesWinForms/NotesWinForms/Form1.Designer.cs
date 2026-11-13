namespace NotesWinForms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtDraft = new TextBox();
            this.btnAdd = new Button();
            this.txtQuery = new TextBox();
            this.btnSearch = new Button();
            this.btnReset = new Button();
            this.lstNotes = new ListBox();
            this.btnDelete = new Button();
            this.btnSave = new Button();
            this.btnLoad = new Button();
            this.lblCount = new Label();
            this.lblSaveState = new Label();
            this.lblStatus = new Label();
            this.SuspendLayout();

            // txtDraft
            this.txtDraft.Location = new Point(12, 12);
            this.txtDraft.Size = new Size(300, 23);
            // btnAdd
            this.btnAdd.Location = new Point(320, 10);
            this.btnAdd.Size = new Size(100, 27);
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Click += btnAdd_Click;

            // txtQuery
            this.txtQuery.Location = new Point(12, 50);
            this.txtQuery.Size = new Size(200, 23);
            // btnSearch
            this.btnSearch.Location = new Point(220, 48);
            this.btnSearch.Size = new Size(80, 27);
            this.btnSearch.Text = "Найти";
            this.btnSearch.Click += btnSearch_Click;
            // btnReset
            this.btnReset.Location = new Point(310, 48);
            this.btnReset.Size = new Size(80, 27);
            this.btnReset.Text = "Сброс";
            this.btnReset.Click += btnReset_Click;

            // lstNotes
            this.lstNotes.Location = new Point(12, 90);
            this.lstNotes.Size = new Size(400, 200);
            this.lstNotes.SelectedIndexChanged += lstNotes_SelectedIndexChanged;

            // btnDelete
            this.btnDelete.Location = new Point(12, 300);
            this.btnDelete.Size = new Size(100, 30);
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Click += btnDelete_Click;
            // btnSave
            this.btnSave.Location = new Point(120, 300);
            this.btnSave.Size = new Size(100, 30);
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += btnSave_Click;
            // btnLoad
            this.btnLoad.Location = new Point(230, 300);
            this.btnLoad.Size = new Size(100, 30);
            this.btnLoad.Text = "Загрузить";
            this.btnLoad.Click += btnLoad_Click;

            // lblCount
            this.lblCount.Location = new Point(12, 340);
            this.lblCount.AutoSize = true;
            // lblSaveState
            this.lblSaveState.Location = new Point(12, 360);
            this.lblSaveState.AutoSize = true;
            // lblStatus
            this.lblStatus.Location = new Point(12, 380);
            this.lblStatus.AutoSize = true;

            // Form1
            this.ClientSize = new Size(440, 420);
            this.Controls.Add(this.txtDraft);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lstNotes);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblSaveState);
            this.Controls.Add(this.lblStatus);
            this.Text = "Заметки пилота (WinForms)";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private TextBox txtDraft;
        private Button btnAdd;
        private TextBox txtQuery;
        private Button btnSearch;
        private Button btnReset;
        private ListBox lstNotes;
        private Button btnDelete;
        private Button btnSave;
        private Button btnLoad;
        private Label lblCount;
        private Label lblSaveState;
        private Label lblStatus;
    }
}