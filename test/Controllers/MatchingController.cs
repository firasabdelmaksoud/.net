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
    public class MatchingController : Controller
    {
        // GET: Matching
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("http://localhost:8081");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("SpringMVC/servlet/retrieve-all-Matching").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Matching>>().Result;

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
        public ActionResult Create(Matching ma)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8081");
            Client.PostAsJsonAsync<Matching>("SpringMVC/servlet/add-Matching ", ma).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("SpringMVC/servlet/remove-Matching/" + id).Result;
            Matching ma = new Matching();
            if (response.IsSuccessStatusCode)
            {

                ma= response.Content.ReadAsAsync<Matching>().Result;

            }
            else
            {
                ma= null;
            }

            return View(ma);
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
                client.DeleteAsync("SpringMVC/servlet/remove-Matching/" + id).ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
        public ActionResult Edit(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("SpringMVC/servlet/retrieve-Matching/" + id).Result;
            Matching ma = new Matching();
            if (response.IsSuccessStatusCode)
            {

                ma = response.Content.ReadAsAsync<Matching>().Result;

            }
            else
            {
                ViewBag.project = "erreur";
            }

            return View(ma);
        }


        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            Matching ma = new Matching();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //houni essta3mlt service GetProjectById 
            HttpResponseMessage response = client.GetAsync("SpringMVC/servlet/retrieve-Matching/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                ma = response.Content.ReadAsAsync<Matching>().Result;
                UpdateModel(ma, collection);

                // TODO: Add insert logic here

                HttpClient client2 = new HttpClient();
                client2.BaseAddress = new Uri("http://localhost:8081");
                client2.PutAsJsonAsync<Matching>("SpringMVC/servlet/Matching/" + id, ma).ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

    }
}