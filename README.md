# ConsolePlus
Functions to facilitate reading and writing values on the Console.  

Example usage:

using Quadrivia;
 
int a = ConsolePlus.ReadType("Int in range 3-7: ", 3, 7);

float b = ConsolePlus.ReadType("Float in range 3-7: ", 3.0f, 7.0f);

decimal c = ConsolePlus.ReadType("Decimal in range 3-7: ", 3.0m, 7.0m);

double d = ConsolePlus.ReadType("Double in range 3-7: ", 3.0, 7.0);

int e = ConsolePlus.ReadType("Int from 4,5,9: ", new int[] { 4, 5, 9 });

string f = ConsolePlus.ReadString("String of 3-7 chars: ", 3, 7);

int g = ConsolePlus.ReadIndex("String from Foo, Bar (case insensitive): ", new string[] { "Foo", "Bar" });

int h = ConsolePlus.ReadIndex("String from Foo, Bar (case sensitive): ", new string[] { "Foo", "Bar" }, true);

char i = ConsolePlus.ReadChar("Char from Y, N (case insensitive): ", new char[] { 'Y', 'N' }, false);

char j = ConsolePlus.ReadChar("Char from Y, N (case sensitive): ", new char[] { 'Y', 'N' }, true);

Console.WriteLine("Testing output functions");

ConsolePlus.WriteList(new int[] { 3, 1, 4, 1, 5, 9 });

ConsolePlus.WriteList(new int[] { 3, 1, 4, 1, 5, 9 }, "-");

ConsolePlus.WriteList(new int[] { 3, 1, 4, 1, 5, 9 }, "");

ConsolePlus.WriteValues(3, 1, 4, 1, 5, 9);

ConsolePlus.WriteValues("Hello","World");
