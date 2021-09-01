
namespace Pattern.Command
{
    class Exit : ICommand
    {
        public string GetMenuRow()
        {
            return "Выход";
        }
        public bool Run()
        {
            return true;
        }
    }
}
