using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using OnlineCoin.Models;

namespace OnlineCoin.Controllers
{
    public class AccountRolesController : Controller
    {
        private OnlineCoinContext db = new OnlineCoinContext();

        // GET: AccountRoles
        public ActionResult Index()
        {
            return View(db.AccountRoles.ToList());
        }

        // GET: AccountRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountRole accountRole = db.AccountRoles.Find(id);
            if (accountRole == null)
            {
                return HttpNotFound();
            }
            return View(accountRole);
        }

        // GET: AccountRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,CreatedAt,Status")] AccountRole accountRole)
        {
            if (ModelState.IsValid)
            {
                db.AccountRoles.Add(accountRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accountRole);
        }

        // GET: AccountRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountRole accountRole = db.AccountRoles.Find(id);
            if (accountRole == null)
            {
                return HttpNotFound();
            }
            return View(accountRole);
        }

        // POST: AccountRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,CreatedAt,Status")] AccountRole accountRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accountRole);
        }

        // GET: AccountRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountRole accountRole = db.AccountRoles.Find(id);
            if (accountRole == null)
            {
                return HttpNotFound();
            }
            return View(accountRole);
        }

        // POST: AccountRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccountRole accountRole = db.AccountRoles.Find(id);
            db.AccountRoles.Remove(accountRole);
            db.SaveChanges();
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
