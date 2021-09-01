using Pattern.Command;
using System.Collections.Generic;
using static System.Console;


namespace Pattern
{
    class MenuRunner
    {
        private List<ICommand> commands;
        public MenuRunner(List<ICommand> commands)
        {
            this.commands = commands;
        }
        public void MenuRun()
        {
            bool isExit = false;
            do
            {
                WriteLine("Меню");
                WriteLine("Введите номер нужного действия");

                int num = 1;
                foreach (ICommand command in commands)
                {
                    WriteLine(num + ". " + command.GetMenuRow());
                    num++;
                }

                string userInput = ReadLine();

                num = int.Parse(userInput);
                isExit = commands[num - 1].Run();
            }
            while (!isExit);
        }
    }
}
