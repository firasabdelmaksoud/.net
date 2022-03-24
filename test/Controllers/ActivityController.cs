using Sitecore.FakeDb;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class ActivityController : Controller
    {
        // GET: Activity
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("http://localhost:8081");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("SpringMVC/servlet/retrieve-all-Activity").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Activity>>().Result;

            }
            else
            {
                ViewBag.result = "erreur";
            }
            return View();

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(Activity a)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8081");
            Client.PostAsJsonAsync<Activity>("SpringMVC/servlet/add-Activity ", a).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("SpringMVC/servlet/remove-Activity/" +id).Result;
            Activity a = new Activity();
            if (response.IsSuccessStatusCode)
            {

                a = response.Content.ReadAsAsync<Activity>().Result;

            }
            else
            {
                a = null;
            }

            return View(a);
        }
        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:8081");

                // TODO: Add insert logic here
                client.DeleteAsync("SpringMVC/servlet/remove-Activity/" + id).ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);

               return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("SpringMVC/servlet/retrieve-Activity/" + id).Result;
            Activity a = new Activity();
            if (response.IsSuccessStatusCode)
            {

                a = response.Content.ReadAsAsync<Activity>().Result;

            }
            else
            {
                ViewBag.project = "erreur";
            }

            return View(a);
        }


        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            Activity a = new Activity();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //houni essta3mlt service GetProjectById 
            HttpResponseMessage response = client.GetAsync("SpringMVC/servlet/retrieve-Activity/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                a = response.Content.ReadAsAsync<Activity>().Result;
                UpdateModel(a, collection);

                // TODO: Add insert logic here

                HttpClient client2 = new HttpClient();
                client2.BaseAddress = new Uri("http://localhost:8081");
                client2.PutAsJsonAsync<Activity>("SpringMVC/servlet/modify-Activity/"+id, a).ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
    }
}
