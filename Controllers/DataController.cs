using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office.CustomUI;
using DrugRelatedDeaths.API;
using DrugRelatedDeaths.DataAccess;
using DrugRelatedDeaths.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace DrugRelatedDeaths.Controllers
{
   
    public class DataController : Controller
    {
        public ApplicationDbContext dbContext;
       
        private readonly AppSettings _appSettings;
        public DataController(ApplicationDbContext context, IOptions<AppSettings> appSettings)
        {
            dbContext = context;
            _appSettings = appSettings.Value;
        }
        [HttpGet]
        public ActionResult Index(string Search_Data, string Drug_type)
        {
            var DrugList = new List<string>();
            var DrugQuery = from t1 in dbContext.MainObject
                             select t1.DescriptionofInjury;
            DrugList.AddRange(DrugQuery.Distinct());
                            




            ViewBag.Drug_type = new SelectList(DrugList);

            IList<MainObject.Drug_Info> drug_Infos = new List<MainObject.Drug_Info>();
            var emp = from q in dbContext.MainObject
                      select q;

            if (!String.IsNullOrEmpty(Search_Data))
            {
                emp = emp.Where(s => s.ResidenceCity.Contains(Search_Data));
            }

            if (!String.IsNullOrEmpty(Drug_type))
            {
                emp = emp.Where(s => s.DescriptionofInjury == Drug_type);
            }

            var myDrugList = emp.ToList();

            foreach (var empData in myDrugList)
            {
                drug_Infos.Add(new MainObject.Drug_Info()
                {
                    ID = empData.ID,
                    Sex = empData.Sex,
                    ResidenceCity = empData.ResidenceCity,
                    ResidenceCounty = empData.ResidenceCounty,
                    Race = empData.Race,
                    DescriptionofInjury = empData.DescriptionofInjury,
                    Date = empData.Date,
                    Age = empData.Age
                });
            }
            return View(drug_Infos);
        }
    


public IActionResult Bar()
        {
            int x = 0;
            int y = 0;
            int z = 0;
            int a = 0;
            int b = 0;
            int c = 0;
            APIHandler webHandler = new APIHandler();
            List<Drug> Drug1 = webHandler.GetObject1();
            foreach(Drug item in Drug1)
            { 
                if (item.Cocaine == "Y")
                {
                    x = x + 1;
                }
                if (item.Ethanol == "Y")
                {
                    y = y + 1;
                }
                if (item.Amphet == "Y")
                {
                    z = z + 1;
                }
                if (item.FentanylAnalogue == "Y")
                {
                    a = a + 1; 
                }
                if (item.Fentanyl == "Y")
                {
                    b = b + 1;
                }

                if (item.Tramad == "Y")
                {
                    c = c + 1;
                }
            }
            var lstmodel = new List<ReportViewModel>();
            lstmodel.Add(new ReportViewModel { DimensionOne = "Cocaine", Quantity = x });


            lstmodel.Add(new ReportViewModel { DimensionOne = "Ethanol", Quantity = y });
            lstmodel.Add(new ReportViewModel { DimensionOne = "Amphet", Quantity = z });
            lstmodel.Add(new ReportViewModel { DimensionOne = "Fentanyl", Quantity = b });
            lstmodel.Add(new ReportViewModel { DimensionOne = "Tramad", Quantity = c });
            lstmodel.Add(new ReportViewModel { DimensionOne = "FentanylAnalogue", Quantity = a });
            return View(lstmodel);
        }
            }

            
        }
    
