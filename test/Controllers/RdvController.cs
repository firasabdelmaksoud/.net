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
    public class RdvController : Controller
    {
        // GET: Rdv
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("http://localhost:8081");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("SpringMVC/servlet/retrieve-all-Rdv").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Rdv>>().Result;

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
        public ActionResult Create(Rdv rd)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8081");
            Client.PostAsJsonAsync<Rdv>("SpringMVC/servlet/add-Rdv ", rd).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("SpringMVC/servlet/remove-Rdv/" + id).Result;
            Rdv r = new Rdv();
            if (response.IsSuccessStatusCode)
            {

                r = response.Content.ReadAsAsync<Rdv>().Result;

            }
            else
            {
                r = null;
            }

            return View(r);
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
                client.DeleteAsync("SpringMVC/servlet/remove-Rdv/" + id)
                       .ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);

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
            HttpResponseMessage response = client.GetAsync("SpringMVC/servlet/retrieve-Rdv/" + id).Result;
            Rdv ra = new Rdv();
            if (response.IsSuccessStatusCode)
            {

                ra = response.Content.ReadAsAsync<Rdv>().Result;

            }
            else
            {
                ViewBag.project = "erreur";
            }

            return View(ra);
        }


        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            Rdv ra = new Rdv();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //houni essta3mlt service GetProjectById 
            HttpResponseMessage response = client.GetAsync("SpringMVC/servlet/retrieve-Rdv/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                ra = response.Content.ReadAsAsync<Rdv>().Result;
                UpdateModel(ra, collection);

                // TODO: Add insert logic here

                HttpClient client2 = new HttpClient();
                client2.BaseAddress = new Uri("http://localhost:8081");
                client2.PutAsJsonAsync<Rdv>("SpringMVC/servlet/modify-Rdv/" + id, ra).ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

    }
}