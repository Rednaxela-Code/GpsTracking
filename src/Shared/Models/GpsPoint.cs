using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class GpsPoint : DataEntity
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public int SatelliteCount { get; set; }
        public DateTime Timestamp { get; set; }

        public GpsPoint()
        {
        }

        public GpsPoint(double latitude, double longitude, double altitude, int satelliteCount, DateTime timestamp)
        {
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
            SatelliteCount = satelliteCount;
            Timestamp = timestamp;
        }

        public override string ToString()
        {
            return $"Id : {Id}, Latitude: {Latitude}, Longitude: {Longitude}, Altitude: {Altitude}, Satellites: {SatelliteCount}, Timestamp: {Timestamp}";
        }
    }
}
