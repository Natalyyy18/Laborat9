using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace пробую
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            GeoCoordinates geo = new GeoCoordinates();
            geo.Latitude = 90;
            geo.Longitude = 180;
            GeoCoordinates geo1 = new GeoCoordinates();
            geo1.Latitude = 89;
            geo1.Longitude = 179;
            GeoCoordinates geo2 = new GeoCoordinates();
            geo2.Latitude = 5;
            geo2.Longitude = -18;
            GeoCoordinates geo3 = new GeoCoordinates();
            geo3.Latitude = 5;
            geo3.Longitude = 183;
            geo.PrintInfo();
            geo1.PrintInfo();
            double dist = GeoCoordinates.CalculateDistanceStatic(geo, geo1);
            Console.WriteLine("Дистанция между точками 1 и 2.");
            Console.WriteLine(dist);
            Console.WriteLine("Количество созданных в программе объектов.");
            Console.WriteLine(GeoCoordinates.GetCount);
            geo1++;
            geo1.PrintInfo();
            geo = -geo;
            geo.PrintInfo();
            Console.WriteLine("Явное приведение типа bool");
            if ((bool)geo)
            {
                Console.WriteLine("Точка располагается на экваторе");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Точка не на экваторе");
                Console.WriteLine();
            }
            Console.WriteLine("Неявное приведение типа string");
            string geogr = geo;
            Console.WriteLine(geogr);
            Console.WriteLine("Бинарная операция ==");
            if (geo2==geo3)
            {
                Console.WriteLine("На одной параллели");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Не на одной параллели");
                Console.WriteLine();
            }
            Console.WriteLine("Бинарная операция !=");
            if (geo2 != geo3)
            {
                Console.WriteLine("На разных меридианах");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("На одном меридиане");
                Console.WriteLine();
            }
            Console.WriteLine("1 заполнение рандомом");
            GeoCoordinatesArray persarr1 = new GeoCoordinatesArray(3);
            persarr1.Print();
            Console.WriteLine("польз ввод");
            int length;
            Console.WriteLine("введите количество гео точек");
            bool isConvert = int.TryParse(Console.ReadLine(), out length);
            if (!isConvert)
                Console.WriteLine("Неверный формат");
            int[] lat = EnterLatitude(length);
            int[] lont = EnterLongitude(length);
            Console.WriteLine("2 пользовательский");
            GeoCoordinatesArray persarr2 = new GeoCoordinatesArray(length,lat,lont);
            persarr2.Print();
            Console.WriteLine("3 Без параметров");
            GeoCoordinatesArray persarr3 = new GeoCoordinatesArray();
            persarr3.Print();
            Console.WriteLine();
            Console.WriteLine("4 Копи");
            GeoCoordinatesArray persarr4 = new GeoCoordinatesArray(persarr2);
            persarr4.Print();
            //Console.WriteLine("Ближ точка");
            //GeoCoordinatesArray arr = new GeoCoordinatesArray(5);
            //GeoCoordinates coordinates = GeoCoordinatesArray.GetNearestPoint(arr);
            //coordinates.PrintInfo();
            Console.WriteLine("Ближ точка");
            GeoCoordinatesArray arr = new GeoCoordinatesArray(5);
            GeoCoordinates coordinates = GeoCoordinatesArray.GetNearestPoint(persarr2);
            coordinates.PrintInfo();
            Console.WriteLine("Создается массив для работы с индексатором:");
            GeoCoordinatesArray persarrIndex = new GeoCoordinatesArray(5);
            persarrIndex.Print();
            Console.WriteLine("Индексатор присвоен ");
            persarrIndex[0] = new GeoCoordinates(14, 67);
            persarrIndex.Print();
            persarrIndex[8] = new GeoCoordinates(14,67);
            Console.WriteLine($"Точка с индексом 2 - {persarrIndex[2]}");
            Console.WriteLine($"Точка с индексом 9 - {persarrIndex[9]}");
            //GeoCoordinatesArray arr = new GeoCoordinatesArray(5);
            //GeoCoordinates coordinates = GeoCoordinatesArray.GetNearestPoint(arr);
            //coordinates.PrintInfo();


        }
        static int[] EnterLatitude(int length)
        {
            int[] lat = new int[length];
            for (int i = 0; i < lat.Length; i++)
            {
                Console.WriteLine($"Введите широту: {i + 1}");
                lat[i] = int.Parse(Console.ReadLine());
            }
            return lat;
        }
        static int[] EnterLongitude(int length)
        {
            int[] lont = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"Введите долготу: {i + 1}");
                lont[i] = int.Parse(Console.ReadLine());
            }
            return lont;
        }
        
    }
        
}

