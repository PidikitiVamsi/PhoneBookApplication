using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using PhoneBookApplication.Models;
using PBAEntity;

namespace PhoneBookApplication.Controllers
{
    public class PhoneBookController : Controller
    {
        // GET: PhoneBook        
        public ActionResult PhoneBook()
        {
            return View();
        }

        public ActionResult Index()
        {
            Uri uri = new Uri("http://localhost:51598/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.GetStringAsync("PhoneBookapi/GetCategories").Result;
                var lstcat = JsonConvert.DeserializeObject<List<CategoryBook>>(result);
               
               
                return View(lstcat);

            }
            
        }
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(CategoryBook c)
        {
            Uri uri = new Uri("http://localhost:51598/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.PostAsJsonAsync("PhoneBookapi/",c).Result;
               // var lstcat = JsonConvert.DeserializeObject<List<CategoryMVC>>(result);
                if(result.IsSuccessStatusCode == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData.Add("msg", "Record is not inserted some error is getting");
                }
                return View();

            }

        }
        [HttpGet]
        public ActionResult contactdetails(int id)
        {
            Uri uri = new Uri("http://localhost:51598/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.GetStringAsync("PhoneBookapi/GetContactById/" + id).Result;
                var condet = JsonConvert.DeserializeObject<List<ContactBook>>(result);


                return View(condet);

            }

        }
        public ActionResult AllContacts(int id)
        {
            Uri uri = new Uri("http://localhost:51598/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.GetStringAsync("PhoneBookapi/").Result;
                var lstcat = JsonConvert.DeserializeObject<List<ContactBook>>(result);


                return View(lstcat);

            }

        }
        [HttpGet]
        public ActionResult Create()
        {
            //ContactBook c = new ContactBook();
            return View();
        }
        [HttpPost]
        public ActionResult Create(ContactBook c)
        {
            Uri uri = new Uri("http://localhost:51598/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.PostAsJsonAsync("PhoneBookapi/AddContact",c).Result;
                // var lstcat = JsonConvert.DeserializeObject<List<CategoryMVC>>(result);
                if (result.IsSuccessStatusCode == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData.Add("msg", "Record is not inserted some error is getting");
                }

                return View("Index");

            }

        }
       /* [HttpPost]
        public ActionResult Create()
        {
            return RedirectToAction("contactdetails");
        }*/
        public ActionResult Delete(int id)
        {
            Uri uri = new Uri("http://localhost:51598/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.DeleteAsync("PhoneBookapi/Delete" + id).Result;
                // var lstcat = JsonConvert.DeserializeObject<List<CategoryMVC>>(result);
                if (result.IsSuccessStatusCode == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData.Add("msg", "Record is Deleted Successfully");
                }

                return View(id);

            }

        }
        public ActionResult Remove(int id)
        {
            Uri uri = new Uri("http://localhost:51598/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.DeleteAsync("PhoneBookapi/DeleteContactById/" + id).Result;
                // var lstcat = JsonConvert.DeserializeObject<List<CategoryMVC>>(result);
                if (result.IsSuccessStatusCode == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData.Add("msg", "Record is Deleted Successfully");
                }

                return View(id);

            }

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Uri uri = new Uri("http://localhost:51598/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.GetStringAsync("PhoneBookapi/").Result;
                var con = JsonConvert.DeserializeObject<List<ContactBook>>(result);


                return View(con);

            }

        }
        [HttpPost]
        public ActionResult Edit(ContactBook con)
        {
            Uri uri = new Uri("http://localhost:51598/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.PutAsJsonAsync("PhoneBookapi/" + con.ContactId,con).Result;
                // var lstcat = JsonConvert.DeserializeObject<List<CategoryMVC>>(result);
                if (result.IsSuccessStatusCode == true)
                {
                    return RedirectToAction("Index");
                    ViewData.Add("msg", "Record Not Updated Successfully");
                }
                else
                {
                    ViewData.Add("msg", "Record Not Updated Successfully");
                }

                return View();

            }

        }

    }
}