using static System.Console;

namespace Pattern.Command
{
    class Save : ICommand
    {
        public string GetMenuRow()
        {
            return "Сохранить в файл";
        }
        public bool Run()
        {
            WriteLine("Сохранили");
            return false;
        }
    }
}

