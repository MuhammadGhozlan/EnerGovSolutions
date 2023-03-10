using Microsoft.AspNetCore.Mvc;
using S_Squared_Enterprises_Personal_System.Data;
using S_Squared_Enterprises_Personal_System.Models;

namespace S_Squared_Enterprises_Personal_System.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Home Page
        public IActionResult Index()
        {
            

            var ManagersNamesAndIDs = _db.Employees.Where(emp => emp.ManagerID.HasValue)
            //    Select(emp => new
            //{
            //    emp.LastName,
            //    emp.FirstName,
            //    emp.EmployeeID
                
            //})
            .ToList();
            
            return View(ManagersNamesAndIDs);
        }

        /*
         * Create Employee
         */
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if(ModelState.IsValid) {
                _db.Employees.Add(employee);
                _db.SaveChanges();
                TempData["success"] = "Employee has been added successfully";
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        /*
        * Update Employee
        */
        //GET
        public IActionResult Update(int? id)
        {
            if(id == 0) { return NotFound(); }
            var EmployeeFromDatabase = _db.Employees.Find(id);
            if(EmployeeFromDatabase == null)
            {
                return NotFound();
            }
            return View(EmployeeFromDatabase);

        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Update(employee);
                _db.SaveChanges();
                TempData["success"] = "Employee has been Updated successfully";
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        /*
      * Delete Employee
      */
        //GET
        public IActionResult Delete(int id) {
            var EmployeeFromDatabase=_db.Employees.Find(id);
            if(EmployeeFromDatabase == null) { return NotFound(); }
            else
                return View(EmployeeFromDatabase);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee employee)
        {
            
                _db.Employees.Remove(employee);
                _db.SaveChanges();
                TempData["success"] = "Employee has been Deleted successfully";
                return RedirectToAction("Index");

            
            
        }

    }
}
