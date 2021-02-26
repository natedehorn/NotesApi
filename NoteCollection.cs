using System.Collections.Generic;

namespace NotesApi
{
    public class NoteCollection{
        public List<Note> Notes{ get; set; }
    }

    public class Note
    {
        public Note(int Id, string Content)
        {
            this.Id = Id;
            this.Content = Content;
        }

        public int Id{ get; set; }
        public string Content { get; set; }
    }
}
