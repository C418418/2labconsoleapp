using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace EscapeRoomGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вы просыпаетесь в комнате и пытаетесь вспомнить свое имя.");
            Console.Write("Введите имя вашего персонажа: ");
            string playerName = Console.ReadLine();

            bool hasKey = false;
            bool hasLockpick = false;
            bool[] artifactsFound = new bool[3]; 

            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("1. Открыть дверь");
                Console.WriteLine("2. Заглянуть под кровать");
                Console.WriteLine("3. Открыть ящик в углу комнаты");
                Console.WriteLine("4. Открыть вентиляцию");
                Console.WriteLine("5. Взглянуть на тумбочку");
                Console.WriteLine("6. Взглянуть на статую рядом с дверью");
                Console.Write("Выберите действие (1-6): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (hasLockpick)
                        {
                            Console.WriteLine($"{playerName}, вы открыли дверь и успешно сбежали!");
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, дверь закрыта. Вам нужно найти отмычку.");
                        }
                        break;

                    case "2":
                        if (!artifactsFound[0])
                        {
                            Console.WriteLine($"{playerName}, вы нашли первый артефакт под кроватью!");
                            artifactsFound[0] = true;
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, под кроватью больше ничего нет.");
                        }
                        break;

                    case "3":
                        if (hasKey)
                        {
                            hasLockpick = true;
                            Console.WriteLine($"{playerName}, вы открыли ящик и нашли отмычку от двери!");
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, ящик закрыт. Вам нужно активировать статую, чтобы получить ключ.");
                        }
                        break;

                    case "4":
                        for (int attempts = 0; attempts < 3; attempts++)
                        {
                            Console.WriteLine($"{playerName}, вы пытаетесь открыть вентиляцию... (попытка {attempts + 1})");
                        }
                        if (!artifactsFound[1])
                        {
                            Console.WriteLine($"{playerName}, вы нашли второй артефакт в вентиляции!");
                            artifactsFound[1] = true;
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, в вентиляции больше ничего нет.");
                        }
                        break;

                    case "5":
                        if (!artifactsFound[2])
                        {
                            Console.WriteLine($"{playerName}, вы нашли третий артефакт на тумбочке!");
                            artifactsFound[2] = true;
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, на тумбочке больше ничего нет.");
                        }
                        break;

                    case "6":
                        if (artifactsFound[0] && artifactsFound[1] && artifactsFound[2])
                        {
                            hasKey = true;
                            Console.WriteLine($"{playerName}, вы активировали статую и получили ключ от ящика!");
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, вам нужно найти все три артефакта для активации статуи.");
                        }
                        break;

                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, выберите действие от 1 до 6.");
                        break;
                }
            }
        }
    }
}
