using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using static System.Console;

namespace XML
{
    class Program
    {
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }

        public static void OutPutElement(XmlElement el, int level)
        {
            string tab = new string('\t', level);
            WriteLine($"{tab}{el.Name}:{el.NodeType}, atr={el.HasAttributes}, nodes = {el.HasChildNodes}");
            if (el.HasChildNodes)
            {
                foreach (XmlLinkedNode child in el.ChildNodes)
                {
                    if (child is XmlText)
                    {
                        WriteLine($"{tab}{child.Name}:{child.NodeType}, {child.Value}");
                    }
                    else
                    {
                        OutPutElement(child as XmlElement, level + 1);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
           // persons.Add(new Person("Name 1", 19));
           // persons.Add(new Person("Name 2", 22));

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("person.xml");
                XmlElement root = doc.DocumentElement;
              //XmlNodeList children = root.ChildNodes;
                foreach (XmlElement node in root.ChildNodes)
                {
                    if(node.Name !="Person")
                    {
                        continue;
                    } 
                    string Name = "";
                    int nAge = 0;
                    /* string Name = node.GetAttribute("Name");
                     string sAge = node.GetAttribute("Age");
                     int nAge = int.Parse(sAge);
                     Person person = new Person(Name, nAge);
                     persons.Add(person);*/
                    
                    foreach (XmlAttribute child in node.Attributes)
                    {
                        switch (child.Name)
                        {
                            case "Name":
                                Name = child.Value;
                                break;
                            case "Age":
                                nAge = int.Parse(child.Value);
                                break;
                        }
                    }
                    foreach (XmlElement child in node.ChildNodes)
                    {
                        switch (child.Name)
                        {
                            case "Name":
                                Name = child.InnerText;
                                break;
                            case "Age":
                                nAge = int.Parse(child.InnerText);
                                break;
                        }
                    }
                   /*if (node.HasAttributes)
                    {
                        Name = node.GetAttribute("Name");
                        string sAge = node.GetAttribute("Age");
                        nAge = int.Parse(sAge);
                    }
                    else
                    {

                    }*/
                    Person person = new Person(Name, nAge);
                    persons.Add(person);
                } 
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            foreach (Person person in persons)
            {
                WriteLine($"{person.Name}:{person.Age}");
            }
            ReadKey();


            #region MyRegion
            /*

                            using (XmlTextWriter writer = new XmlTextWriter("person.xml", Encoding.UTF8))
                            {
                                writer.Formatting = Formatting.Indented;
                                writer.WriteStartDocument();
                                writer.WriteStartElement("ArrayOfPerson");
                                foreach(Person  person in persons)
                                {
                                    /*
                                     * <Person>
                                     *      <Name>Name 1</Name>
                                     *      <Age>33</Age>
                                     * </Person>
                                     * 
                                     * <Person Name="Name 1" Age="33"/>
                                     *      <Documents></Documents>
                                     *      <Passport/>
                                     * </Person>
                                     * 
                                     */
            /* writer.WriteStartElement("Person");

                 writer.WriteStartAttribute("Name");
                 writer.WriteValue(person.Name);
                 writer.WriteEndAttribute();

                 writer.WriteStartAttribute("Age");
                 writer.WriteValue(person.Age);
                 writer.WriteEndAttribute();

             writer.WriteEndElement();

             writer.WriteStartElement("Person");

                 writer.WriteStartElement("Name");
                 writer.WriteValue(person.Name);
                 writer.WriteEndElement();
                 writer.WriteStartElement("Age");
                 writer.WriteValue(person.Age);
                 writer.WriteEndElement();

             writer.WriteEndElement();
         }
         writer.WriteEndElement();
     }*/
            #endregion
        }
    }
}


