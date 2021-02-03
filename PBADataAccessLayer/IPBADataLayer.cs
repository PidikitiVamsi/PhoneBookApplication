using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBAEntity;

namespace PBADataAccessLayer
{
   public interface IPBADataLayer
    {
        List<Contact> GetAllcontactsById(int id);
        void AddContact(Contact contact);
        void DeleteContactById(int id);
        void DeleteCategoryById(int id);
        void AddNewCategory(Category cat);
        List<Category> GetAllCategories();
      //  void UpdateContactById(Contact contact);
    }
}
