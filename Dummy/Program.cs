using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dummy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1
            // double is more precise than float and it can store it
            //float x = 1;
            //double a = x;

            // 2
            //float x = 1f; TRUE
            //decimal x = 1; TRUE
            //double x = 1d; TRUE
            //int x = 1; TRUE
            //byte x = 1; TRUE
            //char x = 'a'; TRUE

            //bool x = true; // FALSE
            //string x = "123"; // FALSE
            //DateTime x = DateTime.Now; FALSE

            //long p = (long)x;

            //short s = 32_767;
            //short s = -32_768;
            //ushort s = 65_535;

            // 3
            //decimal d = 1.2M;
            //Console.WriteLine(d == 1.2M);
            //double b = (float)d;
            //Console.WriteLine(d == (decimal)b);

            // 4
            //double y = 1000001;
            //byte x = (byte)y;
            //Console.WriteLine(x);

            // 5
            //int y = Gender.Male; // FALSE

            // 6
            //char a = 'a';
            //byte b = a; // FALSE
            //char c = b; // FALSE // Više jezički dizajn nego tehnička nužnost — tvorci jezika su hteli da izbegnu situacije gde se broj slučajno tretira kao znak bez namere programera.

            //char a = 'a';
            //int b = a; // TRUE
            //char c = b; // FALSE

            //char a = 'a';
            //long b = a; // TRUE
            //char c = b; // FALSE

            //char a = 'a';
            //short b = a; // FALSE
            //char c = b; // FALSE

            // 7
            //var x = 1.2f; 
            //dynamic y = 3.1m;
            //x = 5.6f; // TRUE
            //x = y; // TRUE
            //x = '7'; // TRUE
            //y = x; // TRUE
            //x = (int)y; // TRUE
            //y = "new Knjiga()"; // TRUE

            // 8
            //double x = 14.123123123F;
            //dynamic y = 3.4m;
            //x = 'a'; // TRUE
            //x = y; // TRUE (but runtime error)
            //y = x; // TRUE

            // 9
            //var x = 1;
            //Gender g = x; // FALSE

            // 10
            //string x;
            //x = x + ""; // FALSE

            // 11
            //int i = 0, j = 2, suma = 10;
            //do
            //{
            //    suma--;
            //    while (j < i + 2)
            //    {
            //        i++;
            //        j++;
            //    }
            //    if (j % 2 == 0)
            //        continue;
            //    suma--;
            //} while (i < 3);
            //Console.WriteLine(--suma);

            // 12
            //Enumeracija e = new Enumeracija(); // 0 - Enumeration can be instantiated
            ////e = e + 1; // This is valid, but e = 1 is invalid
            //switch (++e)
            //{
            //    case Enumeracija.Prolece:
            //        Console.WriteLine("Prolece");
            //        break;
            //    case Enumeracija.Leto:
            //        Console.WriteLine("Leto");
            //        break;
            //    case Enumeracija.Jesen:
            //        Console.WriteLine("Jesen");
            //        break;
            //    case Enumeracija.Zima:
            //        Console.WriteLine("Zima");
            //        break;
            //}

            // 13
            //Operacija op = 0; int x = 10; int y = 2;
            //if (x / y > 1) op++; else op--;
            //switch (op)
            //{
            //    default: op += 1; // Don't have break
            //    case Operacija.Plus: break;
            //    case Operacija.Minus: op -= 2; // Don't have break
            //    case Operacija.Puta:
            //    case Operacija.Podeljeno: op -= 2; break;
            //}
            //Console.WriteLine(op);

            // 14
            //Enumeracija e = new Enumeracija(); // 0
            //e = Enumeracija.Leto; // 3
            //switch (++e) // 4
            //{
            //    case Enumeracija.Prolece:
            //        e--;
            //        break;
            //    case Enumeracija.Leto:
            //        e++;
            //        break;
            //    case Enumeracija.Jesen:
            //    case Enumeracija.Zima:
            //        e = e - 2; // 2
            //        break;
            //}
            //Console.WriteLine(e); // Prolece is printting out, not 2

            // 15
            //Operacija op = 0; // You can just assign 0, for all other numbers you need to cast explicitly
            //int x = 10;
            //int y = 2;
            //if (x / y > 1)
            //    op++; // 1
            //else op--;
            //switch (op)
            //{
            //    default:
            //        op += 1;
            //        break;
            //    case Operacija.Plus: break;
            //    case Operacija.Minus:
            //        op -= 2;
            //        break;
            //    case Operacija.Puta:
            //    case Operacija.Podeljeno:
            //        op -= 2;
            //        break;
            //}
            //Console.WriteLine(op);

            // 16
            //Smer s = Smer.IS;
            //switch (s)
            //{
            //    case Smer.MA:
            //        Console.WriteLine("MA");
            //        break;
            //    case Smer.EE:
            //        Console.WriteLine("EE");
            //        break;
            //    case Smer.JA:
            //        Console.WriteLine("JA");
            //        goto case Smer.EE;
            //    case Smer.IS:
            //        Console.WriteLine("IS");
            //        goto case Smer.MA;
            //}
            //Console.WriteLine(s);

            // 17
            //void DodajDeset(ref int broj)
            //{
            //    broj += 10;
            //}

            //int x = 5;
            //DodajDeset(x); // Can't pass variable without ref
        }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum Enumeracija
    {
        Prolece = 2,
        Leto, // 3
        Jesen = 4,
        Zima = 1
    }

    public enum Operacija { Kvadrat, Plus = 2, Puta, Minus = -1, Podeljeno = 4 } // Kvadrat = 0, Puta = 3

    public enum Smer { JA = 2, IS = 1, MA = 3, EE = 4 };
}