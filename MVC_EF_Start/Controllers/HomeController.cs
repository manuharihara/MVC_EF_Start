using MVC_EF_Start.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Start.DataAccess;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;

namespace MVC_EF_Start.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult feedback()
        {
            return View();
        }


        public IActionResult favorites()
        {
            return View();
        }

        public IActionResult nutrition()
        {
            return View();
        }
        public IActionResult contact()
        {
            return View();
        }

        public IActionResult Order()
        {

            Orders c = new Orders();
            c.OrderID = "OrderID";
            c.CustomerName = "CustomerName";
            c.OrderCategory = "OrderCategory";
            c.MealID = "MealID";
            c.Quantity = "Quantity";
            c.Messege = "Messege";

            return View(c);
        }


       
        private HttpClient httpClient;

         static string BASE_URL = "https://developer.nps.gov/api/v1/";
         static string API_KEY = "mdBybOievMdeX3eYSC0MhFu3U7xRV18xHAPG04qb"; //Add your API key here inside ""

        public IActionResult Parksinfo()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            string NATIONAL_PARK_API_PATH = BASE_URL + "/parks?limit=20";
            string parksData = "";

            Parks parks = null;

            httpClient.BaseAddress = new Uri(NATIONAL_PARK_API_PATH);

            try
            {
                HttpResponseMessage response = httpClient.GetAsync(NATIONAL_PARK_API_PATH).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    parksData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                if (!parksData.Equals(""))
                {
                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                    parks = JsonConvert.DeserializeObject<Parks>(parksData);
                }
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message
                Console.WriteLine(e.Message);
            }

            return View(parks);
        }

        /*
        // static string FOOD_BASE_URL = "https://api.nal.usda.gov/fdc/v1/";
        // static string FOOD_API_KEY = "KvuO3v0mGg9NTGtkJg9E0NFrQhrQSton1UFh5Iv7"; //Add your API key here inside ""



        [HttpPost]
                public ActionResult OrderConfirm(Orders model)
                {

                    StringBuilder Order = new StringBuilder();
                    Order.Append("<b>Number :</b> " + model.OrderID + "<br/>");
                    Order.Append("<b>Name :</b> " + model.CustomerName + "<br/>");
                    Order.Append("<b>OrderCategory :</b> " + model.OrderCategory + "<br/>");
                    Order.Append("<b>MealID :</b> " + model.MealID);
                    Order.Append("<b>Quantity :</b> " + model.Quantity + "<br/>");
                    Order.Append("<b>Messege :</b> " + model.Messege + "<br/>");

                    return Content(Order.ToString());
                }




                /*
                        [HttpPost]
                        public IActionResult Contact(GuestContact contact)
                        {
                            return View(contact);
                        }

                        public ApplicationDbContext dbContext;
                        private object spExecuter;

                        public HomeController(ApplicationDbContext context)
                        {
                            dbContext = context;
                        }


                        [HttpPost]
                        public void Post([FromBody] Orders order)
                        {
                            // adding user to database using spExecuter library
                            this.spExecuter.ExecuteSpNonQuery(
                                 "CreateOrder",
                                 new[]
                                 {
                                    new KeyValuePair<string,object>("TableId",order.TableID),
                                    new KeyValuePair<string, object>("Restaurant",order.RestaurantName),
                                    new KeyValuePair<string, object>("OrderCategory",order.OrderCategory),
                                    new KeyValuePair<string, object>("MealId",order.MealID),
                                    new KeyValuePair<string, object>("Quantity",order.Quantity),
                                    new KeyValuePair<string, object>("Messege",order.Messege)
                                 });
                        }


                        public ActionResult Order(Order Order)
                        {
                            string constr = ConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
                            using (SqlConnection con = new SqlConnection(constr))
                            {
                                string query = "INSERT INTO Customers(Name, Country) VALUES(@Name, @Country)";
                                query += " SELECT SCOPE_IDENTITY()";
                                using (SqlCommand cmd = new SqlCommand(query))
                                {
                                    cmd.Connection = con;
                                    con.Open();
                                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                                    cmd.Parameters.AddWithValue("@Country", customer.Country);
                                    customer.CustomerId = Convert.ToInt32(cmd.ExecuteScalar());
                                    con.Close();
                                }
                            }

                            return View(customer);
                        }

                [HttpPost]
        public IActionResult Order(FormCollection frm)
        {
            Orders c = new Orders();
            c.OrderID = frm["OrderID"];
            c.CustomerName = frm["CustomerName"];
            c.OrderCategory = frm["OrderCategory"];
            c.MealID = frm["MealID"];
            c.Quantity = frm["Quantity"];
            c.Messege = frm["Messege"];


            return View(c);

        }
                        public IActionResult nutrition()
                        {
                            httpClient = new HttpClient();
                            httpClient.DefaultRequestHeaders.Accept.Clear();
                            httpClient.DefaultRequestHeaders.Add("X-Api-Key", FOOD_API_KEY);
                            httpClient.DefaultRequestHeaders.Accept.Add(
                                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                            string FDA_API_PATH = FOOD_BASE_URL + "/foods/list";
                            string FoodNutrientdata = "";

                            FoodNutrients FoodNutrients = null;

                            httpClient.BaseAddress = new Uri(FDA_API_PATH);

                            try
                            {
                                HttpResponseMessage response = httpClient.GetAsync(FDA_API_PATH).GetAwaiter().GetResult();

                                if (response.IsSuccessStatusCode)
                                {
                                    FoodNutrientdata = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                                }

                                if (!FoodNutrientdata.Equals(""))
                                {
                                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                                    FoodNutrients = JsonConvert.DeserializeObject<FoodNutrients>(FoodNutrientdata);
                                }
                            }
                            catch (Exception e)
                            {
                                // This is a useful place to insert a breakpoint and observe the error message
                                Console.WriteLine(e.Message);
                            }

                            return View(FoodNutrients);

                        }

                        // Obtaining the API key is easy. The same key should be usable across the entire
                        // data.gov developer network, i.e. all data sources on data.gov.
                        // https://www.nps.gov/subjects/developer/get-started.htm

                        public IActionResult Parksinfo()
                        {
                            httpClient = new HttpClient();
                            httpClient.DefaultRequestHeaders.Accept.Clear();
                            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
                            httpClient.DefaultRequestHeaders.Accept.Add(
                                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                            string NATIONAL_PARK_API_PATH = BASE_URL + "/parks?limit=20";
                            string parksData = "";

                            Parks parks = null;

                            httpClient.BaseAddress = new Uri(NATIONAL_PARK_API_PATH);

                            try
                            {
                                HttpResponseMessage response = httpClient.GetAsync(NATIONAL_PARK_API_PATH).GetAwaiter().GetResult();

                                if (response.IsSuccessStatusCode)
                                {
                                    parksData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                                }

                                if (!parksData.Equals(""))
                                {
                                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                                    parks = JsonConvert.DeserializeObject<Parks>(parksData);
                                }
                            }
                            catch (Exception e)
                            {
                                // This is a useful place to insert a breakpoint and observe the error message
                                Console.WriteLine(e.Message);
                            }

                            return View(parks);
                        }

                        public IActionResult Index_ParkNewsrelease()
                        {
                            httpClient = new HttpClient();
                            httpClient.DefaultRequestHeaders.Accept.Clear();
                            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
                            httpClient.DefaultRequestHeaders.Accept.Add(
                                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                            string NATIONAL_PARK_API_PATH = BASE_URL + "/parks?limit=20";
                            string parksData = "";

                            Parks parks = null;

                            httpClient.BaseAddress = new Uri(NATIONAL_PARK_API_PATH);

                            try
                            {
                                HttpResponseMessage response = httpClient.GetAsync(NATIONAL_PARK_API_PATH).GetAwaiter().GetResult();

                                if (response.IsSuccessStatusCode)
                                {
                                    parksData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                                }

                                if (!parksData.Equals(""))
                                {
                                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                                    parks = JsonConvert.DeserializeObject<Parks>(parksData);
                                }
                            }
                            catch (Exception e)
                            {
                                // This is a useful place to insert a breakpoint and observe the error message
                                Console.WriteLine(e.Message);
                            }

                            return View(parks);
                        }
                        */


    }
}