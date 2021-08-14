using System.Collections;
using System.Collections.Generic;
using System.Xml;
using static System.Console;

//parse - разбирать

namespace Parser_XML
{
    class Program
    {
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int Height { get; set; }
        }
        class Car
        {
            public string Name { get; set; }
        }
        static void Main(string[] args)
        {

            #region XmlTextReader
            /*
            using (XmlTextReader reader = new XmlTextReader("data.xml"))
            {
                reader.WhitespaceHandling = WhitespaceHandling.None;
                while (reader.Read())
                {
                    WriteLine("LineNumber" + "\t" + reader.LineNumber);
                    WriteLine("Depth" + "\t\t" + reader.Depth);
                    WriteLine("Name" + "\t\t" + reader.Name);
                    WriteLine("NodeType" + "\t" + reader.NodeType);
                    WriteLine("ValueType" + "\t" + reader.ValueType.Name);
                    WriteLine("Value" + "\t\t" + reader.Value);
                    WriteLine("AttributeCount" + "\t" + reader.AttributeCount);
                    if(reader.AttributeCount>0)
                    {
                        while (reader.MoveToNextAttribute())
                        {
                            WriteLine($"\t{reader.NodeType}, {reader.Name},{reader.Value}");
                        }
                    }
                    WriteLine("====================");

                }
            }*/
            #endregion

            ArrayList persons = new ArrayList();
            using (XmlTextReader reader = new XmlTextReader("data.xml"))
            {
                reader.WhitespaceHandling = WhitespaceHandling.None;
                while (reader.Read())
                {
                    //reader.NodeType == "XmlDeclaration" - skip (пропустить)
                    if (reader.NodeType.ToString() == "XmlDeclaration")
                    {
                        continue;
                    }
                    // reader.Name != "ArrayOfPerson"
                    if (reader.Name != "ArrayOfPerson")
                    {
                        WriteLine("Error");
                        break;
                    }
                    ParsePersons(reader, persons);
                }
            }
            foreach (object obj in persons)
            {
                if (obj is Person)
                {
                    Person person = (Person)obj;
                    WriteLine($"{ (obj as Person).Name}: { (obj as Person).Age}: {(obj as Person).Height}");
                }
                if (obj is Car)
                {
                    Car car = (Car)obj;
                    WriteLine($"{car.Name}");
                }
            }
            ReadKey();
        }
        static void ParsePersons(XmlTextReader reader, ArrayList persons)
        {
            while (reader.Read())
            {
                if (reader.Name == "ArrayOfPerson" && reader.NodeType.ToString() == "EndElement")
                {
                    break;
                }
                if (reader.Name == "Person")
                {
                    Person person = ParsePerson(reader);
                    persons.Add(person);
                }
                if (reader.Name == "Car")
                {
                    Car car = ParseCar(reader);
                    persons.Add(car);
                }
            }
        }
        static Person ParsePerson(XmlTextReader reader)
        {
            Person person = new Person();
            while (reader.Read())
            {
                if (reader.NodeType.ToString() == "EndElement")
                {
                    break;
                }
                string Name = reader.Name;
                string Value = GetValue(reader);
                switch (Name)
                {
                    case "Name":
                        person.Name = Value;
                        break;
                    case "Age":
                        person.Age = int.Parse(Value);
                        break;
                    case "Height":
                        person.Height = int.Parse(Value);
                        break;
                }
            }
            return person;
        }
        static Car ParseCar(XmlTextReader reader)
        {
            Car car = new Car();
            while (reader.Read())
            {
                if (reader.NodeType.ToString() == "EndElement")
                {
                    break;
                }
                string Name = reader.Name;
                string Value = GetValue(reader);
                switch (Name)
                {
                    case "Name":
                        car.Name = Value;
                        break;
                }
            }
            return car;
        }
        static string GetValue(XmlTextReader reader)
        {
            string result = "";
            while (reader.Read())
            {
                if (reader.NodeType.ToString() == "EndElement")
                {
                    break;
                }
                result = reader.Value;
            }
            return result;
        }
    }
}
