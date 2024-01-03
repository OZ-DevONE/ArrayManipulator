using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] myArr = new int[10];
            Console.Title = "Программка.";
            bool flag1 = true;
            while (flag1) 
            {
                Console.Clear();

                Console.WriteLine($"Размер инициализиронного массива равна: {myArr.Length}. \n\nВыберите пункты для управления." +
                    $"\n\t1 [Заполнить массив] " +
                    $"\n\t\t2 [Вывести массив в обратно порядке]" +
                    $"\n\t\t\t3 [Найти сумму четных чисел в массиве]" +
                    $"\n\t\t\t\t4 [Найти наименьшее число в массиве]" +
                    $"\n\t\t\t\t\t5 [Текущие значеения в массиве]");

                if (!int.TryParse(Console.ReadLine(), out int pressNumUser) )
                {
                    Console.WriteLine("Такой формат программа не поддерживает. Завершение");
                    return;
                } 
                
                switch (pressNumUser)
                {
                    case 1:
                        {
                            myArr = AddMyArr(myArr);
                            if (myArr == null)
                            {
                                return;
                            }
                            Console.WriteLine("Успешно добавлено, текущие значени в массие.");
                            for (int i = 0; i < myArr.Length; i++)
                            {
                                Console.Write($"[{myArr[i]}]");
                            }
                            break;
                        }

                    case 2:
                        {
                            if (!CheckLenghtMyArr(myArr))
                            {
                                Console.WriteLine("Работа с пустым массив не поддерживается.");
                                break;
                            }

                            for (int i = myArr.Length - 1; i >= 0; i--)
                            {
                                Console.Write($"[{myArr[i]}]");
                            }
                            break;
                        }
                    case 5:
                        {
                            if (!CheckLenghtMyArr(myArr))
                            {
                                Console.WriteLine("Работа с пустым массив не поддерживается.");
                                break;
                            }
                            Console.WriteLine("Текущие значние в массиве: ");
                            foreach (int i in myArr)
                            {
                                Console.Write($"[{i}]");
                            }
                            break;
                        }

                    default:
                        Console.WriteLine("Такого пункта нету.");
                        break;
                }
                
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Метод для проверки массива на пустые элементы
        /// </summary>
        /// <param name="arr">Ткущий массив</param>
        /// <returns>false массив пустой, true в массиве имеются данные</returns>
        static bool CheckLenghtMyArr(int[] arr)
        {
            if(!arr.Any(x => x != 0)) //Если хотябы 1 элемент в массиве не равен 0
            {
                return false;
            }
            return true;
            /*
             * Сокрашенная запись
             * return arr.Any(x => x != 0);
             */
        }

        /// <summary>
        /// Метод добавления данных в массив
        /// </summary>
        /// <param name="arr">Текущий массив</param>
        /// <returns>Новый список массива</returns>
        static int[] AddMyArr(int[] arr)
        {
            int successfullyAdd = 0;
            Console.WriteLine("Введите числа через пробел для добавления в массив:");

            string input = Console.ReadLine(); //Вводим числа от пользователя
            string[] splitNumber = input.Split(' '); //Разделение строк на пробел

            foreach (string number in splitNumber) //Перебираем каждый элемент в массиве splitNumber полученный от input.Split
            {
                if (!int.TryParse(number, out int intNumber) || intNumber == 0) //Конвертируем каждое число в формате string в int, проверка на 0
                {
                    Console.WriteLine("Ошибка: введено некорректное число или ноль.");
                    continue;
                }
                bool flagAddArr = false; //Проверка успеха добавления

                for (int i = 0; i < arr.Length; i++) 
                {
                    if (arr[i] == 0) // Проверка на то что по индексу в массиве находиться пустое значение
                    {
                        arr[i] = intNumber; //Добавляем значние 
                        flagAddArr = true; //Проверка успеха добавления
                        successfullyAdd++; //Количество успешных итераций добалвения
                        break;
                    }
                }

                if(!flagAddArr) //Проверка успеха добавления не пройдена
                {
                    Console.WriteLine("Не хватило место для добавления.");
                }
            }
            Console.WriteLine($"Передано значений: {splitNumber.Length} Успешно добавлено: {successfullyAdd}");
            return arr;
        }
    }
}
