using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        internal interface ICalc 
        {
            int Less(int valueToCompare);
            int Greater(int valueToCompare);
        }
        
        internal class MyArray : ICalc
        {
            int [] _array;
            public MyArray (int [] array) { _array = array; }
            public MyArray() { _array = new int[0]; }
            public MyArray(int arrayLength) //конструктор с рандомайзером
            {
                if (arrayLength < 0) throw new IndexOutOfRangeException("Array length can`t be less than zero!");
                _array = new int[arrayLength];
                Random r = new Random();
                for (int i = 0; i < arrayLength; i++)
                    _array[i] = r.Next(-10,11);
            }
            public int Less(int valueToCompare)
            {
                int temp = 0;
                foreach (var item in _array)
                    if (item < valueToCompare) temp++;
                return temp;
            }
            public int Greater(int valueToCompare)
            {
                int temp = 0;
                foreach (var item in _array)
                    if (item > valueToCompare) temp++;
                return temp;
            }
            public override string ToString()
            {
                StringBuilder temp = new StringBuilder();
                temp.Capacity = _array.Length;

                foreach (var item in _array)
                    temp.Append(item + "; ");
                return Convert.ToString(temp);
            }
        }

        static void Main(string[] args)
        {
            MyArray test = new MyArray(10);
            Console.WriteLine(test);

            //Тест работы интерфейса
            Console.WriteLine("Current array contain next amount of elements less than 0: " + test.Less(0));
            Console.WriteLine("Current array contain next amount of elements greater than 0: " + test.Greater(0));

            //проверка на некорректный вызов конструктора
            try
            {
                MyArray test2 = new MyArray(-10);

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
