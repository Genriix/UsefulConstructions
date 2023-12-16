namespace UsefulConstructions
{
    internal class TestAll
    {
        static void Action1()
        {
            Console.Clear();
            Console.WriteLine("Выбрано действие 1");
            Thread.Sleep(5000);
            Console.WriteLine("Действие выполнено");
            Thread.Sleep(1000);
        }
        static void Main(string[] args)
        {



            string[] frames = {
            "Привет! <З",
            "Меня зовут Ани ^^",
            "Я здесь, для того чтобы вывести для тебя...",
            "Пару зацикленных фраз или картинок :D",
            "Нажми на q, для выхода"};

            ConsoleAnimation consoleAnimation = new();
            do
            {
                while (!Console.KeyAvailable)
                {
                    consoleAnimation.Show(9, 3, frames, 2000);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Q);




            string head = "Селекторное меню";

            Dictionary<string, Action> switches = new()
            {
                ["Действие 1"] = Action1,
                ["Выход"] = null
            };
            string footer = "Подвал меню";
            ConsoleSelectMenu.CreateMenu(head, 9, 3, switches, 10, 5, footer, 12, 8);
        }
    }
}