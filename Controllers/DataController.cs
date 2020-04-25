using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using FindYourRestaurant.DataAccess;
using FindYourRestaurant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace FindYourRestaurant.Controllers
{
    public class DataController : Controller
    {
        public ActionResult Index()
        {
            SearchModel search = new SearchModel();
            search.DrugDetails = PopulateDrugDetails();
            return View(search);
        }

        [HttpPost]
        public ActionResult Index(SearchModel search)
        {
            search.DrugDetails = PopulateDrugDetails();
            if (search.DrugIds != null)
            {
                List<SelectListItem> selectedItems = search.DrugDetails.Where(p => search.DrugIds.Contains(int.Parse(p.Value))).ToList();

                ViewBag.Message = "Selected Drugs:";
                foreach (var selectedItem in selectedItems)
                {
                    selectedItem.Selected = true;
                    ViewBag.Message += "\\n" + selectedItem.Text;
                }
            }

            return View(search);
        }

        private static List<SelectListItem> PopulateDrugDetails()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string constr = ConfigurationManager.ConnectionStrings["Data Source=DESKTOP-BMVVDK6\\SQLEXPRESS;Initial Catalog=Example;Integrated Security=True"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = " SELECT ";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new SelectListItem
                            {
                                Text = sdr["ID"].ToString(),
                                Value = sdr["ID","Sex"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }

            return items;
        }
    }
}