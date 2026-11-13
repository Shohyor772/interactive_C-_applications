using PilotNotes.Core;

namespace NotesMaui;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        
        string path = Path.Combine(FileSystem.Current.AppDataDirectory, "notes.json");
        var store = new JsonNoteStore(path);
        BindingContext = new NotesViewModel(store);
    }
}