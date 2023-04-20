// Реализовать автоматическое управление списком вызовов обработчика событий (сложение, вычитание, умножение, деление)

namespace Events
{
    delegate void MyMathEvent();
    class MyEvent
    {
        MyMathEvent[] evnt = new MyMathEvent[4];
        public event MyMathEvent Event
        {
            add
            {
                int i;
                for (i = 0; i < 4; i++)
                    if (evnt[i] == null)
                    {
                        evnt[i] = value;
                        break;
                    }
            }
            remove
            {
                int i;
                for (i = 0; i < 4; i++)
                    if (evnt[i] == value)
                    {
                        evnt[i] = null;
                        break;
                    }
                if (i == 4) Console.WriteLine("Обработчик событий не найден.");
            }
        }
        public void Zapusk()
        {
            for (int i = 0; i < 4; i++)
                if (evnt[i] != null) evnt[i]();
        }
    }
    class Addition
    {
        private float a;
        private float b;
        public Addition(float a, float b)
        {
            this.a = a;
            this.b = b;
        }
        public void Add() => Console.WriteLine($"Сложение: {a + b}");
    }
    class Subtraction
    {
        private float a;
        private float b;
        public Subtraction(float a, float b)
        {
            this.a = a;
            this.b = b;
        }
        public void Sub() => Console.WriteLine($"Вычитание: {a - b}");
    }
    class Multiplication
    {
        private float a;
        private float b;
        public Multiplication(float a, float b)
        {
            this.a = a;
            this.b = b;
        }
        public void Mult() => Console.WriteLine($"Умножение: {a * b}");
    }
    class Division
    {
        private float a;
        private float b;
        public Division(float a, float b)
        {
            this.a = a;
            this.b = b;
        }
        public void Div()
        {
            if (b == 0) { Console.WriteLine($"Деление: на 0 делить нельзя, дурашка"); }
            else { Console.WriteLine($"Деление: {a / b}"); }
        }
    }
    class Program
    {
        static void Main()
        {
            Console.Write("Введите первое число: ");
            float n1 = float.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            float n2 = float.Parse(Console.ReadLine());
            Console.WriteLine();

            MyEvent evt = new MyEvent();
            Addition a = new Addition(n1, n2);
            Subtraction s = new Subtraction(n1, n2);
            Multiplication m = new Multiplication(n1, n2);
            Division d = new Division(n1, n2);

            evt.Event += a.Add;
            evt.Event += s.Sub;
            evt.Event += m.Mult;
            evt.Event += d.Div;

            evt.Zapusk();
        }
    }
}
