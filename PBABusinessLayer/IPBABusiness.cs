using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBAEntity;

namespace PBABusinessLayer
{
    public interface IPBABusiness
    {
       // List<Contact> GetAllcontacts();
       // void UpdateContactById(Contact contact);
        void AddContact(Contact contact);
        void DeleteContactById(int id);
       // List<Category> GetAllCategories();
      //  List<Contact> GetAllcontacts();
        List<Category> GetAllCategories();
        void AddNewCategory(Category cat);
        void DeleteCategoryById(int id);
        List<Contact> GetAllContactsByCId(int id);

    }
}
