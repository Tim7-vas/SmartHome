using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Models
{
    public class SmartLight : SmartDevice
    {
        public int Brightness { get; private set; }

        public SmartLight(string name, int brightness) : base(name)
        {
            Brightness = brightness;
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($" Яркость: {Brightness}%");
        }

        public override string GetStatus()
        {
            string state = IsOn ? "вкл" : "выкл";
            return $"{Name} — {state}, яркость {Brightness}%";
        }

        public void SetBrightness(int level)
        {
            if (level < 0) level = 0;
            if (level > 100) level = 100;
            Brightness = level;
            Console.WriteLine($"{Name}: яркость установлена на {Brightness}%");
        }

        public void SetBrightness(string preset)
        {
            if (preset == "night") Brightness = 15;
            else if (preset == "evening") Brightness = 40;
            else if (preset == "day") Brightness = 100;
            else
            {
                Console.WriteLine($"{Name}: неизвестный режим '{preset}'");
                return;
            }
            Console.WriteLine($"{Name}: режим '{preset}' (яркость {Brightness}%)");
        }

        public override double GetPowerUsage()
        {
            return IsOn ? Math.Round(15.0 * (Brightness / 100.0), 1) : 0.0;
        }
    }
}