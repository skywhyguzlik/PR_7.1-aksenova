using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_7_1
{
    /// <summary>
    /// Главный класс объединённого консольного приложения «Практическая работа №7».
    /// Предоставляет текстовое меню для запуска трёх учебных программ:
    /// «Числа Фибоначчи», «Галактики» и «Буквы».
    /// Каждый раздел демонстрирует возможности отладчика Microsoft Visual Studio.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Точка входа в приложение.
        /// Отображает главное меню в цикле до тех пор, пока
        /// пользователь не выберет пункт «Выход» (0).
        /// </summary>
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("0) Выход; 1) Числа Фибоначчи; 2) Галактики; 3) Буквы");

                Console.Write("\nВаш выбор: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        RunFibonacci();
                        break;
                    case "2":
                        RunGalaxies();
                        break;
                    case "3":
                        RunLetters();
                        break;
                    case "0":
                        Console.WriteLine("До свидания!");
                        return;
                    default:
                        Console.WriteLine("Неверный ввод. Нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню...");
                Console.ReadKey();
            }
        }



        // ЗАДАНИЕ 1 — ЧИСЛА ФИБОНАЧЧИ

        /// <summary>
        /// Запускает приложение «Числа Фибоначчи».
        /// Запрашивает у пользователя индекс <c>n</c> и выводит
        /// последовательность от F(0) до F(n), а также значение F(n).
        /// </summary>
        /// <remarks>
        /// Использованные инструменты отладки Visual Studio:
        /// <list type="bullet">
        ///   <item><b>Breakpoints</b> — внутри рекурсивного метода <see cref="Fibonacci"/> для наблюдения за стеком.</item>
        ///   <item><b>Call Stack</b> — просмотр глубины рекурсии (при n=7 стек разворачивается на 8 уровней).</item>
        ///   <item><b>Locals</b> — отслеживание параметра <c>n</c> на каждом уровне рекурсии.</item>
        ///   <item><b>Step Into F11</b> — пошаговое выполнение рекурсивных вызовов.</item>
        ///   <item><b>Step Over F10</b> — выполнение итерации цикла без захода в <see cref="Fibonacci"/>.</item>
        ///   <item><b>Data Tips</b> — наведение курсора на переменную <c>n</c> для проверки значения.</item>
        /// </list>
        /// </remarks>
        static void RunFibonacci()
        {
            Console.Clear();
            Console.WriteLine("=== Числа Фибоначчи ===\n");
            Console.Write("Введите порядковый номер числа Фибоначчи (от 0): ");

            if (!int.TryParse(Console.ReadLine(), out int n) || n < 0)
            {
                Console.WriteLine("Ошибка: введите целое неотрицательное число.");
                return;
            }

            Console.WriteLine($"\nПоследовательность Фибоначчи (0 .. {n}):");
            for (int i = 0; i <= n; i++)
            {
                Console.Write(Fibonacci(i));
                if (i < n) Console.Write(", ");
            }

            Console.WriteLine();
            Console.WriteLine($"\nF({n}) = {Fibonacci(n)}");
        }

        static int Fibonacci(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException(nameof(n),
                    "Индекс не может быть отрицательным.");
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        /// <summary>
        /// Рекурсивно вычисляет n-е число последовательности Фибоначчи.
        /// </summary>
        /// <remarks>
        /// Последовательность определяется правилом:
        /// F(0) = 0, F(1) = 1, F(n) = F(n-1) + F(n-2) при n ≥ 2.
        /// Внимание: рекурсивный алгоритм имеет экспоненциальную сложность
        /// O(2^n) и пригоден лишь для небольших значений n.
        /// </remarks>
        /// <param name="n">Индекс числа Фибоначчи (≥ 0).</param>
        /// <returns>Значение n-го числа Фибоначчи.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Выбрасывается, если <paramref name="n"/> отрицательное.
        /// </exception>







        // ЗАДАНИЕ 2 — ГАЛАКТИКИ

        /// <summary>
        /// Запускает приложение «Галактики».
        /// Выводит список галактик с названием, расстоянием (МСв) и морфологическим типом.
        /// </summary>
        /// <remarks>
        /// В исходном коде содержались два бага, обнаруженных и исправленных в ходе отладки:
        /// <list type="number">
        ///   <item>
        ///     Свойство <c>GalaxyType</c> класса <see cref="Galaxy"/> было объявлено как <c>object</c>
        ///     вместо <c>GType</c> — вместо названия типа выводилось имя класса.
        ///   </item>
        ///   <item>
        ///     В конструкторе <see cref="GType"/> символ <c>'l'</c> (строчная L) вместо <c>'I'</c>
        ///     (заглавная I) — тип Irregular никогда не устанавливался.
        ///   </item>
        /// </list>
        /// Использованные инструменты отладки Visual Studio:
        /// <list type="bullet">
        ///   <item><b>Breakpoints</b> — на строку <c>Console.WriteLine</c> внутри <c>foreach</c> и на конструктор <see cref="GType"/>.</item>
        ///   <item><b>Data Tips</b> — наведение на <c>theGalaxy.GalaxyType</c> → раскрытие → обнаружение свойства <c>MyGType</c>.</item>
        ///   <item><b>Step Into F11</b> — заход в конструктор <see cref="GType"/> для проверки ветки <c>switch</c>.</item>
        ///   <item><b>Edit and Continue / Hot Reload</b> — исправление типа свойства прямо во время сеанса отладки.</item>
        ///   <item><b>Restart Ctrl+Shift+F5</b> — перезапуск приложения после правки.</item>
        /// </list>
        /// </remarks>


        static void RunGalaxies()
        {
            Console.Clear();
            Console.WriteLine("=== Welcome to Galaxy News! ===\n");

            var galaxies = new List<Galaxy>
        {
            new Galaxy { Name = "Tadpole",                MegaLightYears = 400, GalaxyType = new GType('S') },
            new Galaxy { Name = "Pinwheel",               MegaLightYears = 25,  GalaxyType = new GType('S') },
            new Galaxy { Name = "Cartwheel",              MegaLightYears = 500, GalaxyType = new GType('L') },
            new Galaxy { Name = "Small Magellanic Cloud", MegaLightYears = 0.2, GalaxyType = new GType('I') },
            new Galaxy { Name = "Andromeda",              MegaLightYears = 3,   GalaxyType = new GType('S') },
            new Galaxy { Name = "Maffei 1",               MegaLightYears = 11,  GalaxyType = new GType('E') }
        };

            Console.WriteLine($"{"Название",-28} {"Расстояние (МСв)",18}   {"Тип",12}");
            Console.WriteLine(new string('─', 64));

            foreach (Galaxy g in galaxies)
            {
                Console.WriteLine($"{g.Name,-28} {g.MegaLightYears,18}   {g.GalaxyType.MyGType,12}");
            }
        }

        /// <summary>
        /// Представляет галактику с именем, расстоянием и морфологическим типом.
        /// </summary>
        class Galaxy
        {
            public string Name { get; set; }
            public double MegaLightYears { get; set; }
            public GType GalaxyType { get; set; }
        }

        class GType
        {
            public enum GalaxyTypeEnum { Spiral, Elliptical, Irregular, Lenticular }
            public GalaxyTypeEnum MyGType { get; set; }

            public GType(char type)
            {
                switch (type)
                {
                    case 'S': MyGType = GalaxyTypeEnum.Spiral; break;
                    case 'E': MyGType = GalaxyTypeEnum.Elliptical; break;
                    case 'I': MyGType = GalaxyTypeEnum.Irregular; break;  // Исправлено: было 'l'
                    case 'L': MyGType = GalaxyTypeEnum.Lenticular; break;
                }
            }
        }





        // ЗАДАНИЕ 3 — БУКВЫ

        /// <summary>
        /// Запускает приложение «Буквы».
        /// Итерирует по массиву символов, на каждом шаге строит строку <c>name</c>
        /// и вызывает <see cref="SendMessage"/>.
        /// </summary>
        static void RunLetters()
        {
            Console.Clear();
            Console.WriteLine("=== Приложение «Буквы» ===\n");

            char[] letters = { 'f', 'r', 'e', 'd', ' ', 's', 'm', 'i', 't', 'h' };
            string name = "";
            int[] a = new int[10];

            for (int i = 0; i < letters.Length; i++)
            {
                name += letters[i];
                a[i] = i + 1;
                SendMessage(name, a[i]);
            }
        }

        /// <summary>
        /// Выводит приветствие с текущим накопленным именем и числовым счётчиком.
        /// </summary>
        /// <param name="name">
        /// Текущее накопленное имя (формируется итерационно в <see cref="RunLetters"/>).
        /// </param>
        /// <param name="msg">
        /// Числовой счётчик, соответствующий текущей итерации (1-based).
        /// </param>
        /// <example>
        /// При первом вызове: <c>SendMessage("f", 1)</c> → <c>Hello, f! Count to 1</c>
        /// </example>

        static void SendMessage(string name, int msg)
        {
            Console.WriteLine($"Hello, {name}! Count to {msg}");
        }
    }
}
