using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PilotNotes.Core;

public class NotesViewModel : INotifyPropertyChanged
{
    private readonly INoteStore _store;
    private List<Note> _allNotes = new();
    private string _draft = "";
    private string _query = "";
    private Note? _selectedNote;
    private string _status = "Готово";
    private bool _isDirty = false;

    public ObservableCollection<Note> VisibleNotes { get; } = new();

    public string Draft
    {
        get => _draft;
        set { if (_draft == value) return; _draft = value; Changed(); AddCommand.Refresh(); }
    }

    public string Query
    {
        get => _query;
        set { if (_query == value) return; _query = value; Changed(); }
    }

    public Note? SelectedNote
    {
        get => _selectedNote;
        set { if (_selectedNote == value) return; _selectedNote = value; Changed(); DeleteCommand.Refresh(); }
    }

    public string Status
    {
        get => _status;
        set { if (_status == value) return; _status = value; Changed(); }
    }

    public bool IsDirty
    {
        get => _isDirty;
        set { if (_isDirty == value) return; _isDirty = value; Changed(); Changed(nameof(SaveState)); LoadCommand.Refresh(); }
    }

    public string CountText => $"Показано: {VisibleNotes.Count}. Всего: {_allNotes.Count}";
    public string SaveState => IsDirty ? "Есть несохранённые изменения" : "Все сохранено";

    public RelayCommand AddCommand { get; }
    public RelayCommand DeleteCommand { get; }
    public RelayCommand SearchCommand { get; }
    public RelayCommand ResetSearchCommand { get; }
    public RelayCommand SaveCommand { get; }
    public RelayCommand LoadCommand { get; }

    public NotesViewModel(INoteStore store)
    {
        _store = store;

        AddCommand = new RelayCommand(Add, () => !string.IsNullOrWhiteSpace(Draft));
        DeleteCommand = new RelayCommand(Delete, () => SelectedNote != null);
        SearchCommand = new RelayCommand(Search);
        ResetSearchCommand = new RelayCommand(ResetSearch);
        SaveCommand = new RelayCommand(Save);
        LoadCommand = new RelayCommand(Load, () => !IsDirty);

        Load(); // Первоначальная загрузка
    }

    public void Add()
    {
        try
        {
            string text = NoteRules.CleanText(Draft);
            var note = new Note { Id = NoteRules.NextId(_allNotes), Text = text };
            _allNotes.Add(note);
            Draft = "";
            IsDirty = true;
            Status = "Заметка добавлена";
            RebuildVisible();
        }
        catch (Exception ex) { Status = ex.Message; }
    }

    public void Delete()
    {
        if (SelectedNote == null) return;
        try
        {
            var toRemove = _allNotes.FirstOrDefault(n => n.Id == SelectedNote.Id);
            if (toRemove != null)
            {
                _allNotes.Remove(toRemove);
                IsDirty = true;
                Status = "Заметка удалена";
                RebuildVisible();
            }
        }
        catch (Exception ex) { Status = ex.Message; }
    }

    public void Search()
    {
        RebuildVisible();
        Status = "Поиск выполнен";
    }

    public void ResetSearch()
    {
        Query = "";
        RebuildVisible();
        Status = "Поиск сброшен";
    }

    public void Save()
    {
        try
        {
            _store.Save(_allNotes);
            IsDirty = false;
            Status = "Сохранено успешно";
        }
        catch (Exception ex) { Status = $"Ошибка сохранения: {ex.Message}"; }
    }

    public void Load()
    {
        if (IsDirty) { Status = "Сначала сохраните изменения!"; return; }
        try
        {
            _allNotes = _store.Load();
            RebuildVisible();
            Status = "Загружено успешно";
        }
        catch (Exception ex) { Status = $"Ошибка загрузки: {ex.Message}"; }
    }

    private void RebuildVisible()
    {
        SelectedNote = null;
        VisibleNotes.Clear();
        foreach (var note in NoteRules.Find(_allNotes, Query))
        {
            VisibleNotes.Add(note);
        }
        Changed(nameof(CountText));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void Changed([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}