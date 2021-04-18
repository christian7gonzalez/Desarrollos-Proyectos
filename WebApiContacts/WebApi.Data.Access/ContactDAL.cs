using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using WebApi.Entity;
using Criptografia;


namespace WebApi.Data.Access
{
    public class ContactDAL
    {    
        string connectionString = DesencryptConnectionString("UwBlAHIAdgBlAHIAIAA9ACAARABFAFMASwBUAE8AUAAtAE0AQQBTAEEAVABPAFwAUABSAE8ARABfADIAMAAxADcAOwBJAG4AaQB0AGkAYQBsACAAQwBhAHQAYQBsAG8AZwAgAD0AIABDAG8AbgB0AGEAYwB0AFMAQQA7ACAAVQBzAGUAcgAgAEkARAAgAD0AIABzAGEAOwAgAFAAYQBzAHMAdwBvAHIAZAA9AFAAUgBPAEQAXwAyADAAMQA3AA==");
        static string DesencryptConnectionString(string txtConnection)
        {
            Desencrypt encrypting = new Desencrypt();
            string connectionString = encrypting.SetDesencrypt(txtConnection);
            return connectionString;
        }
        public IEnumerable<Contact> ContactsList()
        {
           
            List<Contact> MenusList = new List<Contact>();
            string querySql = "SELECT * FROM Contact";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(querySql, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr != null) 
                    {
                        while (dr.Read()) 
                        {
                            Contact objContacts = new Contact();
                            objContacts.Id = Convert.ToInt32(dr["id"]);
                            objContacts.FirstName = Convert.ToString(dr["firstName"]);
                            objContacts.LastName = Convert.ToString(dr["lastName"]);
                            objContacts.Company = Convert.ToString(dr["company"]);
                            objContacts.Email = Convert.ToString(dr["email"]);
                            objContacts.PhoneNumber = Convert.ToString(dr["phoneNumber"]);
                            MenusList.Add(objContacts); 
                        }

                    }
                    con.Close();
                }
                return MenusList;
            }
            catch (Exception ex)
            {

                throw ex;
            }   
        }
        public Contact GetContact(int id)
        {
            Contact objContact = new Contact();
            string querySql = "Contact_CxID";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(querySql, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            objContact.Id = Convert.ToInt32(dr["id"]);
                            objContact.FirstName = Convert.ToString(dr["firstName"]);
                            objContact.LastName = Convert.ToString(dr["lastName"]);
                            objContact.Company = Convert.ToString(dr["company"]);
                            objContact.Email = Convert.ToString(dr["email"]);
                            objContact.PhoneNumber = Convert.ToString(dr["phoneNumber"]);
                        }
                    }
                    con.Close();
                }
                return objContact;
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

        public int AddContact(Contact objContacts)
        {
            int id;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Contact_A", con);
                    cmd.Parameters.AddWithValue("@firstName", objContacts.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", objContacts.LastName);
                    cmd.Parameters.AddWithValue("@company", objContacts.Company);
                    cmd.Parameters.AddWithValue("@email", objContacts.Email);
                    cmd.Parameters.AddWithValue("@phoneNumber", objContacts.PhoneNumber);
                    con.Open();
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

        public void EditContact(Contact obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Contact_M", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@firstName", obj.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", obj.LastName);
                    cmd.Parameters.AddWithValue("@company", obj.Company);
                    cmd.Parameters.AddWithValue("@email", obj.Email);
                    cmd.Parameters.AddWithValue("@phoneNumber", obj.PhoneNumber);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }                 
        }
        public void DeleteContact(int id) 
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Contact_B", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id",id)); //muetro otra manera de enviar parametro al SP
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
