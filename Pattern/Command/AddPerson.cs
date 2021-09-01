using System.Collections.Generic;
using static System.Console;

namespace Pattern.Command
{
    class AddPerson : ICommand
    {
        private List<Persona> persons;
        public AddPerson(List<Persona> persons)
        {
            this.persons = persons;
        }
        public string GetMenuRow()
        {
            return "Добавить новую персону";
        }

        public bool Run()
        {
            Write("Введите имя: ");
            string name = ReadLine();
            Write("Введите возраст: ");
            string age = ReadLine();
            Persona persona = new Persona();
            persona.Name = name;
            persona.Age = int.Parse(age);
            persons.Add(persona);
            return false;
        }
    }
}
