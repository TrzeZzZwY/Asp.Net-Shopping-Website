using AspNetProjekt.Services.interfaces;

namespace AspNetProjekt.Services
{
    public class DefaultClock : IClockProvider
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
        public DateTime Epoch()
        {
            return DateTime.UnixEpoch;
        }
    }
}
