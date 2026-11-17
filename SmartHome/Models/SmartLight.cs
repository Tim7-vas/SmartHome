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
            Console.WriteLine($"Яркость: {Brightness}%");
        }

        public override string GetStatus()
        {
            string state = IsOn ? "вкл" : "выкл";
            return $"{Name} — {state}, яркость {Brightness}%";
        }
    }
}