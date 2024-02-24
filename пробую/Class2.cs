using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace пробую
{
    public class GeoCoordinatesArray
    {
        private GeoCoordinates[] arr; // одномерный массив элементов типа GeoCoordinates
        private static int objectsCounter = 0;
        public static int ArraysCounter = 0;
        public GeoCoordinatesArray()
        {
            arr = new GeoCoordinates[0];
            arraysCounter++;
        }

        public GeoCoordinatesArray(int size) //создание массива с заполнением рандомом
        {
            arr = new GeoCoordinates[size];
            arraysCounter++;
            objectsCounter += size;
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                arr[i] = new GeoCoordinates();
                arr[i].Latitude = random.Next(-90,90);
                arr[i].Longitude = random.Next(-180,180);

            }
        }
 
        public int Length
        {
            get=>arr.Length;
        }
        public static int arraysCounter { get; set; }

        public GeoCoordinatesArray(GeoCoordinatesArray other) //конструктор копир
        {
            arr = new GeoCoordinates[other.Length];
            for (int i = 0; i < other.Length; i++)
            {
                arr[i] = new GeoCoordinates(other.arr[i]);
            }
        }


        public GeoCoordinatesArray(int length, int[] lat, int[] lont) 
        {
            arr = new GeoCoordinates[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = new GeoCoordinates(lat[i], lont[i]);
            }
            arraysCounter++;
        }
        public void Print()
        {
            foreach (GeoCoordinates geog in arr) 
                Console.WriteLine($"широта: {geog.Latitude}, долгота:{geog.Longitude}");
        }
      
        public GeoCoordinates this[int index] //индексатор
        {
            get
            {
                if (index >=0 && index < arr.Length)
                    return arr[index];
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < arr.Length)
                    arr[index] = value;
                else Console.WriteLine("Выход за границу");
            }
        }
        public static GeoCoordinates GetNearestPoint(GeoCoordinatesArray arr) //наиближайшая точка к 0;0
        {
            double minimalRange = 999999999;
            int num = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                double range = Math.Pow(arr[i].Longitude,2) + Math.Pow(arr[i].Latitude,2);
                range = Math.Sqrt(range);
                if (minimalRange > range)
                {
                    minimalRange = range;
                    num = i;
                }
            }
            return arr[num];
        }
       

    }
}
