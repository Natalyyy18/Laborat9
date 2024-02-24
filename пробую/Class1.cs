using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace пробую
{
    public class GeoCoordinates
    {
        private double latitude;
        private double longitude;

        public double Latitude //для задания ограничений широты
        {
            get { return latitude; }

            set
            {
                if ((value >= -90) && (value <= 90))
                {

                    latitude = value;
                }
            }
        }

        public double Longitude //для задания ограничений долготы
        {
            get { return longitude; }
            set
            {
                if ((value >= -180) && (value <= 180))
                {

                    longitude = value;
                }
            }

        }
        private static int count = 0; 
        public GeoCoordinates()
        {
            latitude = 0;
            longitude = 0;
            count++;
        }

        public GeoCoordinates(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            count++;
        }

        public GeoCoordinates(GeoCoordinates otherGeoCoordinates) //копирование
        {
            latitude = otherGeoCoordinates.latitude;
            longitude = otherGeoCoordinates.longitude;
            count++;
        }
        public double CalculateDistance(GeoCoordinates geo, GeoCoordinates geo1) //для нахождения расстояния между точками
        {

            return ((Math.Sin((geo1.latitude - geo.latitude) / 2) * Math.Sin((geo1.latitude - geo.latitude) / 2)) + (Math.Cos(geo1.latitude) * Math.Cos(geo.latitude) * (Math.Sin((geo1.longitude - geo.longitude) / 2) * Math.Sin((geo1.longitude - geo.longitude) / 2))));
        }

        public static double CalculateDistanceStatic(GeoCoordinates geo, GeoCoordinates geo1) //static
        {
            return ((Math.Sin((geo1.latitude - geo.latitude) / 2) * Math.Sin((geo1.latitude - geo.latitude) / 2)) + (Math.Cos(geo1.latitude) * Math.Cos(geo.latitude) * (Math.Sin((geo1.longitude - geo.longitude) / 2) * Math.Sin((geo1.longitude - geo.longitude) / 2))));
        }
        public static int GetCount => count;
        public void PrintInfo() //для показа точки
        {
            Console.WriteLine($"Широта: {latitude}, Долгота: {longitude}");
        }

        public static GeoCoordinates operator ++(GeoCoordinates geo) //увеличение широты и долготы объекта на 0,01
        {
            GeoCoordinates geoChanged = new GeoCoordinates();
            geoChanged.Latitude = geo.Latitude+0.01;
            geoChanged.Longitude = geo.Longitude+0.01;
            return geoChanged;

        }
        public static GeoCoordinates operator -(GeoCoordinates geo) //широта и долгота точки меняет знак значения на противоположный, абсолютное значение не меняется.
        {
            GeoCoordinates geoChanged = new GeoCoordinates();
            geoChanged.Latitude = geo.Latitude * (-1);
            geoChanged.Longitude = geo.Longitude * (-1);
            return geoChanged;
        }
        public static explicit operator bool (GeoCoordinates geo) //результатом является true, если точка располагается на экваторе, иначе – false;
        {
            if (geo.latitude == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static  implicit operator string (GeoCoordinates geo) // результатом является определение типа долготы точки: «Восточная долгота» / «Западная долгота» / «Нулевой меридиан»
        {
            if (geo.longitude % 180 == 0)
            {
                return "Нулевой меридиан";
            }
            else
            {
                if (0 <= geo.longitude & geo.longitude <= 180)
                {
                    return "Восточная";
                }
                else
                {
                    return "Западная";
                }
            }
        }
        public static bool operator ==(GeoCoordinates geo, GeoCoordinates geo1) //результатом является true, если обе точки находятся на одной параллели, и false – в противном случае.
        {
            if (geo.latitude == geo1.latitude)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(GeoCoordinates geo, GeoCoordinates geo1) //результатом является true, если точки находятся на разных меридианах, и false – в противном случае
        {
            if (geo.longitude != geo1.longitude)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is GeoCoordinates b)
                return this.Latitude == b.Latitude && this.Longitude == b.Longitude;
            return false;
        }

        public double CalculateDistance(GeoCoordinates geo2)
        {
            throw new NotImplementedException();
        }
    }


    
}
