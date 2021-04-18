using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Access;
using WebApi.Entity;


namespace WebApi.Business
{
    public class ContactBusiness
    {
        ContactDAL cDAL = new ContactDAL();
        Contact contact = new Contact();
        public IEnumerable<Contact> ContactsList()
        {
            try
            {
                return cDAL.ContactsList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public Contact GetContact(int id)
        {
            try
            {
                contact = cDAL.GetContact(id);
                return contact;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public int AddContact(Contact objContact)
        {
            int id;
            try
            {
                id = cDAL.AddContact(objContact);
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EditContact(Contact obj)
        {
            try
            {
                cDAL.EditContact(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteContact(int id)
        {
            try
            {
                cDAL.DeleteContact(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
