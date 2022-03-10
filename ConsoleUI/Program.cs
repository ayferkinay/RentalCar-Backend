using Business.Concrete;
using DataAccess.Concrete.EntitiyFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            // CarDetails();
            RentalTest();
            Console.ReadLine();
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDall());
            Rental rental = new Rental {Id=3, CarId = 1, CustomerId = 1, RentDate = DateTime.Today };
            var result = rentalManager.Add(rental);
            if (result.Success == false)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car's Color: " + car.ColorId + "\nCar's Brand :  " + car.BrandName + "\nCar's Name : " + car.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
          
        }
    }
}