using Avalonia.Controls;
using PilotNotes.Core;
using System;
using System.IO;

namespace NotesAvalonia;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PilotNotes.Avalonia", "notes.json");
        var store = new JsonNoteStore(path);
        DataContext = new NotesViewModel(store);
    }
}