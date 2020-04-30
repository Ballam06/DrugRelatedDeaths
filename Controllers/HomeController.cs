using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DrugRelatedDeaths.Models;
using DrugRelatedDeaths.API;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using DrugRelatedDeaths.DataAccess;
using Microsoft.Extensions.Options;


namespace DrugRelatedDeaths.Controllers
{
    public class HomeController : Controller
    {
        
        public ApplicationDbContext dbContext;
        private readonly AppSettings _appSettings;
        public HomeController(ApplicationDbContext context, IOptions<AppSettings> appSettings)
        {
            dbContext = context;
            _appSettings = appSettings.Value;
        }
       
        private readonly ILogger<HomeController> _logger;

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Refresh()
        {

           
            APIHandler webHandler = new APIHandler();
            List<Drug> Drug1 = webHandler.GetObject1();

            APIHandler webHandler1 = new APIHandler();
            List<MainObject.Drug_Info> mainObj = webHandler1.GetObject();


            dbContext.MainObject.RemoveRange(dbContext.MainObject);
           
            dbContext.Drug.RemoveRange(dbContext.Drug);
            dbContext.SaveChanges();

             // ClearTables(Drugs);
            foreach (Drug item in Drug1)
            {   
               
                
                dbContext.Drug.Add(item);
            }
            //dbContext.SaveChanges();
            foreach ( MainObject.Drug_Info item in mainObj)
            {
                Console.WriteLine(item);
                dbContext.MainObject.Add(item);
            }
            dbContext.SaveChanges();
            var l1= new List<ReportViewModel>();
           var l2= new List<MainObject.Drug_Info>();
            int x = 0;
            foreach (MainObject.Drug_Info item1 in mainObj)
            {
                if (x < 20)
                {
                    l2.Add(item1);
                }
                else
                {
                    break;
                }
                x = x + 1;
            }


            return View(l2);
        }
      
        public IActionResult Index1()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index1(MainObject.Drug_Info uc)
        {
            if (uc.ID == null)
            {
                ViewBag.message = "Please enter Id";
            }
            else
            {
                

                dbContext.MainObject.Add(uc);
                dbContext.SaveChanges();
                ViewBag.message = "The User" + uc.ID + "saved";
            }
            return View();

            
        }
        [Route("delete")]
        [HttpGet]
        public IActionResult Delete()
        {
            return View("Delete");
        }

        [Route("delete")]
        [HttpPost]
        public IActionResult Delete(string id)
        {
            
            if (id==null)
            {
                ViewBag.message = "Please enter id";
            }
            else
            {
                try
                {
                    dbContext.MainObject.Remove(dbContext.MainObject.Find(id));

                    dbContext.SaveChanges();
                    ViewBag.message = "The User" + id + "Deleted";
                }
                catch
                {
                    ViewBag.message = "No Matching ID Found";
                }

            }
            return View();
        }

        public IActionResult About()


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
       
    } }
        
    
