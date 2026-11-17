using System;
using System.Text;
using SmartHome.Models;

namespace SmartHome
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            SmartDevice[] devices =
            {
            new SmartLight("Лампа в гостиной", 80),
            new SmartLight("Ночник в спальне", 20),
            new Thermostat("Термостат", 22.5),
            new SmartSpeaker("Умная колонка", 35),
            new SecurityCamera("Камера у входа"),
            new RobotVacuum("Робот-пылесос", 92),
            new SmartKettle("Умный чайник", 95)
            };

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("==========================================");
                Console.WriteLine(" УМНЫЙ ДОМ 2.0 — МЕНЮ");
                Console.WriteLine("==========================================");
                Console.WriteLine("1. Включить все устройства");
                Console.WriteLine("2. Выключить все устройства");
                Console.WriteLine("3. Статус и энергопотребление всех устройств");
                Console.WriteLine("4. Включить/выключить конкретное устройство");
                Console.WriteLine("5. Сценарий: «Ушёл из дома»");
                Console.WriteLine("6. Сценарий: «Ночной режим»");
                Console.WriteLine("7. Демонстрация перегрузки (свет и термостат)");
                Console.WriteLine("0. Выход");
                Console.Write("\nВыберите действие: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("--- Включение всех устройств ---");
                        foreach (SmartDevice device in devices)
                        {
                            device.TurnOn();
                        }
                        break;

                    case "2":
                        Console.WriteLine("--- Выключение всех устройств ---");
                        foreach (SmartDevice device in devices)
                        {
                            device.TurnOff();
                        }
                        break;

                    case "3":
                        ShowAllStatuses(devices);
                        break;

                    case "4":
                        ToggleSingleDevice(devices);
                        break;

                    case "5":
                        ActivateAwayMode(devices);
                        break;

                    case "6":
                        ActivateNightMode(devices);
                        break;

                    case "7":
                        DemoOverloading(devices);
                        break;

                    case "0":
                        isRunning = false;
                        Console.WriteLine("Работа программы завершена.");
                        break;

                    default:
                        Console.WriteLine("Неизвестная команда. Введите число от 0 до 7.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void ShowAllStatuses(SmartDevice[] devices)
        {
            Console.WriteLine("--- Статус устройств и энергопотребление ---");
            double totalPower = 0;

            for (int i = 0; i < devices.Length; i++)
            {
                double power = devices[i].GetPowerUsage();
                totalPower += power;
                Console.WriteLine($"{i + 1}. {devices[i].GetStatus()} | Потребление: {power} Вт");
            }

            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Общее энергопотребление дома: {totalPower} Вт");
        }

        static void ToggleSingleDevice(SmartDevice[] devices)
        {
            ShowAllStatuses(devices);
            Console.Write("\nВведите номер устройства: ");

            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= devices.Length)
            {
                SmartDevice selected = devices[index - 1];
                if (selected.IsOn)
                {
                    selected.TurnOff();
                }
                else
                {
                    selected.TurnOn();
                }
            }
            else
            {
                Console.WriteLine("Некорректный номер устройства.");
            }
        }

        static void ActivateAwayMode(SmartDevice[] devices)
        {
            Console.WriteLine("--- Активация сценария: «Ушёл из дома» ---");
            foreach (SmartDevice device in devices)
            {
                if (device is SecurityCamera)
                {
                    device.TurnOn();
                }
                else
                {
                    device.TurnOff();
                }
            }
        }

        static void ActivateNightMode(SmartDevice[] devices)
        {
            Console.WriteLine("--- Активация сценария: «Ночной режим» ---");
            foreach (SmartDevice device in devices)
            {
                if (device is SmartLight light)
                {
                    light.TurnOn();
                    light.SetBrightness("night");
                }
                else if (device is Thermostat thermostat)
                {
                    thermostat.TurnOn();
                    thermostat.SetTemperature(19.0);
                }
                else if (device is SecurityCamera)
                {
                    device.TurnOn();
                }
                else
                {
                    device.TurnOff();
                }
            }
        }

        static void DemoOverloading(SmartDevice[] devices)
        {
            Console.WriteLine("--- Демонстрация перегрузки методов ---");
            foreach (SmartDevice device in devices)
            {
                if (device is SmartLight light)
                {
                    light.SetBrightness(65);
                    light.SetBrightness("evening");
                }
                else if (device is Thermostat thermostat)
                {
                    thermostat.SetTemperature(23.0);
                    thermostat.SetTemperature(22.0, 18.5);
                }
            }
        }
    }
}