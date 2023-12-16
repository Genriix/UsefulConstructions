/*
 Класс для создания интерактивного селекторного меню

Для его использования требуется:

1. Создать string головы. Это может быть как пара слов, как и целый текст.
   Автопереноса здесь нет, так что перенос текста на новую строчку надо будет
   Писать ручками
2. Добавить словарь для пары свитч-действие.
   ВАЖНО! Чтобы действия были void и не принимали значений (Как в TestAll)
3. Добавить string подвала.
4. Создать экземпляр класса.

Синтаксис: ConsoleSelectMenu.CreateMenu(stringHead, intHeadX, intHeadY, dictionarySwitches, intSwitchesX, intSwitchesY, stringFooter, footerX, footerY );
 
Если шапка и подвал нам не нужны, можно в их string поля поставить "noHead" и "noFooter" соответственно.
 */

namespace UsefulConstructions
{
    internal class ConsoleSelectMenu
    {
        static public void CreateMenu(string head, int headX, int headY, Dictionary<string, Action> switches, int switchesX, int switchesY, string footer, int footerX, int footerY)
        {
            Console.Clear();
            string[] items = new string[switches.Keys.Count];
            switches.Keys.CopyTo(items, 0);

            int index = 0;
            while (true)
            {
                Console.CursorVisible = false;

                if (head != "noHead")
                {
                    Console.SetCursorPosition(headX, headY);
                    Console.Write(head);
                }

                for (int i = 0; i < items.Length; i++)
                {
                    Console.SetCursorPosition(switchesX, i + switchesY);
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("// " + items[i]);
                        Console.ResetColor();
                    }
                    else { Console.WriteLine(" " + items[i] + "  "); }
                }

                if (footer != "noFooter")
                {
                    Console.SetCursorPosition(footerX, footerY);
                    Console.Write(footer);
                }

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < items.Length - 1) index++;

                        else index = 0;

                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0) index--;

                        else index = items.Length - 1;

                        break;
                    case ConsoleKey.Enter:
                        if (index == items.Length - 1) { Console.Clear(); return; }
                        else switches.Values.ElementAt(index).Invoke(); Console.Clear(); break; // Выполнение функции класса Execute
                }
            }
        }
    }
}
