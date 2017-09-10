using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string abAsString = null;
            try
            {
                using (StreamReader reader = new StreamReader(File.Open("INPUT.txt", FileMode.Open)))
                {
                    abAsString += reader.ReadToEnd();
                }
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            string[] aAndBAsString = abAsString.Split(' ');
            int numA, numB;
            bool result = Int32.TryParse(aAndBAsString[0], out numA);
            if (!result)
            {
                Console.WriteLine("Attempted conversion of '{0}' failed.",
                               aAndBAsString[0] == null ? "<null>" : aAndBAsString[0]);
            }

            result = Int32.TryParse(aAndBAsString[1], out numB);
            if (!result)
            {
                Console.WriteLine("Attempted conversion of '{0}' failed.",
                               aAndBAsString[1] == null ? "<null>" : aAndBAsString[1]);
            }

            int num = numA + numB;

            try
            {
                using (StreamWriter numbersWriter = new StreamWriter(File.Open("OUTPUT.txt", FileMode.OpenOrCreate)))
                {
                    numbersWriter.Write(num);
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
