using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PBAEntity;
using PBADataAccessLayer;
using PBABusinessLayer;

namespace PBAWebApi.Controllers
{
    public class PhoneBookapiController : ApiController
    {
        //Get all categories in t= category table
       [Route("api/PhoneBookapi/GetCategories")]
        public List<Category> Get()
        {
            PBABusiness bll = new PBABusiness();
            var lstcat = bll.GetAllCategories();
            return lstcat;
        }
        //Get all the contacts in the existing contact
        [Route("api/PhoneBookapi/GetContacts")]
        public List<Contact> GetContacts()
        {
            PBABusiness bll = new PBABusiness();
            var lstcats = bll.GetAllcontacts();
            return lstcats;
        }
        //Here adding the new category
        public void Post([FromBody]Category cat)
        {
            PBABusiness bll = new PBABusiness();
            bll.AddNewCategory(cat);
        }
        //Get contact by id in the contact basis
        [Route("api/PhoneBookapi/GetContactById/{id}")]
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, "Record Deleted");
            try
            {
                PBABusiness bll = new PBABusiness();
                var lstcat = bll.GetAllContactsByCId(id);
                return res = Request.CreateResponse<List<Contact>>(lstcat);
            }
            catch(Exception ex)
            {
                res = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return res;
        }
        //Adding the new contact in contact class
        [Route("api/PhoneBookapi/AddContact")]
        public HttpResponseMessage PostContact([FromBody]Contact contact)
        {
            HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, "Record Deleted");
            try
            {
                PBABusiness bll = new PBABusiness();
                bll.AddContact(contact);
                
            }
            catch (Exception ex)
            {
                res = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return res;
        }
        //Deleting the category from existing category
       [Route("api/PhoneBookapi/Delete")]
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, "Record Deleted");
            try
            {
                PBABusiness bll = new PBABusiness();
                bll.DeleteCategoryById(id);
                
            }
            catch (Exception ex)
            {
                res = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return res;
        }
        //Deleting contact from existing contact
        [Route("api/PhoneBookapi/DeleteContactById/{id}")]
        public HttpResponseMessage DeleteContactById(int id)
        {
            HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, "Record Deleted");
            try
            {
                PBABusiness bll = new PBABusiness();
                bll.DeleteContactById(id);
                
            }
            catch (Exception ex)
            {
                res = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return res;
        }
        //updating the contact in the existing contact with their id reference
        public HttpResponseMessage Put([FromBody] Contact contact,int id)
        {
            HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, "Records updated");
            try
            {
                PBABusiness bll = new PBABusiness();
                bll.UpdateContactById(contact);
            }
            catch(Exception ex)
            {
                res = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return res;
        }


    }
}
