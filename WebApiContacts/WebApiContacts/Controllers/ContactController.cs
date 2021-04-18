using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business;
using WebApi.Entity;

namespace WebApiContacts.Properties
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : Controller
    {
        ContactBusiness cBuss = new ContactBusiness();
        Contact contact = new Contact();

        [HttpGet]
        public IEnumerable<Contact> GetContactsList()
        {
            try
            {
                return cBuss.ContactsList();
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

        [HttpGet("id={id}")] 
        public IActionResult GetContact(int id)
        {
            try
            {
                contact = cBuss.GetContact(id);
                return Ok(contact);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }        
        }
        [HttpPost]
        public IActionResult AddContact(Contact model)
        {
            int id;
            try
            {
                id = cBuss.AddContact(model);
                return Ok("Exito! -- id " + id + " agregardo.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditContact(Contact obj)
        {
            try
            {
                cBuss.EditContact(obj);
                return Ok("Exito! -- id " + obj.Id + " editado.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("id={id}")]
        public IActionResult DeleteContact(int id)
        {
            try
            {
                cBuss.DeleteContact(id);
                return Ok("Exito! -- Contacto con id " + id + " eliminado.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
