using Microsoft.AspNetCore.Mvc;
using BusinessObjects.Models;
using System.Collections.Generic;
using System.Collections;
namespace MVCPractice.Controllers
{
    public class CourseController : Controller
    {
        BusinessAccessLayer.BusinessAccesslayer businessAccessLayer = new BusinessAccessLayer.BusinessAccesslayer();

        public IActionResult Index()
        {
            var list = businessAccessLayer.GetAllCourses();
            if (list.Count() > 0)
            {

                return View(list);
            }
            else
            {
                ViewBag.Msg = "No records";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            businessAccessLayer.AddCourse(course);
            //return View();
            return RedirectToAction("Index");

        }

        public IActionResult Details(int? id)
        {
            if (id != null)
            {

                Course course = businessAccessLayer.GetCourse(id);
                return View(course);
            }
            else
            {
                ViewBag.Msg = "No records";
                return View();
            }
        }

        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID"; return View();
            }
            else
            {
                var course = businessAccessLayer.GetCourse(id);
                if (course == null)
                {
                    ViewBag.msg = "There is no record woth this ID";
                    return View();
                }
                else
                    return View(course);
            }

        }

        [HttpPost]
        public IActionResult Edit(Course course, int id)
        {
            ViewBag.Msg= businessAccessLayer.EditCourse(course, id);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID"; return View();
            }
            else
            {
                var course = businessAccessLayer.GetCourse(id);
                if (course == null)
                {
                    ViewBag.msg = "There is no record woth this ID";
                    return View();
                }
                else
                    return View(course);
            }
        }
        [HttpPost]
        public IActionResult Delete(Course course, int id)
        {
            businessAccessLayer.DeleteCourse(course, id);
            return View();

        }
    }
}
