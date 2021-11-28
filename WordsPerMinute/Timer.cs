using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsPerMinute
{
    public class Timer
    {

        private DateTime _startTime = new DateTime();
        private DateTime _stopTime = new DateTime();
        private bool _timerStarted = false;

        public Timer()
        {

        }

        public void StartTimer()
        {

            _startTime = DateTime.Now;
            _timerStarted = true;
        }

        public void StopTimer()
        {
            _stopTime = DateTime.Now;
        }
        public double GetDuration()
        {
            return (_stopTime - _startTime).TotalSeconds;
        }

    }
}
