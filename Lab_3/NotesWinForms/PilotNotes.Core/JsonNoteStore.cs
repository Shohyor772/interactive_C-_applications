using System.Text.Json;

namespace PilotNotes.Core;

public class JsonNoteStore : INoteStore
{
    private readonly string _path;

    public JsonNoteStore(string path)
    {
        _path = path;
    }

    public List<Note> Load()
    {
        if (!File.Exists(_path)) return new List<Note>();

        try
        {
            string json = File.ReadAllText(_path);
            var notes = JsonSerializer.Deserialize<List<Note>>(json);
            return NoteRules.ValidateCopy(notes);
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка чтения: {ex.Message}");
        }
    }

    public void Save(List<Note> notes)
    {
        NoteRules.ValidateCopy(notes);
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(notes, options);
        
        string? dir = Path.GetDirectoryName(_path);
        if (dir != null) Directory.CreateDirectory(dir);
        
        File.WriteAllText(_path, json);
    }
}