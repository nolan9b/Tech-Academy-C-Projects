using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPracticalExercise.Models;

namespace MVCPracticalExercise.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _connectionString = @"Data Source=NOLAN\SQLEXPRESS;Initial Catalog=Insurance;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GenerateQuote(string firstName, string lastName, string emailAddress,
                                            DateTime dateOfBirth, int carYear, string carMake, string carModel,
                                           bool? dUI, int tickets, bool? cover)
        {
            // Checkbox inputs are not submitted when unchecked
            // If checkbox is unchecked no value will be sent and thus DUI and Cover will be null.
            if (dUI == null) { dUI = false; }
            if (cover == null) { cover = false; }
            
            // Create quote instance,  calculate price and return details to view
            var quote = new Quote(firstName, lastName, emailAddress,
                                        dateOfBirth, carYear, carMake, carModel,
                                       dUI, tickets, cover);

            Quote.CalculateQuotePrice(quote);
            int price = quote.Price;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                string queryString = @"INSERT INTO Quotes (FirstName, LastName, EmailAddress, DateOfBirth, CarYear, CarMake, CarModel, DUI, Tickets, Cover, Price)
                                        VALUES (@FirstName, @LastName, @EmailAddress, @DateOfBirth, @CarYear, @CarMake, @CarModel, @DUI, @Tickets, @Cover, @price)";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    var command = new SqlCommand(queryString, connection);
                    command.Parameters.Add("@FirstName", SqlDbType.VarChar);
                    command.Parameters.Add("@LastName", SqlDbType.VarChar);
                    command.Parameters.Add("@EmailAddress", SqlDbType.VarChar);
                    command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime);
                    command.Parameters.Add("@CarYear", SqlDbType.Int);
                    command.Parameters.Add("@CarMake", SqlDbType.VarChar);
                    command.Parameters.Add("@CarModel", SqlDbType.VarChar);
                    command.Parameters.Add("@DUI", SqlDbType.Bit);
                    command.Parameters.Add("@Tickets", SqlDbType.Int);
                    command.Parameters.Add("@Cover", SqlDbType.Bit);
                    command.Parameters.Add("@Price", SqlDbType.Int);

                    command.Parameters["@FirstName"].Value = firstName;
                    command.Parameters["@LastName"].Value = lastName;
                    command.Parameters["@EmailAddress"].Value = emailAddress;
                    command.Parameters["@DateOfBirth"].Value = dateOfBirth;
                    command.Parameters["@CarYear"].Value = carYear;
                    command.Parameters["@CarMake"].Value = carMake;
                    command.Parameters["@CarModel"].Value = carModel;
                    command.Parameters["@DUI"].Value = dUI;
                    command.Parameters["@Tickets"].Value = tickets;
                    command.Parameters["@Cover"].Value = cover;
                    command.Parameters["@Price"].Value = price;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return View("Success", quote);
        }
    }
}