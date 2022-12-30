using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Note_Taking_App.DAL;
using Note_Taking_App.Models;

namespace Note_Taking_App.Controllers
{
    public class NotesController : Controller
    {
        private readonly AppDbContext _db;

        public NotesController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {

            List<Note> notes = await _db.Notes.Where(x => x.IsDeactive == false).ToListAsync();
            return View(notes);
        }


        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Note note)
        {

            if (note.Title == null)
            {
                ModelState.AddModelError("Title", "Title must be");
                return View(note);
            }
            

            bool isExists = await _db.Notes.Where(x => x.IsDeactive == false).AnyAsync(x => x.Title == note.Title);

            if (isExists)
            {
                ModelState.AddModelError("Title", "There is already note under this title. Please change the title");
                return View(note);
            }


            


            note.CreatedDate = DateTime.Now;


           


            await _db.AddAsync(note);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Note? note = await _db.Notes.FirstOrDefaultAsync(x => x.Id == id);
            if (note == null)
            {
                return BadRequest();
            }

         

            return View(note);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(Note note, int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Note? dBNote = await _db.Notes.FirstOrDefaultAsync(x => x.Id == id);
            if (dBNote == null)
            {
                return BadRequest();
            }

            if (note.Title == null)
            {
                ModelState.AddModelError("Title", "Title must be");
                return View(note);
            }

            


            bool isExists = await _db.Notes.Where(x => x.IsDeactive == false).AnyAsync(x => x.Title == note.Title && x.Id != id);

            if (isExists)
            {
                ModelState.AddModelError("Title", "There is already note under this title. Please change the title");
                return View(note);
            }
            




            dBNote.Title = note.Title;
            dBNote.Description = note.Description;
            
            


            await _db.SaveChangesAsync();



            return RedirectToAction("Index");
        }



        public async Task<IActionResult> Detail(int id)
        {


            if (id == 0)
            {
                return NotFound();
            }


            Note? note = await _db.Notes.FirstOrDefaultAsync(x => x.Id == id);


            if (note == null)
            {
                return BadRequest();
            }



            return View(note);

        }




        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }


            Note? note = await _db.Notes.FirstOrDefaultAsync(x => x.Id == id);


            if (note == null)
            {
                return BadRequest();
            }




            note.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }



        public async Task<IActionResult> Search(string key)
        {

            List<Note> notes = await _db.Notes.Where(x => x.Title.Contains(key)).ToListAsync();
            return PartialView("_GlobalSearchPartial", notes);
        }




       


    }
}
