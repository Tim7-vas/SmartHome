using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Models
{
    public class SmartKettle : SmartDevice
    {
        public int WaterTemperature { get; private set; }

        public SmartKettle(string name, int waterTemperature) : base(name)
        {
            WaterTemperature = waterTemperature;
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($" Начинает нагрев до {WaterTemperature}°C");
        }

        public override string GetStatus()
        {
            string state = IsOn ? "вкл" : "выкл";
            return $"{Name} — {state}, целевая температура {WaterTemperature}°C";
        }

        public override double GetPowerUsage()
        {
            return IsOn ? 2000.0 : 0.0;
        }
    }
}