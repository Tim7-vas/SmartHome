using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Models
{
    public sealed class SecurityCamera : SmartDevice
    {
        public bool IsRecording { get; private set; }

        public SecurityCamera(string name) : base(name)
        {
            IsRecording = false;
        }

        public override void TurnOn()
        {
            base.TurnOn();
            IsRecording = true;
            Console.WriteLine(" Начинает запись видео");
        }

        public override void TurnOff()
        {
            base.TurnOff();
            IsRecording = false;
            Console.WriteLine(" Запись видео остановлена");
        }

        public override string GetStatus()
        {
            string state = IsOn ? "вкл" : "выкл";
            string recordState = IsRecording ? "запись идёт" : "ожидание";
            return $"{Name} — {state}, режим: {recordState}";
        }
    }
}