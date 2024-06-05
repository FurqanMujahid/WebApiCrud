using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;
using WebApiCrud.Models;
using static WebApiCrud.Models.AgreementModel;
using System;
using System.Collections.Generic;

namespace WebApiCrud.Controllers
{
    
    public class HomeController : Controller
    {
        FurqanTestDBEntities1 context = new FurqanTestDBEntities1();
        public ActionResult Index()
        {
            var ListOfData = context.Students.ToList();
            return View(ListOfData);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Student());
        }
        [HttpPost]
        public ActionResult Create(Student stu)
        {
            context.Students.Add(stu);
            context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            //  return View(stu);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            return View(data);

        }
        [HttpPost]
        public ActionResult Edit(Student stu)
        {
            //return View(Create);
            var data = context.Students.Where(x => x.StudentId == stu.StudentId).FirstOrDefault();
            if (data != null)
            {
                data.FirstName = stu.FirstName;
                data.LastName = stu.LastName;
                data.Height = stu.Height;
                data.StandardRefId = stu.StandardRefId;
                data.Grade = stu.Grade;
                data.RollNumber = stu.RollNumber;
                context.SaveChanges();
                ViewBag.Message = "Data updated successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var data = context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            var data = context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            context.Students.Remove(data);
            context.SaveChanges();
            ViewBag.ViewBagMessage = "Record Delete Successfully";


            return RedirectToAction("index");
        }
       
    }  
}  
