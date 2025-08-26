using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SensorSimulator
{
    public class Sensor
    {
        public string sensorName { get; set; }
        public bool isRunning { get; set; }
        public string sensorColor { get; set; }

        public Sensor(string sensorName) {
            this.sensorName = sensorName;
            this.sensorColor = "gray";
            this.isRunning = false;
        }
    }
}
