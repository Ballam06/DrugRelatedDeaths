using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using DrugRelatedDeaths.Models;
using System.Collections;
using Newtonsoft.Json.Linq;
using Formatting = Newtonsoft.Json.Formatting;
using System.Net;
using System.IO;

namespace DrugRelatedDeaths.API
{



    public class APIHandler
    {



            static string BASE_URL = "http://api.louisvilleky.gov/";

        
        HttpClient httpClient;

            public APIHandler()
            {
                httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Clear();
               
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }


            public List<MainObject.Drug_Info> GetObject()
            {
                string RESTO_CHART_PATH = "https://data.ct.gov/resource/deaths.json";

                string foodChart = "";

            List<MainObject.Drug_Info> mainObject = null;
            

                httpClient.BaseAddress = new Uri(RESTO_CHART_PATH);

                // It can take a few requests to get back a prompt response, if the API has not received
                //  calls in the recent past and the server has put the service on hibernation
                try
                {
                    HttpResponseMessage response = httpClient.GetAsync(RESTO_CHART_PATH).GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        foodChart = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    }

                    if (!foodChart.Equals(""))
                    {
                    

                    mainObject = JsonConvert.DeserializeObject<JArray>(foodChart).ToObject<List<MainObject.Drug_Info>>();
                    // mainObject =  collection.Cast<MainObject>().ToList();


                }
            
                }
                catch (Exception e)
                {
                    // This is a useful place to insert a breakpoint and observe the error message
                    Console.WriteLine(e.Message);
                }




                return mainObject;
            }
        public List<Drug> GetObject1()
        {
            string RESTO_CHART_PATH = "https://data.ct.gov/resource/deaths.json";

            string foodChart = "";

            List<Drug> mainObject1 = null;


            httpClient.BaseAddress = new Uri(RESTO_CHART_PATH);

            // It can take a few requests to get back a prompt response, if the API has not received
            //  calls in the recent past and the server has put the service on hibernation
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(RESTO_CHART_PATH).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    foodChart = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                if (!foodChart.Equals(""))
                {


                    mainObject1 = JsonConvert.DeserializeObject<JArray>(foodChart).ToObject<List<Drug>>();
                    // mainObject =  collection.Cast<MainObject>().ToList();


                }

            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message
                Console.WriteLine(e.Message);
            }




            return mainObject1;
        }
    }
    }

