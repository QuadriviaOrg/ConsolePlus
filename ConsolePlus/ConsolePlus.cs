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

        /// <summary>
        /// Prompt the user to enter an integer number optionally specifying min and max acceptable values.
        /// </summary>,
        /// <returns>The integer entered</returns>
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

        /// <summary>
        /// Prompt the user to enter an integer number that must be one of a specified list of valid values.
        /// </summary>
        /// <returns>The integer entered</returns>
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

        /// <summary>
        /// Prompt the user to enter a value, which must be capable of being converted to the type specified. 
        /// </summary>
        /// <returns>The value entered, converted to the specified type.</returns>
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
        /// <summary>
        /// Prompt the user to enter a value, which must be capable of being converted to the type specified,
        /// and fall within the min/max range specified.  The type specified must be a 'comparable' type.
        /// </summary>
        /// <returns>The value entered, converted to the specified type.</returns>
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
                    if (value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0) break;
                }
                catch (Exception) { }
                Console.WriteLine(Invalid);
            }
            return value;
        }

        /// <summary>
        /// Prompt the user to enter a value, which must be one of a specified list of valid values.
        /// </summary>
        /// <returns>The value entered, converted to the specified type.</returns>
        public static T ReadType<T>(string prompt, IList<T> validValues)
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

        /// <summary>
        /// Prompt the user to enter a string, which must satisfy the min- and max-length constraints, if specified.
        /// </summary>
        /// <returns>The string entered</returns>
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

        /// <summary>
        /// Prompt the user to enter a string, which must be one of a specified list of valid values.
        /// By default, the match will be case-insentive.
        /// Removes any leading/trailing spaces from the user's entry before matching.
        /// </summary>
        /// <param name="caseSensitive">Set to true to enforce case-matching.</param>
        /// <returns>The index of the matching string within the validValues.</returns>
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
                    value = Console.ReadLine().Trim();
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

        /// <summary>
        /// Prompt the user to hit a single key, which must be one of a specified list of valid (char) values.
        /// System ignores any non-matching keys until a match is made.
        /// </summary>
        /// <param name="caseSensitive">Set to true to enforce case-matching. If not specified defaults to false</param>
        /// <returns>Return the char value of the key entered</returns>
        public static char ReadChar(string prompt, IList<char> validValues, bool caseSensitive = false)
        {
            Console.Write(prompt);
            char value = '\0';
            while (true)
            {
                value = Console.ReadKey(true).KeyChar;
                if (caseSensitive && validValues.Contains(value))
                {
                    break;
                }
                if (!caseSensitive)
                {
                    value = validValues.FirstOrDefault(c => Char.ToUpper(value) == Char.ToUpper(c));
                    if (value != '\0') break;
                }
            }
            Console.WriteLine(value);
            return value;
        }

        /// <summary>
        /// Write values of provided any IEnumerable type (e.g. List or Array), separated by the specified spacer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="spacer">If not specified, defaults to ", "</param>
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

        /// Write multiple values, each separated by comma and space.
        public static void WriteValues<T>(params T[] list)
        {
            WriteList(list);
        }

    }
}
