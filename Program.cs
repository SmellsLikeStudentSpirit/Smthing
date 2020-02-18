using System;

namespace labavmsis1
{

    class Translate
    {
        public static int From_9_to_10(int num9)
        {
            double foo= 0;
            int bar = 0;
            int r = Dim(num9, 9);
            for(int i=1;i<r+1;i++)
            {
                if(i!=r)
                {
                    bar = num9 / ((int)Math.Pow(10,r-i)) % ((int)Math.Pow(10,i));
                }
                else
                {
                    bar = num9 % 10;
                }
                if(bar>8)
                {
                    throw new ArgumentOutOfRangeException();
                }
                foo += bar * Math.Pow(9,r-i);
            }
            int Result = Convert.ToInt32(foo);
            return Result;
        }

        public static int From_10_to_9(int num10)
        {
            int result = 0;
            int r = Dim(num10, 9);
            int foo = (num10/9)* 10 + num10 % 9;
            result = foo;

            return result;
        }

        static int Dim(int numS,int S)
        {
            int result = 0;
            while (numS!=0)
            {
                numS = numS / S;
                result++;
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Menu:
            Console.WriteLine("Выберите что хотите сделать:(введите подходящий пункт меню)");
            Console.WriteLine("1)Перевод из 9 -> 10 систему счисления");
            Console.WriteLine("2)Перевод из 10-> 9  систему счисления");
            int k = int.Parse(Console.ReadLine());
            int num;
            switch (k)
            {
                case 1:
                    Console.WriteLine("Input:");
                    Input9cc:
                    try
                    {
                        num = int.Parse(Console.ReadLine());
                        Console.WriteLine("Число " + num + " в 10-ричной\n" + Translate.From_9_to_10(num));
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Напишите число пожалуйста в 9-ричной сс");
                        goto Input9cc;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Введите целое число в 9-ричной сс");
                        goto Input9cc;
                    }
                    break;
                case 2:
                    Console.WriteLine("Input:");
                    Input10cc:
                    try
                    {
                        num = int.Parse(Console.ReadLine());
                        Console.WriteLine("Число "+num+" в 9-ричной\n"+Translate.From_10_to_9(num));
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Введите целое число");
                        goto Input10cc;
                    }
                    break;
            }
            Console.WriteLine("Хотите продолжить(y/n)?");
            if(Console.ReadLine()=="y")
            {
                goto Menu;
            }
            Console.ReadKey();
        }
    }

}
