using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        private string _connectionString = @"Data Source=NOLAN\SQLEXPRESS;Initial Catalog=School;Integrated Security=True;Connect 
                                            Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public ActionResult Index()
        {
            return View();
        }
    }
}