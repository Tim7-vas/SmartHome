using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Models
{
    public class Thermostat : SmartDevice
    {
        public double TargetTemperature { get; private set; }

        public Thermostat(string name, double temperature) : base(name)
        {
            TargetTemperature = temperature;
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($" Целевая температура: {TargetTemperature}°C");
        }

        public override string GetStatus()
        {
            string state = IsOn ? "вкл" : "выкл";
            return $"{Name} — {state}, цель {TargetTemperature}°C";
        }

        public void SetTemperature(double temp)
        {
            TargetTemperature = temp;
            Console.WriteLine($"{Name}: целевая температура {TargetTemperature}°C");
        }

        public void SetTemperature(double dayTemp, double nightTemp)
        {
            TargetTemperature = dayTemp;
            Console.WriteLine($"{Name}: дневной режим {dayTemp}°C, ночной режим {nightTemp}°C");
        }

        public override double GetPowerUsage()
        {
            return IsOn ? 1500.0 : 0.0;
        }
    }
}