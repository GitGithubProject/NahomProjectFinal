using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleInformationPresenter
{
    public class Car
    {

        private double _milage;

        private string _Vin = GetRandomVinNumber();


        // public setter
        public string Make { get; set; }
        public string Model { get; set; }
        public string ManufactureLocation { get; set; }     
        public int Year { get; set; }
        public string EngineType { get; set; }       
        public double Mileage
        {
            get { return _milage; }
            set
            {
                if (value > _milage)
                {
                    _milage = value;

                }
            }
            
        }
        public string Vin { 
            get { return _Vin; } 
            set {
                if(value.Length == 17)
                {
                    _Vin = value;
                }
            
            } 
        }
        public string LotNumber { get; set; }

        // method that create random vin number for the same 
        // manufacturer and the same type of car
        // only the last serial number of vin changed
        // help to locat the differnt car
        public  static string GetRandomVinNumber()
        {

            //return ManufactureLocation[0].ToString() + Make[1].ToString() + Make[2].ToString();

            Random randSerial = new Random();
            string randomNumber = randSerial.Next(0, 1000000).ToString("D6"); ;
            return "1HGBH41JXMN" + randomNumber;
        }

    }

    public class Program
    {
        private static Dictionary<string, Car> carDictionary = new Dictionary<string, Car>();
       
        // method to preload the Dictionary (hashmap in java)
        public static void Prepopulate(List<Car> cars)
        {
            carDictionary =  cars.ToDictionary(x => x.Vin, x => x);
        }

        // method to display the car inventory
        public static void Display()
        {
            foreach (var carDictionaryEntry in carDictionary)
            {
                Console.WriteLine(
                    "  Manufacture--> " + carDictionaryEntry.Value.ManufactureLocation +
                    "  Make--> " + carDictionaryEntry.Value.Make +
                    "  Model--> " + carDictionaryEntry.Value.Model +
                    "  Year--> " + carDictionaryEntry.Value.Year +
                    "  Mileage--> " + carDictionaryEntry.Value.Mileage +
                    "  Vin--> " + carDictionaryEntry.Value.Vin +
                    "  Lot Number--> " + carDictionaryEntry.Value.LotNumber);
            }

        }
        public static void UpdateMilage(string vinNumber, double milage)
        {            
            if(carDictionary.ContainsKey(vinNumber))
            {
                //var car = carDictionary[vinNumber];
                //car.Mileage = milage;
                carDictionary[vinNumber].Mileage = milage;
                Console.WriteLine("The Current Mileage of the Give Vin number is updated: ");
                Console.WriteLine("The new Mileage is: " + carDictionary[vinNumber].Mileage);
            }
            else
            {
                Console.WriteLine("The Vin Number not found");
            }
        }
        static void Main(string[] args)
        {

            // 1. Create list of Cars
            List<Car> listOfCar = new List<Car>
            {
                new Car(){
                    Make="Toyota",ManufactureLocation="Seattle",Vin= "1HGBH41JXMN109186" ,Model="Prius",Year=2021,

                    EngineType="V4", LotNumber="100A", Mileage= 023
                },

                new Car(){
                    Make="Toyota",ManufactureLocation="Seattle",Model="Prius",Year=2021,

                    EngineType="V4", LotNumber="101A",  Mileage= 023
                },
                new Car(){
                    Make="Toyota",ManufactureLocation="Seattle",Model="Prius",Year=2021,

                    EngineType="V4", LotNumber="102A",  Mileage= 023
                },new Car(){
                    Make="Toyota",ManufactureLocation="Seattle",Model="Prius",Year=2021,

                    EngineType="V4", LotNumber="102A", Mileage= 023
                },

                new Car(){
                    Make="Toyota",ManufactureLocation="Seattle",Model="Prius",Year=2021,

                    EngineType="V4", LotNumber="104A",  Mileage= 023
                },
                new Car(){
                    Make="Toyota",ManufactureLocation="Seattle",Model="Prius",Year=2021,

                    EngineType="V4", LotNumber="105A",  Mileage= 023
                },
                
                new Car(){
                    Make="Toyota",ManufactureLocation="Seattle",Model="Prius",Year=2021,

                    EngineType="V4", LotNumber="106A",  Mileage= 023
                },
                new Car(){
                    Make="Toyota",ManufactureLocation="Seattle",Model="Prius",Year=2021,

                    EngineType="V4", LotNumber="107A",  Mileage= 023
                }
            };
            //2 .Call Prepopulate using #1 values as argument

            Prepopulate(listOfCar);



            Console.WriteLine("\n\n");
            Console.WriteLine("=================================================");

            //3. call display method

            //Display the list of the car with its property that found in the
            // in the parkin lot
            Display();

            Console.WriteLine("\n\n");
            Console.WriteLine("=================================================");
            //4.call UpdateMilage , using one of the car's vin number and random milage


            // UpdateMilage(listOfCar.FirstOrDefault().Vin, 908);

            UpdateMilage("1HGBH41JXMN109186", 908);

            Console.WriteLine("\n\n");
            Console.WriteLine("=================================================");

            //The list of car after the give vin number updated for the mileage
            // if the vin number is found and the value of the mileage greater
            // than the current mileage
            Display();

        }
    }
}
