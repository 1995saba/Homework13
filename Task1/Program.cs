using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string arrayFibonacciAsString=null;

            try
            {
                using(StreamReader numbersReader = new StreamReader(File.Open("1.txt", FileMode.Open)))
                {
                    arrayFibonacciAsString += numbersReader.ReadToEnd();
                }
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            string[] numbersAsString = arrayFibonacciAsString.Split(' ');
            int size = numbersAsString.Length;
            int[] arrayFibonacci = new int[size];
            for(int i = 0; i < size; i++)
            {
                bool result = Int32.TryParse(numbersAsString[i], out arrayFibonacci[i]);
                if (!result)
                {
                    Console.WriteLine("Attempted conversion of '{0}' failed.",
                                   numbersAsString[i] == null ? "<null>" : numbersAsString[i]);
                }
            }

            int[] arrayFibonacciSecondPart = new int[size];
            arrayFibonacciSecondPart[0] = arrayFibonacci[size - 1] + arrayFibonacci[size - 2];
            arrayFibonacciSecondPart[1] = arrayFibonacciSecondPart[0] + arrayFibonacci[size - 1];

            for(int i = 2; i < size; i++)
            {
                arrayFibonacciSecondPart[i] = arrayFibonacciSecondPart[i - 1] + arrayFibonacciSecondPart[i - 2];
            }

            try
            {
                using (StreamWriter numbersWriter = new StreamWriter(File.Open("1.txt", FileMode.Append)))
                {
                    for(int i = 0; i < size; i++)
                    {
                        numbersWriter.Write(" ");
                        numbersWriter.Write(arrayFibonacciSecondPart[i]);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
