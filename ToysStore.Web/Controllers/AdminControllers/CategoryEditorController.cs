using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using ToysStore.Web.Models;
using ToysStore.Web.Models.DomainModel;

namespace ToysStore.Web.Controllers.AdminController
{
    public class CategoryEditorController : Controller
    {
        private DataProjectContext db = new DataProjectContext();

        // GET: CategoryEditor
        public async Task<ActionResult> Index()
        {
            return View(await db.Categories.ToListAsync());
        }

        // GET: CategoryEditor/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToyCategory toyCategory = await db.Categories.FindAsync(id);
            if (toyCategory == null)
            {
                return HttpNotFound();
            }
            return View(toyCategory);
        }

        // GET: CategoryEditor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryEditor/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Categories")] ToyCategory toyCategory)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(toyCategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(toyCategory);
        }

        // GET: CategoryEditor/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToyCategory toyCategory = await db.Categories.FindAsync(id);
            if (toyCategory == null)
            {
                return HttpNotFound();
            }
            return View(toyCategory);
        }

        // POST: CategoryEditor/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Categories")] ToyCategory toyCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toyCategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(toyCategory);
        }

        // GET: CategoryEditor/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToyCategory toyCategory = await db.Categories.FindAsync(id);
            if (toyCategory == null)
            {
                return HttpNotFound();
            }
            return View(toyCategory);
        }

        // POST: CategoryEditor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ToyCategory toyCategory = await db.Categories.FindAsync(id);
            db.Categories.Remove(toyCategory);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
