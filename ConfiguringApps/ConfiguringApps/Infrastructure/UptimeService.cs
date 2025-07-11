using System.Diagnostics;

namespace ConfiguringApps.Infrastructure
{
    public class UptimeService
    {
        private Stopwatch _stopwatch;
        public UptimeService()
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public long Uptime =>_stopwatch.ElapsedMilliseconds;
    }
}
