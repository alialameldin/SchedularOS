using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class processINFO
    {
        public int index;
        public int time;//burst time 
        public int rtime;//remaing time
        public int ATime;//Arrival Time
        public int startTime;
        public int departureTime;
        public int priority;
        public static processINFO deepCopy(processINFO p)
        {
            processINFO t = new processINFO();
            t.index = p.index;
            t.rtime = p.rtime;
            t.ATime = p.ATime;
            t.time = p.time;
            t.priority = p.priority;
            t.departureTime = p.departureTime;
            return t;
        }

    }
}
