using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;
using VMSApp.Models;

namespace VMSApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public IActionResult Signup(Employee emp1)
        {
            List<Employee> allemp = EmpDbManager.GetAllEmp();
            for(int i = 0; i < allemp.Count; i++)
            {
              Employee emp = allemp[i]; 
                if(emp1.Empno == emp.Empno)
                {
                    return RedirectToAction("Login", "Home");
                }
               
            }

            EmpDbManager.SaveNewEmp(emp1);

            return View();


        }




        
        public IActionResult Login(Employee emp1)
        {
            
            int empno = emp1.Empno;
            string password = emp1.Password;

            List<Employee> allemp = EmpDbManager.GetAllEmp();

            for (int i = 0; i < allemp.Count; i++)
            {
                Employee emp = allemp[i];
                if (emp.Empno == empno && emp.Password.Equals(password))
                {
                    ViewData["emp"] = emp;
                    if (emp.Role.Equals("admin"))
                    {
                        return RedirectToAction("Index" , "Admin");

                    }
                    else
                    {
                        if (emp.Role.Equals("superadmin"))
                        {
                            return RedirectToAction("Index", "Superadmin");
                        }
                        else
                        {
                            if (emp.Role.Equals("sequerity"))

                            {
                                return RedirectToAction("Index", "Sequerity");
                            }
                        }

                    }
                }

            }


            return View();

        }



    }
}