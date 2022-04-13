using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorTDD
{
    public class StringCalculator
    {
        private static List<char> delims = new List<char>() { ',', '\n' };
        static void Main(string[] args)
        {
            Console.WriteLine(Add("//;\n3;5;7;8;0"));
            Console.ReadKey();
        }

        public static int Add(string numbers)
        {
            if(IsEmptyString(numbers) == 0)
            {
                return 0;
            }
            AddNewDelimiters(ref numbers);
            return ExtractNumbers(numbers);
        }

        //Checking if the string is empty or not.
        public static int IsEmptyString(string numbers)
        {
            if (numbers.Equals(""))
            {
                return 0;
            }
            return 1;
        }

        //Extract only numbers eliminate all delimiters.
        public static int ExtractNumbers(string numbers)
        {
            int count = 0;
            string[] arr = numbers.Split(delims.ToArray());
            foreach(string s in arr)
            {
                IsNegativeNumber(Convert.ToInt32(s));
                count += Convert.ToInt32(s);
            }
            return count;
        }

        //Handle new delimiters and add it to the list.
        public static void AddNewDelimiters(ref string numbers)
        {
            if(numbers[2] == ',' || numbers[2] == '\n')
            {
                throw new Exception("Delimiter already Exists");
            }
            if(numbers[0] == '/' && numbers[1] == '/' && numbers[3] == '\n')
            {
                delims.Add(numbers[2]);
                numbers = numbers.Remove(0, 4);
            }
        }

        //Handle negative numbers.
        public static void IsNegativeNumber(int num)
        {
            if(num<0)
            {
                throw new Exception("Negatives not allowed.");
            }
        }
    }
}
