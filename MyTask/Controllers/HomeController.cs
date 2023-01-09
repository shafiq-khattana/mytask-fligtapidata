using MyTask.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyTask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult SearchPage()
        {
            return View();
        }

        public async Task<ActionResult> ResultPage()
        {
            string url = @"http://api.mybookingworld.com/api/OneWayTrip?Origin=KHI&Destination=LHE&Departure=2023-01-12&Adults=1&Children=0&Infant=0&ReturnType=json&UserName=intelli&ApiPassword=786786&ClientID=1&DirectOnly=True&ShowAlternateGrid=False";

            HttpClient client = new HttpClient();
            var resp = await client.GetAsync(url);
            if(resp.IsSuccessStatusCode)
            {
                string json = await resp.Content.ReadAsStringAsync();
                DataModel mod = JsonConvert.DeserializeObject<DataModel>(json);
                return View(mod);
            }
            return View();
        }
    }
}