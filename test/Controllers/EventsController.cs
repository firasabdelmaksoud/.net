using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace wassim.Controllers
{
    public class EventsController : Controller
    {

        // GET: Events
        public ActionResult Index()
        {

            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("http://localhost:8081");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("SpringMVC/servlet/retrieve-all-Events").Result;
            if (response.IsSuccessStatusCode)
            {
                //ViewBag.Model = response.Content.ReadAsAsync<IEnumerable<Events>>().Result;
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Events>>().Result;

            }
            else
            {
                ViewBag.result = "erreur";
            }
            return View(ViewBag.result);

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(Events a)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8081");
            Client.PostAsJsonAsync<Events>("SpringMVC/servlet/add-Events", a).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");
        }
        //[HttpPost]
        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var events = new Events();

            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("http://localhost:8081");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("SpringMVC/servlet/retrieve-Events/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                events = (Events)response.Content.ReadAsAsync<Events>().Result;
            }
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }


        // POST: Events/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var events = new Events();

            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("http://localhost:8081");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("SpringMVC/servlet/retrieve-Events/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                events = (Events)response.Content.ReadAsAsync<Events>().Result;
            }
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
           
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("SpringMVC/servlet/retrieve-Events/" + id).Result;
            Events evt = new Events();
            if (response.IsSuccessStatusCode)
            {

                evt = response.Content.ReadAsAsync<Events>().Result;

            }
            else
            {
                ViewBag.project = "erreur";
            }

            return View(evt);
        }


        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id)
        {

            Events evt = new Events();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //houni essta3mlt service GetProjectById 
            HttpResponseMessage response = client.GetAsync("SpringMVC/servlet/retrieve-Events/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
               evt = response.Content.ReadAsAsync<Events>().Result;
                UpdateModel(evt, collection);

                // TODO: Add insert logic here

                HttpClient client2 = new HttpClient();
                client2.BaseAddress = new Uri("http://localhost:8081");
                client2.PutAsJsonAsync<Events>("SpringMVC/servlet/modify-Events/" + id, evt).ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
        // GET: Events/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("SpringMVC/servlet/remove-Events/" + id).Result;
            Events a = new Events();
            if (response.IsSuccessStatusCode)
            {

                a = response.Content.ReadAsAsync<Events>().Result;

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
                client.DeleteAsync("SpringMVC/servlet/remove-Events/" + id).ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }


        public ActionResult Recherche(Events evt)
        {

            var events = new List<Events>();

            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("http://localhost:8081");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("SpringMVC/servlet/retrieve-all-Events").Result;
            if (response.IsSuccessStatusCode)
            {
                events = (List<Events>)response.Content.ReadAsAsync<IEnumerable<Events>>().Result;
                if (!string.IsNullOrEmpty(evt.name))
                {
                    events = events.Where(s => s.name.Contains(evt.name)).ToList();
                }
                return View(events);
            }


            else
            {
                return RedirectToAction("Index");
            }

        }
        // GET: Events/Details/5
        public ActionResult Mailing(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var events = new Events();

            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("http://localhost:8081");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("SpringMVC/servlet/retrieve-Events/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                events = (Events)response.Content.ReadAsAsync<Events>().Result;             
            }
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }
        //public ActionResult SendMailEvent( int id, string dest)
        //public ActionResult SendMailEvent( int id, string description, string name, string date)
        public ActionResult SendMailEvent(Events events)

        {
            //Events eventt = db.Events.Find(id);
            try
            {
                var mailObject = "";
                var compte_email = string.Empty;


                mailObject = "Event confirmation ";


                var _port = 587;
                var _enableSsl = true;
                var _smtp = "smtp.office365.com";
                //var _emetteur = "Wassim.boussaffa@esprit.tn";
                var _emetteur = "smaknine@iga-tunisie.com";

                var _credentials = new System.Net.NetworkCredential(_emetteur, "Yuh68455");
                string body = "Hi, </br> Your participation in the event have been confirmed </br> Thank you and enjoy the event!";
                //string body = "Hi, </br> Your participation in the " + eventt.name + " event have been confirmed for the date of: " + eventt.date.ToShortDateString() +"</br> Thank you and enjoy the event!";
                if (events.description != null && events.description != string.Empty)
                {


                    using (MailMessage mailMessage = new MailMessage())

                    {

                        mailMessage.From = new MailAddress(_emetteur);

                        mailMessage.Subject = mailObject;

                        mailMessage.Body = body;

                        mailMessage.IsBodyHtml = true;

                        mailMessage.To.Add(new MailAddress(events.description));

                        SmtpClient smtp = new SmtpClient();

                        smtp.Host = _smtp;

                        smtp.EnableSsl = Convert.ToBoolean(Convert.ToInt16(_enableSsl));

                        System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();

                        NetworkCred = _credentials;

                        smtp.Credentials = NetworkCred;

                        smtp.Port = Convert.ToInt32(_port);

                        smtp.Send(mailMessage);
                    }

                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                throw;
            }

        }

    
    }
}
