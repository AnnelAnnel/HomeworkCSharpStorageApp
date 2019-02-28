using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReserveCopy;


namespace StorageConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            StorageService ss = new StorageService();
            ss.storages.Add(new Flash(32, "Transcend", "D 2000", 9.12, USBType.USB30));
            ss.storages.Add(new Flash(16, "Sony", "E 3500", 9.12, USBType.USB30));
            ss.storages.Add(new HDD(128, "Samsung", "H 2000", 4, 32, USBType.USB30));
            ss.storages.Add(new HDD(256, "Transcend", "H 1500", 4, 64, USBType.USB20));
            ss.storages.Add(new DVD(9.4, "DVD", "RW", 47.6, 10.5, DVDType.twoSided));

            MainMenu(ss);
        }


        public static void MainMenu(StorageService ss)
        {

            Console.WriteLine("1. Общая вместимость доступных устройств");
            Console.WriteLine("2. Копирование информации");
            Console.WriteLine("3. Расчет времени для копирования");
            Console.WriteLine("4. Расчет количества носителей для переноса информации");
            Console.WriteLine("5. Выход");
            Console.Write(": ");
            int choice = 0;
            bool tryChoice = Int32.TryParse(Console.ReadLine(), out choice);
            if (tryChoice)
            {
                if (choice == 1)
                {
                    Console.Clear();
                    
                    for (int i = 0; i < ss.storages.Count; i++)
                    {
                        Console.Write("{0}.", i);
                        ss.storages[i].printInfo();                        
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Общая вместимость {0} Gb", ss.getTotalCapacity());
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Console.Clear();
                    MainMenu(ss);
                }
                else if (choice == 2)
                {
                    Console.Clear();
                    for (int i = 0; i < ss.storages.Count; i++)
                    {
                        Console.Write("{0}.", i);
                        ss.storages[i].printInfo();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Свободного места: {0}\n", ss.storages[i].getFreeCapacity());
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Укажите объем информации для копирования");
                    Console.ForegroundColor = ConsoleColor.White;
                    double volume;
                    bool test = Double.TryParse(Console.ReadLine(), out volume);
                    if (test == false)
                    {
                        while (test == false)
                        {
                            Console.WriteLine("Неверно введены данные. Попробуйте еще раз:");
                            test = Double.TryParse(Console.ReadLine(), out volume);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Выберите устройство для копирования:");
                    Console.ForegroundColor = ConsoleColor.White;

                    int index;
                    bool test_ = Int32.TryParse(Console.ReadLine(), out index);
                    if (test_ == false)
                    {
                        while (test_ == false)
                        {
                            Console.WriteLine("Неверно введены данные. Попробуйте еще раз:");
                            test_ = Int32.TryParse(Console.ReadLine(), out index);
                        }
                    }
                    try
                    {
                        ss.storages[index].copyInfo(volume);
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    finally
                    {
                        Console.ReadKey();
                        Console.Clear();
                        MainMenu(ss);
                    }

                }
                else if (choice == 3)
                {
                    Console.Clear();
                    for (int i = 0; i < ss.storages.Count; i++)
                    {
                        Console.Write("{0}.", i);
                        ss.storages[i].printInfo();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Свободного места: {0}\n", ss.storages[i].getFreeCapacity());
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Укажите объем информации для копирования");
                    Console.ForegroundColor = ConsoleColor.White;
                    double volume;
                    bool test = Double.TryParse(Console.ReadLine(), out volume);
                    if (test == false)
                    {
                        while (test == false)
                        {
                            Console.WriteLine("Неверно введены данные. Попробуйте еще раз:");
                            test = Double.TryParse(Console.ReadLine(), out volume);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Выберите устройство для копирования:");
                    Console.ForegroundColor = ConsoleColor.White;
                    int index;
                    bool test_ = Int32.TryParse(Console.ReadLine(), out index);
                    if (test_ == false)
                    {
                        while (test_ == false)
                        {
                            Console.WriteLine("Неверно введены данные. Попробуйте еще раз:");
                            test_ = Int32.TryParse(Console.ReadLine(), out index);
                        }
                    }
                    try
                    {
                        Console.WriteLine("Для копирования {0} Гб нужно {1} носителей указанного типа",
                            volume, Math.Ceiling(volume / ss.storages[index].getCapacity()));
                        TimeSpan time = ss.storages[index].getCopyTime(volume);
                        Console.WriteLine("Расчетное время:\nМинут: {0}\nСекунд: {1}\nМиллисекунд: {2}",
                                time.TotalMinutes, time.TotalSeconds, time.TotalMilliseconds);
                    }
                    catch (Exception ex)
                    {                        
                        Console.WriteLine(ex.Message);
                        
                    }
                    finally
                    {
                        Console.ReadKey();
                        Console.Clear();
                        MainMenu(ss);
                    }
                }
                else if (choice == 4)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Укажите объем информации для копирования");
                    Console.ForegroundColor = ConsoleColor.White;
                    double volume;
                    bool test = Double.TryParse(Console.ReadLine(), out volume);
                    if (test == false)
                    {
                        while (test == false)
                        {
                            Console.WriteLine("Неверно введены данные. Попробуйте еще раз:");
                            test = Double.TryParse(Console.ReadLine(), out volume);
                        }
                    }
                    Console.WriteLine("Для копирования {0} Гб:", volume);

                    for (int i = 0; i < ss.storages.Count; i++)
                    {
                        Console.Write(ss.storages[i].getInfo());
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(" {0} устройств", Math.Ceiling(volume / ss.storages[i].getCapacity()));
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.ReadKey();
                    Console.Clear();
                    MainMenu(ss);


                }
                else if (choice == 5)
                    return;
                else
                {
                    Console.WriteLine("Неправильно введены данные");
                    Console.ReadKey();
                    Console.Clear();
                    MainMenu(ss);
                }
            }
            else
            {
                Console.WriteLine("Неправильно введены данные");
                Console.ReadKey();
                Console.Clear();
                MainMenu(ss);
            }
        }
    }

}

