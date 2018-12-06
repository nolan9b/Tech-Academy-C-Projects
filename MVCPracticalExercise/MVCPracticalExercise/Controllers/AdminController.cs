using MVCPracticalExercise.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPracticalExercise.Controllers
{
    public class AdminController : Controller
    {
        private readonly string _connectionString = @"Data Source=NOLAN\SQLEXPRESS;Initial Catalog=Insurance;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public ActionResult Index()
        {
            string queryString = "SELECT * FROM Quotes";
            var quotes = new List<Quote>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var quote = new Quote();
                    quote.Id = Convert.ToInt32(reader["Id"]);
                    quote.FirstName = reader["FirstName"].ToString();
                    quote.LastName = reader["LastName"].ToString();
                    quote.EmailAddress = reader["EmailAddress"].ToString();
                    quote.Price = Convert.ToInt32(reader["Price"]);
                    quotes.Add(quote);
                }
                connection.Close();
            }
            return View(quotes);
        }
    }
}