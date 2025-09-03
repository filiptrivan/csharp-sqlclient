using System.Security.Cryptography;

namespace Dummy
{

    internal class Program
    {
        static void Main(string[] args)
        {
            // 3
            //float f = 1.4f;
            //decimal m = f;
            //f = m;
            //double d = 1.5;
            //d = m;
            //m = d;

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
            //x = y; // TRUE
            //x = '7'; // TRUE
            //y = x; // TRUE
            //x = (int)y; // TRUE

            // 8
            //double x = 14.123123123F;
            //dynamic y = 3.4m;
            //x = 'a'; // TRUE
            //x = y; // TRUE (but runtime error)
            //y = x; // TRUE

            // 10
            //string x;
            //x = x + ""; // FALSE

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
            //    case Operacija.Minus: op -= 2;// Don't have break
            //    case Operacija.Puta:
            //    case Operacija.Podeljeno: op -= 2; break;
            //}
            //Console.WriteLine(op);

            // 18
            //void Dodaj(out int x)
            //{
            //    //x++; // FALSE: Use of unassigned variable
            //    x = 0;
            //}

            //int x = 6;
            //Dodaj(out x);
            //Console.WriteLine(x);

            // 19
            //void m1(ref Klasa kRef) // NOTE: If it wasn't ref init of the class wouldn't change the value inside the Main
            //{
            //    kRef = new Klasa(5);
            //}

            //Klasa k1 = new Klasa(); // NOTE: If it was not initialized, it would throw exception
            //m1(ref k1);
            //Console.WriteLine("k1.vrednost = " + k1.vrednost);

            // 20
            //void Dodaj(in int x)
            //{
            //    //x = 0; // FALSE: With in, it's readonly
            //}
            ////void Dodaj(ref/in/out int x) { }

            //int x = 6;
            //Dodaj(x); // NOTE: It works with and without in prefix
            //Console.WriteLine(x);

            // 22
            //void m(out int x)
            //{
            //    x = 5;
            //    int y = x++; // NOTE: This will increase the out x also
            //}

            //int x;
            //m(out x);
            //Console.WriteLine(x);

            // 23 - In the class, overload with ref works
            //  public class Podatak
            //  {
            //    public int broj = 10;
            //    public void M(int broj) { broj = this.broj; }
            //    public void M(ref int broj) { broj = this.broj; }
            //  }

            // 24
            //x = x++; // x = x++; leaves x unchanged
            //y += x;

            // 25
            //void m(ref int x) { }
            //Klasa k = new Klasa(); 
            //m(ref k.vrednost); // This will work because new Klasa() will instantiate vrednost to 0

            // 27
            //Struktura s1 = new Struktura();
            //Struktura s2 = new Struktura();
            //if (s1 == s2) // We can't compare structs
            //    Console.WriteLine();

            // 28
            //int x += 5; // FALSE

            // 29
            //void M(int a, int b, int c) { }
            //M(2, 1, c:2); // This is valid cuz c is in the proper position

            // 30
            //5.0.UO();
            //(double)5.UO(); // FALSE

            // 31
            //int[] niz = { 1, 2, 3 };
            //Console.WriteLine(niz[^0]); // index out of range exception

            // 32
            //if (true)
            //{
            //    int z = 0;
            //}
            //int z = 0;

            //koja implementaciona metoda za prenos parametara se moze koristiti ukoliko je potrebno da metoda vrati informacije pozivaouce:
            //pass-by-reference, out?

            //koji od nav. prog. jezika omogucava da se prenese sadrzaj formalnog parametra u argument? C#, JAVA, C++, C

            //33
            //static void M(double x, params double[] y) { }
            //static void M(double y = 5, double x = 10) { }
            //M(x: 5.2);

            // 35
            // sta od navedenog moze uticati na smanjenje pouzdanosti programa
            // postojanje kljucnih reci koje nisu rezervisane
            // implicitna konverzija promenljive
            // koriscenje dinamickog dosega
            // odsustvo podrske za korisnicki definisane tipove podataka
            // neogranicavanje alijasa 
            // odsustvo ortogonalnosti

            // 36
            // sta od navedenog moze imati negativan uticaj na efikasnost programa
            // implicitno deklarisanje tipa promenljive koriscenjem konteksta
            // koriscenje statickih promenljivih
            // dinamicko povezivanje sa tipom
            // pisanje programa u jeziku sa statickim dosegom
            // dinamicka provera tipova
            // dinamicko povezivanje sa memorijskom lokacijom

            // 37
            //string s1 = "xyz";
            //string s2 = "zxy";
            //s2 = s2 + 2; // VALID syntax
            //s2 = s1;
            //s2 = "yzx";
            //// Even if string is considered as reference type it's behaving like value type, and the s1 stays "xyz" for the whole time

            // 38
            //int[] niz = { 1, 2, 3, 4, 5, 6, 7 };
            //int[] noviNiz = niz[3..^5]; // Exception, invalid range

            //foreach (var item in noviNiz)
            //{
            //    Console.WriteLine(item);
            //}

            // 39
            //B b = new A();
            //A a = new B();

            // 40
            //new B(1);

            // 41
            //char a = 'a';
            //a = a + 1;
            //a++;

            // 43
            //A a = new B();
            //a.M();
            //A a2 = new A();
            //a2.M();

            // 44
            //object y;
            //string? y;
            //char? y;
            //int x = 5;
            //y = x.ToString()?[0];

            // 45
            //var y = Enumeracija.Zima ?? 0;
            //var y = "abc"?[0] ?? 1;

            // 46
            //char c = 'A';
            //int x = 5;
            //decimal m = c;
            //m = x;

            // 47
            //byte e = 0;
            //checked
            //{
            //    e--;
            //}

            // 48
            //int? f1 = null; 
            //int f2 = (int)f1; // Runtime error

            // 49
            //var f1 = 0; 
            //dynamic f2 = "1"; 
            //f2 = f1; // Obrati paznju da ovo moze, da je bilo f1 = f2, ne bi moglo

            // 50
            //int i = 0;
            //Struktura s;
            //i = s.x; // We get the error

            // 51
            //int i;
            //i += 5;

            // 52
            //Struktura s;
            //s.x += 5; 

            // 53
            //Klasa k = new Klasa();
            //Console.WriteLine(k.enumeracija == 0);

            // 54
            //int a;
            //int b;
            //a = b;

            // 55
            //int x;
            //Klasa k = new Klasa();
            //x = k?.vrednostByte;

            // 56
            //int? a1 = null; 
            //int a2 = 1; 
            //int a = a1 ?? a2;

            // 57
            //float a = 5.2f;
            //a++;
            //Console.WriteLine(a);

            // 58
            //Klasa k = null; 
            //Enumeracija? e2 = k?.enumeracija;
            //Enumeracija? e3 = k.enumeracija;
            //Enumeracija e4 = k?.enumeracija;
            //Enumeracija e5 = k.enumeracija;

            // 59
            //int? f1 = null; 
            //int f2 = (int)f1;

            // 60
            //Klasa e1 = null; 
            //Enumeracija? e2 = e1?.enumeracija;
            //Klasa f1 = new Klasa(); 
            //object f2 = f1?.enumeracija;

            // 61
            //string s = (string)'#';

            // 62
            //char a = new Klasa().tekst[0];
            //long? b = new Klasa().tekst[0] ?? 1;

            // 63
            //Klasa f1 = new Klasa(); 
            //char? f2 = f1?.tekst[0];

            // 64
            //uint d = 0; d--;

            // 65
            //string f = "1";
            //f += '#';

            // 66
            //var x = (int)new Klasa().enumeracija;

        }

