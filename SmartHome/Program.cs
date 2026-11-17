using System;
using SmartHome.Models;

namespace SmartHome
{
    class Program
    {
        static void Main()
        {
            SmartDevice[] devices =
            {
            new SmartLight("Лампа в гостиной", 80),
            new Thermostat("Термостат", 22.5),
            new SmartSpeaker("Колонка", 30)
            };

            foreach (SmartDevice device in devices)
            {
                device.TurnOn();
                Console.WriteLine(device.GetStatus());
                Console.WriteLine();
            }
        }
    }
}