using Pattern.Command;
using System.Collections.Generic;

namespace Pattern
{
    static class Program
    {

        static void Main(string[] args)
        {
            List<Persona> persons = new List<Persona>();
            persons.Add(new Persona());

            List<ICommand> commands = new List<ICommand>();
            commands.Add(new AddPerson(persons));
            commands.Add(new NewMenu(persons));
            commands.Add(new Exit());
            commands.Add(new Load());
            commands.Add(new Save());

            MenuRunner menuRun = new MenuRunner(commands);
            menuRun.MenuRun();


           

                //1. Новый класс команды
                //2. Передать в новую команду коллекцию персон через конструктор
                //3. Ввод возраста и имени
                //4. Создать новый объект и добавить в коллекцию
            }

    }
}

