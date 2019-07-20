using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMVCApp.BLL.BLL;
using MyMVCApp.Models.Models;

namespace MyMVCApp.Controllers
{
    public class StudentController : Controller
    {
        StudentManager _studentManager =new StudentManager();
        private Student _student = new Student();
        
        // GET: Student
        public ActionResult Add()
        {
            _student.ID = 101;
            _student.Name = "Ali";
            _studentManager.Add(_student);

            return View();
        }
        public ActionResult Delete()
        {
            _student.ID = 5;
            
            _studentManager.Delete(_student);

            return View();
        }
        public ActionResult Update()
        {
            _student.ID = 5;
            Student aStudent = _studentManager.GetByID(_student);
            if (aStudent != null)
            {
                aStudent.Name = "Azad";
                _studentManager.Update(aStudent);
            }

            return View();

            
        }

        public ActionResult GetByID()
        {
           // _student.ID = 2;

            _studentManager.GetByID(_student);

            return View();
        }
        public ActionResult GetAll()
        {


            List<Student> bStudent = _studentManager.GetAll();

            return View();
        }
    }
}