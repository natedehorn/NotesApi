using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotesApi.Controllers;

namespace NotesApiTests
{
    [TestClass]
    public class NotesControllerTest
    {
        private NotesController _controller;
        private string _jsonFile = "testnotes.json";
        private string _json = "{ \"Notes\":[ {\"Id\" : 1, \"Content\": \"My First Note\" },{ \"Id\" : 2, \"Content\": \"My Second Note\" },{ \"Id\" : 3, \"Content\": \"My Third Note\" },{ \"Id\" : 4, \"Content\": \"My Fourth Note\" },{ \"Id\" : 5, \"Content\": \"My Fifth Note\" }]}";

        [TestInitialize]
        public void Init(){
            System.IO.File.WriteAllText(_jsonFile, _json);
            _controller = new NotesController(_jsonFile);
        }

        [TestMethod]
        public void GetNotes_Should_ReturnAllNotes()
        {
            var result = _controller.GetNotes();
            Assert.IsTrue(result.Count >= 5);
        }

        [TestMethod]
        public void GetNote_Should_ReturnSpecificNote()
        {
            var result = _controller.GetNotes(4);
            Assert.AreEqual(result.Content, "My Fourth Note");
        }

        [TestMethod]
        public void CreateNote_Should_AddNewNote()
        {
            var id = _controller.CreateNote("A new note");
            var result = _controller.GetNotes(id);
            Assert.AreEqual(result.Content, "A new note");
        }

        [TestMethod]
        public void EditNote_Should_UpdateNote()
        {
            var id = _controller.EditNote(5, "Edited Note");
            var result = _controller.GetNotes(id);
            Assert.AreEqual(result.Content, "Edited Note");
        }

        [TestMethod]
        public void DeleteNote_Should_RemoveNote()
        {
            var count = _controller.GetNotes().Count;
            _controller.DeleteNote(1);
            Assert.AreEqual(count - 1, _controller.GetNotes().Count);
        }
    }
}
