using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //冒泡排序(降序)
            int[] a = { 6, 2, 8, 54, 3, 0, 9 };
            for(int i=0;i<a.Length;i++)
            {
                for(int j=0;j<a.Length-1-i;j++)
                {
                    if (a[j]<a[j+1])
                    {
                        int temp = a[j+1];
                        a[j+1]=a[j];
                        a[j]=temp;
                    }
                }
            }
            foreach(int item in a)
            {
                Console.Write(item);
            }
            Console.ReadKey();


            Array.Sort(a);//只变升序
            foreach (int item in a)
            {
                Console.Write(item);
            }
            Console.ReadKey();


            Array.Reverse(a);//只反转
            foreach (int item in a)
            {
                Console.Write(item);
            }
            Console.ReadKey();
        }
    }
}
