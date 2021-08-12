using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using static System.Console;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class Program
    {
        [Serializable]
       
        public class Car
        {
            
            public Car(string vendor, string model, int year, int power, string color)
            {
                Vendor = vendor;
                Model = model;
                Year = year;
                Power = power;
                Color = color;
            }
            public string Vendor { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public int Power { get; set; }
            public string Color { get; set; }
           // public List<Car> Auto { get; set; } = new List<Car>();
        }
        static void Main(string[] args)
        {
            Car
            c1 = new Car("BMW", "X1", 2019, 180, "blue" ),
            c2 = new Car("Ford", "Kuga", 2015, 150, "gray"),
            c3 = new Car("Audi", "A4", 2021, 180, "red");
         
            List<Car> Cars = new List<Car>() { c1, c2, c3 };

            JsonSerializer jsonSerializer = new JsonSerializer();
          
          /*  using (Stream fs = new FileStream("data.json", FileMode.OpenOrCreate))
            {
                using (JsonWriter jsonWriter = new JsonTextWriter(new StreamWriter(fs)))
                {
                    jsonSerializer.Serialize(jsonWriter, Cars);
                }
            }*/

          // Cars = null;

            using (Stream fs = new FileStream("data.json", FileMode.Open))
            {
                using (JsonReader jsonReader = new JsonTextReader(new StreamReader(fs)))
                {
                    Cars = jsonSerializer.Deserialize(jsonReader, typeof(List<Car>)) as List<Car>;
                }
            }
           


            ReadKey();
        }
    }
}

