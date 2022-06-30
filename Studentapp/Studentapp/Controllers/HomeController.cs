using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student.Models;
using StudentappDB.DBoperations;
namespace Studentapp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        StudentRepository repository = null;

        public  HomeController()
        {
            repository = new StudentRepository();                
        }
        public ActionResult Index()
        {
            return RedirectToAction("GetAllStudents");
        }

        public ActionResult Create()
        {
           
            return View();
        }

        public ActionResult DataAdded()
        {
            return View();
        }

        [HttpPost]
         public ActionResult Create(StudentDataModel model)
        {
            if (ModelState.IsValid)
            {
                int id = repository.AddStudent(model);
                if (id > 0)
                {
                    ModelState.Clear();
                   // ViewBag.Issucces = "Congratulation Your Data Is Added";
                    return RedirectToAction("DataAdded");
                }
            }
            return View();
        }

        public ActionResult GetAllStudents()
        {
            var result = repository.GetAllStudents();
            return View(result);
        }

        public ActionResult HostelName(int id)
        {
            var StudentData = repository.GetStudent(id);
            return View(StudentData);
        }
        
        public ActionResult Edit(int id)
        {
            var StudentData = repository.GetStudent(id);
            return View(StudentData);
        }

        [HttpPost]
        public ActionResult Edit(StudentDataModel model)
        {
            if(ModelState.IsValid)
            {
                repository.UpdateStudent(model.ID, model);

                return RedirectToAction("GetAllStudents");
            }
            
            return View();
        }

  
        public ActionResult Delete(int id)
        {
                repository.DeleteStudent(id);

                return RedirectToAction("GetAllStudents");
          
        }
    }
}