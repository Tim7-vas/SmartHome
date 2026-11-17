using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Models
{
    public class RobotVacuum : SmartDevice
    {
        public int BatteryLevel { get; private set; }

        public RobotVacuum(string name, int batteryLevel) : base(name)
        {
            BatteryLevel = batteryLevel;
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($" Уровень заряда: {BatteryLevel}%. Начинает уборку");
        }

        public override void TurnOff()
        {
            base.TurnOff();
            Console.WriteLine(" Возвращается на базу");
        }

        public override string GetStatus()
        {
            string state = IsOn ? "вкл" : "выкл";
            return $"{Name} — {state}, заряд {BatteryLevel}%";
        }

        public override double GetPowerUsage()
        {
            return IsOn ? 65.0 : 0.0;
        }
    }
}