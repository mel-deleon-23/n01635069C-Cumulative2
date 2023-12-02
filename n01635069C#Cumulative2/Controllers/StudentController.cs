using n01635069C_Cumulative2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace n01635069C_Cumulative2.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        //GET: /Student/List
        public ActionResult List(string StudentSearchKey = null)
        {
            //pass students information into View
            StudentDataController controller = new StudentDataController();
            IEnumerable<Student> Students = controller.ListStudents(StudentSearchKey);

            return View(Students);
        }


        //GET: /Student/Show
        public ActionResult Show(int id)
        {
            StudentDataController controller = new StudentDataController();
            Student NewStudent = controller.FindStudent(id);

            return View(NewStudent);
        }

        //GET: /Student/New
        public ActionResult New()
        {
            return View();
        }

        //GET: /Student/Ajax_New
        public ActionResult Ajax_New()
        {
            return View();
        }

        //POST: /Student/Create
        [HttpPost]
        public ActionResult Create(int StudentId, string StudentFName, string StudentLName, string StudentNumber)
        {
            Debug.WriteLine("I have accessed the Create Method");
            Debug.WriteLine(StudentId);
            Debug.WriteLine(StudentFName);
            Debug.WriteLine(StudentLName);

            Student NewStudent = new Student();

            NewStudent.studentid = StudentId;
            NewStudent.studentfname = StudentFName;
            NewStudent.studentlname = StudentLName;
            NewStudent.studentnumber = StudentNumber;

            StudentDataController controller = new StudentDataController();
            controller.AddStudent(NewStudent);

            return RedirectToAction("List");
        }

        //POST: /Student/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            StudentDataController controller = new StudentDataController();
            controller.DeleteStudent(id);
            return RedirectToAction("List");
        }

        //GET: /Student/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            StudentDataController controller = new StudentDataController();
            Student NewStudent = controller.FindStudent(id);

            return View(NewStudent);
        }

    }
}