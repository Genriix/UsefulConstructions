/*
Класс для создания прерываемой анимации в консоли
Для его использования требуется:

1. Заключить экземпляр класса в цикл (не важно, с условием - или без) 
2. Указать позицию анимации от правого края консоли и от верхнего края консоли
3. Добавить список фреймов, которые будет выводить консоль
4. Добавить промежуток (в мс) между фреймами
 */

namespace UsefulConstructions
{
    public class ConsoleAnimation
    {
        int counter;
        public ConsoleAnimation() { counter = 0; }
        public void Show(int left, int top, string[] frames, int time)
        {
            Console.SetCursorPosition(left, top);
            if (counter == frames.Length) counter = 0;
            Console.WriteLine(frames[counter]);
            counter++;
            Thread.Sleep(time);
            Console.Clear();
        }
    }
}