        public class A
        {
            public A() { Console.WriteLine("A"); }
            public A(int i) { Console.WriteLine("AI"); }

            public virtual void M() 
            {
                Console.WriteLine("A");
            }
        }
        public class B : A
        {
            public B() : base(1) { Console.WriteLine("B"); }
            public B(int i) : this() { Console.WriteLine("BI"); }

            public override void M()
            {
                Console.WriteLine("B");
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

        class Klasa
        {
            public byte vrednostByte;
            public int vrednost = 0;
            public string tekst;
            public Enumeracija? enumeracija;

            public Klasa(int vrednost)
            {
                this.vrednost=vrednost;
            }
            public Klasa() { }

            //public int B { set; } // You can't have set alone
            //public string C { set { vrednost = int.Parse(value); } } // You can have set alone like this
            //public int F(int x) => { return x; } // Invalid syntax

            //public static void A1() { vrednost++; } // We can't access the `vrednost` from static method

            // Overload examples:

            // 63
            //public void M(Klasa k, int i, int p = 0) { }
            //public void M(out Klasa k, int i, int p = 0) { k = null; } // out CAN be at the whichever place inside method arguments
            //void M(Klasa k, int i, out int p = 0) { p = 0; } // ref nor out can have default value

            // 64
            ////this can't be used inside static method

            // 65
            // You need to check for returned type also, void method can't return anything
        }

        public struct Struktura
        {
            public int x, y;
            public static int z;
            public Struktura(int x, int y)
            {
                this.x = x;
                this.y = y;
                //this.z = 5; // You can't use `this` if the field is static
            }


        }

        public struct Index
        {
            public int broj;
            public int godina;

            public void A(int broj) { broj += this.broj; }
            public void B(ref int broj) { broj += broj; }
            public void C(int broj) { this.broj += this.broj; }
            //public void D(out int broj) { this.broj += broj; } // `broj` isn't initialized
            //public static void E(int broj) { this.broj += broj; } // this can't be used inside static method
        }

        public class Razlomak
        {
            public int brojilac;
            public int imenilac;

            public Razlomak(int brojilac, int imenilac)
            {
                this.brojilac = brojilac;
                this.imenilac = imenilac;
            }
        }
    }
}
public static class Extensions
{
    public static int UO(this double poena) => 0;
}