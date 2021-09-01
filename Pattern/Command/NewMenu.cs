using System.Collections.Generic;
using static System.Console;

namespace Pattern.Command
{
    class NewMenu : ICommand
    {
        private List<Persona> persons;
        public NewMenu(List<Persona> persons)
        {
            this.persons = persons;
        }
        public string GetMenuRow()
        {
            return "Список персон:";
           
        }
        public bool Run()
        {
            foreach (Persona person in persons)
            {
                WriteLine($"{ person.Name},{ person.Age}");
            }
            return false;
        }
    }
}
