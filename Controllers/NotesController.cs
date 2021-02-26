using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Linq;

namespace NotesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private NoteCollection _notes;
        private string _jsonFile;
        public NotesController(string jsonFile = "notes.json")
        {
            _jsonFile = jsonFile;
            if(System.IO.File.Exists(_jsonFile)){
                var json = System.IO.File.ReadAllText(_jsonFile);
                _notes = JsonSerializer.Deserialize<NoteCollection>(json);
            }
        }

        [HttpGet]
        public IList<Note> GetNotes()
        {
            return _notes.Notes;
        }

        [HttpGet("{id}")]
        public Note GetNotes(int id) => _notes.Notes.Where(note => note.Id == id).FirstOrDefault();

        [HttpPost]
        public int CreateNote([FromBody] string content){
            var id = _notes.Notes.Count + 1;
            _notes.Notes.Add(new Note(id, content));
            UpdateFile();
            return id;
        }

        [HttpPut("{id}")]
        public int EditNote(int id, [FromBody] string content){
            _notes.Notes.Where(note => note.Id == id).FirstOrDefault().Content = content;
            UpdateFile();
            return id;
        }

        [HttpDelete("{id}")]
        public void DeleteNote(int id){
            _notes.Notes.RemoveAll(note => note.Id == id);
            UpdateFile();
        }

        private void UpdateFile() => System.IO.File.WriteAllText(_jsonFile, JsonSerializer.Serialize<NoteCollection>(_notes));
    }
}
