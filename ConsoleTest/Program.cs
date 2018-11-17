using System;
namespace Quadrivia
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = ConsolePlus.ReadType("Int in range 3-7: ", 3, 7);
            Console.WriteLine(a);
            float b = ConsolePlus.ReadType("Float in range 3-7: ", 3.0f, 7.0f);
            Console.WriteLine(b);
            decimal c = ConsolePlus.ReadType("Decimal in range 3-7: ", 3.0m, 7.0m);
            Console.WriteLine(c);
            double d = ConsolePlus.ReadType("Double in range 3-7: ", 3.0, 7.0);
            Console.WriteLine(d);
            int e = ConsolePlus.ReadType("Int from 4,5,9: ", new int[] { 4, 5, 9 });
            Console.WriteLine(e);
            string f = ConsolePlus.ReadString("String of 3-7 chars: ", 3, 7);
            Console.WriteLine(f);
            int g = ConsolePlus.ReadIndex("String from Foo, Bar (case insensitive): ", new string[] { "Foo", "Bar" });
            Console.WriteLine(g);
            int h = ConsolePlus.ReadIndex("String from Foo, Bar (case sensitive): ", new string[] { "Foo", "Bar" }, true);
            Console.WriteLine(h);
            char i = ConsolePlus.ReadChar("Char from Y, N (case insensitive): ", new char[] { 'Y', 'N' }, false);
            Console.WriteLine(i);
            char j = ConsolePlus.ReadChar("Char from Y, N (case sensitive): ", new char[] { 'Y', 'N' }, true);
            Console.WriteLine(j);

            Console.WriteLine("Testing output functions");
            ConsolePlus.WriteList(new int[] { 3, 1, 4, 1, 5, 9 });
            ConsolePlus.WriteList(new int[] { 3, 1, 4, 1, 5, 9 }, "-");
            ConsolePlus.WriteList(new int[] { 3, 1, 4, 1, 5, 9 }, "");
            ConsolePlus.WriteValues(3, 1, 4, 1, 5, 9);
            ConsolePlus.WriteValues("Hello","World");

            Console.ReadKey();
        }
    }
}
