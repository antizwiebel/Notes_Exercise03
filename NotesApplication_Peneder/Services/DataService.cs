using System.Collections.Generic;

namespace NotesExercise03_Peneder.Services
{
    public class DataService : IDataService
    {

        private readonly List<Note> allNotes;

        public DataService()
        {
            allNotes= new List<Note>();
        }

        public IEnumerable<Note> GetAllNotes()
        {
            return allNotes;
        }

        public void DeleteNote(Note note)
        {
            allNotes.Remove(note);
        }

        public void SaveNote(Note note)
        {
            allNotes.Add(note);
        }
    }
}