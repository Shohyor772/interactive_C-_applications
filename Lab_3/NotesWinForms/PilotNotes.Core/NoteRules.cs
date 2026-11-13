namespace PilotNotes.Core;

public static class NoteRules
{
    public static string CleanText(string? text)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentException("Введите текст заметки.");
        return text.Trim();
    }

    public static long NextId(List<Note> notes)
    {
        if (notes == null || notes.Count == 0) return 1;
        return notes.Max(n => n.Id) + 1;
    }

    public static List<Note> Find(List<Note> notes, string query)
    {
        if (string.IsNullOrWhiteSpace(query)) return new List<Note>(notes);
        string q = query.Trim();
        return notes.Where(n => n.Text.Contains(q, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public static List<Note> ValidateCopy(List<Note>? notes)
    {
        if (notes == null) throw new ArgumentException("Список заметок пуст или повреждён.");
        
        var seenIds = new List<long>();
        var result = new List<Note>();

        foreach (var note in notes)
        {
            if (note.Id <= 0) throw new ArgumentException("Id должен быть положительным.");
            if (seenIds.Contains(note.Id)) throw new ArgumentException("Повторяющийся Id.");
            if (string.IsNullOrWhiteSpace(note.Text)) throw new ArgumentException("Текст заметки не может быть пустым.");
            
            seenIds.Add(note.Id);
            result.Add(note);
        }
        return result;
    }
}