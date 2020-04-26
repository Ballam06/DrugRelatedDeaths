using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FindYourRestaurant.Models;

using FindYourRestaurant.API;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Collections;
using DocumentFormat.OpenXml.Office.CustomUI;
using Microsoft.EntityFrameworkCore;
using FindYourRestaurant.DataAccess;
using Microsoft.Extensions.Options;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.CodeAnalysis.Operations;

namespace FindYourRestaurant.Controllers
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
            var l1 = new List<ReportViewModel>();



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
        
    
