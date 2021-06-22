using System;
using System.Collections.Generic;
using System.Linq;

namespace YabsProblemB
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> globalDictionary = new Dictionary<int, string>();

            for (int i = 0; i <= 2000; i++)
            {
                string[] values = Console.ReadLine().Split(' ');

                if (values[0] == "def")
                {
                    if (globalDictionary.Where(x => x.Value == values[1]).Count() > 0)
                        globalDictionary.Remove((from item in globalDictionary where item.Value == values[1] select item.Key).FirstOrDefault());
                    globalDictionary.Add(int.Parse(values[2]), values[1]);
                }

                else if (values[0] == "calc")
                {
                    int fullCommand = 0;
                    string realResult = "";
                    bool exit = false;

                    for (int y = 0; y < values.Length; y++)
                    {
                        if (!exit)
                        {
                            switch (values[y])
                            {
                                case "calc":
                                    break;
                                case "+":
                                    break;
                                case "-":
                                    y++;
                                    fullCommand -= globalDictionary.FirstOrDefault(x => x.Value == values[y]).Key;
                                    break;
                                case "=":
                                    break;
                                default:
                                    if (!string.IsNullOrEmpty(globalDictionary.FirstOrDefault(x => x.Value == values[y]).Value))
                                        fullCommand += globalDictionary.FirstOrDefault(x => x.Value == values[y]).Key;
                                    else
                                    {
                                        fullCommand = 0;
                                        exit = true;
                                    }
                                    break;
                            }
                        }
                    }

                    if (globalDictionary.Where(x => x.Key == fullCommand).Count() > 0)
                        realResult = globalDictionary.FirstOrDefault(x => x.Key == fullCommand).Value.ToString();

                    foreach (var item in values.Skip(1))
                        Console.Write($"{ item } ");

                    Console.WriteLine($"{ (!string.IsNullOrEmpty(realResult) ? realResult : "unknown") }");
                }

                else if (values[0] == "clear")
                    globalDictionary.Clear();
            }
        }
    }
}
