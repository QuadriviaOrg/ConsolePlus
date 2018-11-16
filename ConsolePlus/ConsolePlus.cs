using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Quadrivia
{
    public static class ConsolePlus
    {
        private const string Invalid = "Invalid input";

        //Requests the user to enter a number via the console
        public static int ReadInteger(string prompt, int min = 0, int max = int.MaxValue)
        {
            int value = 0;
            while (true)
            {
                Console.Write(prompt);
                try
                {
                     value = Convert.ToInt32(Console.ReadLine());
                    if (value >= min && value <= max) break;
                }
                catch (Exception)
                {
                }
                Console.WriteLine(Invalid);
            }
            return value;
        }

        public static int ReadInteger(string prompt, IEnumerable<int> validValues)
        {
            int value = 0;
            while (true)
            {
                Console.Write(prompt);
                try
                {
                    value = Convert.ToInt32(Console.ReadLine());
                    if (validValues.Contains(value)) break;
                }
                catch (Exception) { }
                Console.WriteLine(Invalid);
            }
            return value;
        }

        public static T ReadType<T>(string prompt)
        {
            T value;
            var convertor = TypeDescriptor.GetConverter(typeof(T));
            while (true)
            {
                Console.Write(prompt);
                try
                {
                    string input = Console.ReadLine();
                    value = (T)(convertor.ConvertFromInvariantString(input));
                    break;
                }
                catch (Exception) { }
                Console.WriteLine(Invalid);
            }
            return value;
        }
        //Requests the user to enter a number via the console
        public static T ReadType<T>(string prompt, T min, T max) where T : IComparable
        {
            T value;
            var convertor = TypeDescriptor.GetConverter(typeof(T));
            while (true)
            {
                Console.Write(prompt);
                try
                {
                    string input = Console.ReadLine();
                    value = (T)(convertor.ConvertFromInvariantString(input));                 
                    if (value.CompareTo(min) >=0 && value.CompareTo(max) <= 0) break;
                }
                catch (Exception) {}
                Console.WriteLine(Invalid);
            }
            return value;
        }

        public static T ReadType<T>(string prompt,IList<T> validValues)
        {
            T value;
            var convertor = TypeDescriptor.GetConverter(typeof(T));
            while (true)
            {
                Console.Write(prompt);
                try
                {
                    string input = Console.ReadLine();
                    value = (T)(convertor.ConvertFromInvariantString(input));
                    if (validValues.Contains(value))
                    {
                        break;
                    }
                }
                catch (Exception) { }
                Console.WriteLine(Invalid);
            }
            return value;
        }

        public static string ReadString(string prompt, int minLength = 0, int maxLength = int.MaxValue)
        {
            string value = "";
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    value = Console.ReadLine();
                    if (value.Length >= minLength && value.Length <= maxLength) break;
                }
                catch (Exception) { }
                Console.WriteLine(Invalid);
            }
            return value;
        }

        public static int ReadIndex(string prompt, IList<string> validValues, bool caseSensitive = false, bool ignoreInvalid = true)
        {
            string value = "";
            int index = 0;
            if (!caseSensitive)
            {
                validValues = validValues.Select(v => v.ToUpper()).ToList();
            }
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    value = Console.ReadLine();
                    var value2 = value;
                    if (!caseSensitive)
                    {
                        value2 = value.ToUpper();
                    }
                    if (validValues.Contains(value2))
                    {
                        index = validValues.IndexOf(value2);
                        break;
                    }
                }
                catch (Exception) { }
                Console.WriteLine(Invalid);
            }
            return index;
        }

        public static int ReadCharIndex(string prompt, IList<char> validValues, bool caseSensitive = false)
        {
            Console.Write(prompt);
            int index = 0;
            char value = '\0';
            if (!caseSensitive)
            {
                validValues = validValues.Select(v => Char.ToUpper(v)).ToList();
            }
            while (true)
            {
                    value = Console.ReadKey(true).KeyChar;
                var value2 = value;
                    if (!caseSensitive)
                    {
                        value2 = Char.ToUpper(value);
                    }
                if (validValues.Contains(value2))
                {
                    index = validValues.IndexOf(value2);
                    break;
                }
            }
            Console.WriteLine(value);
            return index;
        }

        public static void WriteList<T>(IEnumerable<T> list, string spacer = ", ")
        {
            if (list.Count() == 0) return;
            foreach (var item in list.Take(list.Count() - 1))
            {
                Console.Write(item.ToString() + spacer);
            }
            Console.Write(list.Last());
            Console.WriteLine();
        }

        public static void WriteValues<T>(params T[] list) 
        {
            WriteList(list);
        }

    }
}
