using dbFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace dbFirst.Controllers
{
    public class EmployeeController : Controller
    {
        //injecting a dependency in controller 
        CrudVContext _db;
        public EmployeeController(CrudVContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
          var e=  _db.Employees.ToList();
            return View(e);
        }

        [HttpGet]
        public IActionResult Create()
        {
          return View();  
        }

        [HttpPost]
        public IActionResult Create(Employee e)
        {
            _db.Employees.Add(e);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
           var r= _db.Employees.Find(id);
            return View(r);
        }

        [HttpPost]
        public IActionResult Edit(Employee o) 
        {
            _db.Employees.Update(o);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult Delete(int id) 
        {
           var e= _db.Employees.Find(id);
            return View(e);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete_c(int id)
        {
           var d= _db.Employees.Find(id);
               _db.Employees.Remove(d);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
           var e= _db.Employees.Find(id);
            return View(e);
        }
    }
}
