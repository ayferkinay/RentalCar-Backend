using Business.Concrete;
using DataAccess.Concrete.EntitiyFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarDetails();
            Console.ReadLine();
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