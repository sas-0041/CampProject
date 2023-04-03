using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var carDetail in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(carDetail.BrandName+" / "+carDetail.CarType+" / "
                    +carDetail.ColorName+" / "+carDetail.DailyPrice+"TL");
            }
        }

        private static void ColorTest()
        {
            Color color = new Color()
            {
                ColorId = 4,
                ColorName = "Blue"
            };
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color1 in colorManager.GetAllByColors().Data)
            {
                Console.WriteLine(color1.ColorName);
            }
            var result = colorManager.GetByColorId(2);
            Console.WriteLine(result.Data.ColorName);
        }

        private static void BrandTest()
        {
            Brand brand = new Brand()
            {
                BrandId = 4,
                BrandName = "Opel Combo",
            };
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand1 in brandManager.GetAllByBrands().Data)
            {
                Console.WriteLine(brand1.BrandName);
            }
            var result = brandManager.GetByBrandId(1);

            Console.WriteLine(result.Data.BrandName);
        }

        private static void CarTest()
        {
            Car car = new Car()
            {
                Id = 5,
                BrandId = 1,
                ColorId = 3,
                CarType = "Hatchback tek kapı",
                DailyPrice = 350,
                ModelYear = 2015,
                Description = "Tüplü"
            };

            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Update(car);

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}
            Console.WriteLine("Hello World!");
        }
    }
}
