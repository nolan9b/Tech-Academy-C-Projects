using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPracticalExercise.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public bool? DUI { get; set; }
        public int Tickets { get; set; }
        public bool? Cover { get; set; }
        public int Price { get; set; }

        public Quote(string firstName, string lastName, string emailAddress,
                          DateTime dateOfBirth, int carYear, string carMake, string carModel,
                          bool? dUI, int tickets, bool? cover)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            DateOfBirth = dateOfBirth;
            CarYear = carYear;
            CarMake = carMake;
            CarModel = carModel;
            DUI = dUI;
            Tickets = tickets;
            Cover = cover;
            Price = 0;
        }

        public Quote()
        { }

        public static Quote CalculateQuotePrice(Quote quote)
        {
            int basePrice = 50;

            // Calculate Age
            DateTime birthDate = quote.DateOfBirth;
            DateTime now = DateTime.Now;
            int age = now.Year - birthDate.Year;

            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;

            if (age < 18) basePrice += 100;
            if (age >= 18 && age < 25) basePrice += 25;
            if (age >= 100) basePrice += 25;

            // Car Year
            if (quote.CarYear < 2000 || quote.CarYear > 2015) basePrice += 25;
            // Car Make
            if (quote.CarMake.ToLower() == "porsche") basePrice += 25;
            // Car Model
            if (quote.CarMake.ToLower() == "porsche" && quote.CarModel.ToLower() == "911 carrera") basePrice += 25;
            // Tickets
            basePrice += quote.Tickets * 10;
            // DUI
            if (quote.DUI == true) basePrice = (int)(basePrice * 1.25);
            if (quote.Cover == true) basePrice = (int)(basePrice * 1.5);

            quote.Price = basePrice;

            return quote;
        }
    }
}