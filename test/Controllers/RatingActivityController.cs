using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class RatingActivityController : Controller
    {
        // GET: RatingActivity
        public ActionResult Index(int id)
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("http://localhost:8081");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("SpringMVC/servlet/retrieve-all-RatingActivityByActivity/"+id).Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<RatingActivity>>().Result;

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
        public ActionResult Create(int id, RatingActivity a)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8081");
            Client.PostAsJsonAsync<RatingActivity>("SpringMVC/servlet/add-RatingActivity/"+id, a).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("SpringMVC/servlet/remove-RatingActivity/"+ id).Result;
            RatingActivity a = new RatingActivity();
            if (response.IsSuccessStatusCode)
            {

                a = response.Content.ReadAsAsync<RatingActivity>().Result;

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
                client.DeleteAsync("SpringMVC/servlet/remove-RatingActivity/" + id).ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);

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
            HttpResponseMessage response = client.GetAsync("SpringMVC/servlet/retrieve-RatingActivity/" + id).Result;
            RatingActivity a = new RatingActivity();
            if (response.IsSuccessStatusCode)
            {

                a = response.Content.ReadAsAsync<RatingActivity>().Result;

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

            RatingActivity a = new RatingActivity();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //houni essta3mlt service GetProjectById 
            HttpResponseMessage response = client.GetAsync("SpringMVC/servlet/retrieve-RatingActivity/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                a = response.Content.ReadAsAsync<RatingActivity>().Result;
                UpdateModel(a, collection);

                // TODO: Add insert logic here

                HttpClient client2 = new HttpClient();
                client2.BaseAddress = new Uri("http://localhost:8081");
                client2.PutAsJsonAsync<RatingActivity>("SpringMVC/servlet/modify-RatingActivity/" + id, a).ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
    }
}