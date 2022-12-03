using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Note_Taking_App.DAL;
using Note_Taking_App.Models;

namespace Note_Taking_App.Controllers
{
    public class NoteController : Controller
    {
        private readonly AppDbContext _db;

        public NoteController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {

            List<Note> notes = await _db.Notes.ToListAsync();
            return View(notes);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult>Create(Note note)
        {

            
            bool isExists = await _db.Notes.AnyAsync(x => x.Title == note.Title);

            if (isExists)
            {
                ModelState.AddModelError("Title", "There is already note under this title. Please change the title");
                return View(note);  

            }

            note.IsInProgress = true;
            note.IsCompleted = false;
            await _db.Notes.AddAsync(note);
            await _db.SaveChangesAsync();


            return RedirectToAction("Index");
        }



    }
}
