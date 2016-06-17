using System.Collections.Generic;

namespace NotesExercise03_Peneder.Services
{
    public interface IDataService
    {
        IEnumerable<Note> GetAllNotes();

        void SaveNote(Note note);

        void DeleteNote(Note note);
    }
}