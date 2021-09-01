using static System.Console;

namespace Pattern.Command
{
    class Load : ICommand
    {
        public string GetMenuRow()
        {
            return "Загрузить из файла";
        }
        public bool Run()
        {
            WriteLine("Загрузили");
            return false;
        }
    }
}
