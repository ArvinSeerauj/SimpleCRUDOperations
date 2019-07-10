using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace WebCRUD.Models
{
    public class CustomerDataAccessLayer
    {
        /// <summary>
        /// Set the database connection
        /// </summary>
        /// <returns></returns>
        public SqlConnection objConnection()
        {
            SqlConnection objCon = new SqlConnection();
            objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
            return objCon;
        }
        /// <summary>
        /// Get all customers from the table tbCustomer
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> GetAllCustomers()
        {
            string strSql = string.Empty;
            List<Customer> lstCust = new List<Customer>();
            strSql = "SELECT * FROM [dbo].[tbCustomer]";
            using (SqlConnection objCon = objConnection())
            {                
                SqlCommand objCmd = new SqlCommand(strSql, objCon);
                    //name of connection assigned from the Web.Config
                    objCon.Open();
                    SqlDataReader objReader = objCmd.ExecuteReader();
                    while (objReader.Read())
                    {
                        Customer objCust = new Customer();
                        objCust.CustomerId = Convert.ToInt32(objReader["CustomerId"]);
                        objCust.FirstName = objReader["FirstName"].ToString();
                        objCust.LastName = objReader["LastName"].ToString();
                        objCust.Address = objReader["Address"].ToString();
                        objCust.Email = objReader["Email"].ToString();
                        objCust.ContactNo = objReader["ContactNo"].ToString();
                        objCust.IsActive = Convert.ToBoolean(objReader["IsActive"]);
                        lstCust.Add(objCust);
                    }
            }
            return lstCust;
        }
        /// <summary>
        /// Query Customer by CustomerId
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        public Customer GetCustomerById(int? CustomerId)
        {
            string strSql = string.Empty;
            Customer objCust = new Customer();
            strSql = "SELECT * FROM [dbo].[tbCustomer] WHERE [CustomerId] = " + CustomerId;
            using (SqlConnection objCon = objConnection())
            {
                SqlCommand objCmd = new SqlCommand(strSql, objCon);
                objCon.Open();
                SqlDataReader objReader = objCmd.ExecuteReader();
                while (objReader.Read())
                {
                    objCust.CustomerId = Convert.ToInt32(objReader["CustomerId"]);
                    objCust.FirstName = objReader["FirstName"].ToString();
                    objCust.LastName = objReader["LastName"].ToString();
                    objCust.Address = objReader["Address"].ToString();
                    objCust.Email = objReader["Email"].ToString();
                    objCust.ContactNo = objReader["ContactNo"].ToString();
                    objCust.IsActive = Convert.ToBoolean(objReader["IsActive"]);
                }
            }
            return objCust;
        }
        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="cust"></param>
        public void CreateCustomer(Customer cust)
        {
            string strSql = string.Empty;
            strSql = "INSERT INTO [dbo].[tbCustomer] " +
                        "([FirstName], [LastName], [Address], [Email], [ContactNo])" +
                        " VALUES " +
                        "('" + cust.FirstName + "', '" + cust.LastName + "', '" + cust.Address + "', '" + cust.Email + "', " + cust.ContactNo + ")";
            using (SqlConnection objCon = objConnection())
            {
                SqlCommand cmd = new SqlCommand(strSql, objCon);
                objCon.Open();
                cmd.ExecuteNonQuery();
                objCon.Close();
            }
        }
        /// <summary>
        /// Update Customer by the CustomerId
        /// </summary>
        /// <param name="cust"></param>
        public void UpdateCustomerById(Customer cust)
        {
            string strSql = string.Empty;
            strSql = "UPDATE [dbo].[tbCustomer] " +
                        "SET [FirstName] = '" + cust.FirstName + 
                        "', [LastName] =' " + cust.LastName +
                        "', [Address] = '" + cust.Address +
                        "', [Email] = '" + cust.Email +
                        "', [ContactNo] = " + cust.ContactNo +
                        " WHERE [CustomerId] = " + cust.CustomerId;                        
            using (SqlConnection objCon = objConnection())
            {
                SqlCommand cmd = new SqlCommand(strSql, objCon);
                objCon.Open();
                cmd.ExecuteNonQuery();
                objCon.Close();
            }
        }
        /// <summary>
        /// Delete a customer by CustomerId
        /// </summary>
        /// <param name="CustomerId"></param>
        public void DeleteCustomerById(int CustomerId)
        {
            string strSql = string.Empty;
            strSql = "DELETE [dbo].[tbCustomer] WHERE [CustomerId] = " + CustomerId;
            using (SqlConnection objCon = objConnection())
            {
                SqlCommand cmd = new SqlCommand(strSql, objCon);
                objCon.Open();
                cmd.ExecuteNonQuery();
                objCon.Close();
            }
        }
    }
}