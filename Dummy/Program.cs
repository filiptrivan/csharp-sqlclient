using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography;
using static Dummy.Program;

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
            //byte b = (byte)a;
            //char c = b; // FALSE // Više jezički dizajn nego tehnička nužnost — tvorci jezika su hteli da izbegnu situacije gde se broj slučajno tretira kao znak bez namere programera.

            //char a = 'a';
            //int b = a; // TRUE
            //char c = b; // FALSE

            //char a = 'a';
            //long b = a; // TRUE
            //char c = b; // FALSE

            //char a = 'a';
            //short b = a; // FALSE 
            //short b = (short)a;
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

            // 11
            //char x = '\';
            //short a = (short)x;
            //short a = (short)'3';
            //short a = (byte)'3';
            //byte a = (short)'3';

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


            // 20
            //void Dodaj(in int x)
            //{
            //    //x = 0; // FALSE: With in, it's readonly
            //}
            ////void Dodaj(ref/in/out int x) { }

            //int x = 6;
            //Dodaj(x); // NOTE: It works with and without in prefix
            //Console.WriteLine(x);

            // 24
            //x = x++; // x = x++; leaves x unchanged
            //y += x;


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
            //pass-by-reference

            //koji od nav. prog. jezika omogucava da se prenese sadrzaj formalnog parametra u argument? C#, JAVA, C++, C

            //33
            //static void M(double x, params double[] y) { }
            //static void M(double y = 5, double x = 10) { }
            //M(x: 5.2);

            // 37
            //string s1 = "xyz";
            //string s2 = "zxy";
            //s2 = s2 + 2; // VALID syntax

            // 38
            //int[] niz = { 1, 2, 3, 4, 5, 6, 7 };
            //int[] noviNiz = niz[3..^5]; // Exception, invalid range

            // 41
            //char a = 'a';
            //a = a + 1;
            //a++;

            // 44
            //object y;
            //string? y;
            //char? y;
            //int x = 5;
            //y = x.ToString()?[0];

            // 45
            //var y = Enumeracija?.Zima ?? 0;
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
            //Console.WriteLine(e);

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

            // 52
            //Struktura s;
            //s.x += 5;

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
            //Klasa k = new Klasa();
            //Enumeracija? e2 = k?.enumeracija;
            //Enumeracija? e3 = k.enumeracija;
            //Enumeracija e4 = k?.enumeracija;
            //Enumeracija e5 = k.enumeracija;

            // 60
            //Klasa e1 = null; 
            //Enumeracija? e2 = e1?.enumeracija;
            //Klasa f1 = new Klasa(); 
            //object f2 = f1?.enumeracija;

            // 61
            //string s = (string)'#';

            // 62
            //char a = new Klasa().tekst[0];
            //long? b = new Klasa()?.tekst[0] ?? 1;

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

            // 67
            //Struktura s = new Struktura();
            //s.x = 10;
            //Klasa k = new Klasa();
            //k.s = s;
            //k.s.x = s.x;
            //k.s.x = 11;
            //Console.WriteLine(s.x);

            // 68
            //Enumeracija e = 0;
            //e += 3;
            //Console.WriteLine(e);

            // 69
            //var c1 = 5.3; 
            //dynamic c2 = 1.7m; 
            //c1 = c2;

            // 70
            //char c = new Klasa().tekst[0];
            //Klasa f1 = new Klasa(); 
            //char? f2 = f1?.tekst?[0];

            // 71 - Works in C, C++, Java
            //{
            //    int x = 0;
            //}
            //int x = 0;

            // 72
            //Klasa[] niz1 = new Klasa[10];
            //Console.WriteLine(niz1[0].vrednostByte);
            //Struktura[] niz2 = new Struktura[10];
            //Console.WriteLine(niz2[0].x);
            //Enumeracija[] niz3 = new Enumeracija[10];
            //Console.WriteLine(niz3[0]);
            //Enumeracija?[] niz4 = new Enumeracija?[10];
            //Console.WriteLine(niz3[0]);

            // 73
            //int[] niz1 = new int[10];
            //int[] niz2 = new int { 1 };
            //int[,] mat1 = new int[1][];
            //int[,] mat2 = new int[,] { { 1, 2 } };
            //int[,] mat3 = new int[1, 1] { { 1, 2 } };
            //int[][] nn1 = { { 1, 2 } };
            //int[][] nn2 = { };
            //int[][] nn3 = new int[10][1] { 1, 2, 3 };

            // 75
            //string[] niz = new string[10];
            //Console.WriteLine(niz[10]);

            // 76
            //string[] niz = new string[2] { "ABC" };
            //string[] niz = new string[1] { "ABC" };
            //Console.WriteLine(niz[0][0]);

            // 77
            //Enumeracija[][] niz = new Enumeracija[10][];
            //Console.WriteLine(niz[0][0]);

            // 78
            //int[] niz = { 1, 2, 3, 4, 5};
            //int[] niz2 = niz[2..^0];
            //foreach (int item in niz2)
            //    Console.WriteLine(item);

            // 80
            //int[] niz = { 1, 2 };
            //Console.WriteLine(niz[-1]);

            // 82
            //int x = 5;
            //int y = x + Enumeracija.Leto; // You can't do it to assign it to int, but you can to enum

            // 83
            ////int z = 4 / 0;
            //try
            //{
            //    try
            //    {
            //        int y = 0;
            //        int x = 5 / y;
            //    }
            //    catch (NullReferenceException)
            //    {
            //        Console.WriteLine(1);
            //    }
            //    finally
            //    {
            //        Console.WriteLine(2);
            //    }

            //    Console.WriteLine(3);
            //}
            //catch (DivideByZeroException)
            //{
            //    Console.WriteLine(5);
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine(4);
            //}
            ////catch (DivideByZeroException)
            ////{
            ////    Console.WriteLine(5);
            ////}
            //finally
            //{
            //    Console.WriteLine(6);
            //}

            // 84
            //void M(int a, int b, int c) { }
            //M(1, c: 2, b: 3);
            //M(a: 1, 2, c: 3);
            //M(c: 1, 2, a: 3);

            // 70
            //void M(Klasa k)
            //{
            //    k.vrednost = 10;
            //    k = new Klasa();
            //    k.vrednost = 15;
            //}
            //Klasa klasa = new Klasa();
            //M(klasa);
            //Console.WriteLine(klasa.vrednost);

            // 71
            //void M(ref Struktura s)
            //{
            //    s.x = 10;
            //    s = new Struktura();
            //    s.x = 15;
            //}
            //Struktura s = new Struktura();
            //M(ref s);
            //Console.WriteLine(s.x);

            // 72
            //void M(ref Klasa k)
            //{
            //    Console.WriteLine(--k.vrednost);
            //}
            //Klasa klasa = new Klasa();
            //klasa.vrednost = 10;
            //M(ref klasa);
            //M(ref klasa);

            // 73 !
            //void M1(Pitanje a, ref Pitanje b)
            //{
            //    b = a;
            //    a.resenje.tekst = "3";
            //    a = b;
            //    b.resenje.tekst = "4";
            //}
            //Pitanje a = new Pitanje(); Pitanje b = new Pitanje();
            //a.resenje.tekst = "1"; b.resenje.tekst = "2";
            //M1(a, ref b);
            //Console.WriteLine(a.resenje.tekst + b.resenje.tekst);

            // 74
            //5.UO();
            //5.0.UO();
            //((int)5).UO();
            //(double)'$'.UO();

            // 75
            //int[][] niz = new int[3][];
            //Console.WriteLine(niz[0][0]);

            // 76
            //try
            //{
            //    try
            //    {
            //        Console.WriteLine(1);
            //        throw new DivideByZeroException();
            //    }
            //    catch (ArgumentNullException)
            //    {
            //        Console.WriteLine(2);
            //    }
            //    finally
            //    {
            //        Console.WriteLine(6);
            //    }

            //    Console.WriteLine(3);
            //}
            //catch (ArgumentNullException)
            //{
            //    Console.WriteLine(4);
            //}

            // 78
            //static void M(params int[] a) { }
            //M(a: 1, 2, 3);

            // 79
            //static void M<T>(Object a) where T : class
            //{
            //    a = "5";
            //}
            //Object a = "";
            //M<object>(a);
            //Console.WriteLine(a);

            // 80
            //Console.WriteLine(28%56);
            //Console.WriteLine(0%1);

            // 81
            //Action[] a = new Action[2];
            //for (int i = 1; i < 4; i = i*2)
            //{
            //    a[i/2]=() => Console.Write(i + 5);
            //}
            //foreach (var x in a) x();

            // 82
            //void M(int a = 5, params int[] y) { }
            //void M(params int[] y, int a = 5) { }

            // 83
            //int? a = 0;
            //Enumeracija e = (Enumeracija?)a ?? (Enumeracija)0;
            //Enumeracija e = (Enumeracija?)a ?? 0;
            //Enumeracija e = a ?? 0;
            //Enumeracija e = a ?? (Enumeracija)0;
            //Enumeracija e = 0;

            // 84
            //Klasa[] a = new Klasa[3]; Console.Write(a[0]);

            // 85
            //static (double, char) M5() => (5.0, '#'); var (e, _) = M5();

            // 86
            //Uspeh a = new Uspeh(); int c = 30; double d = 50.0;
            //a += d;
            //a += c; // u operatoru: Uspeh = Uspeh + double
            //c += a;
            //a.bodova = a + 5;

            // 87
            //Console.WriteLine((int)Oznaka.A);

            // 89
            //static void M(int x = 0, int y = 0, int z = 0) { }
            //M(x: 1, 2, z: 2);
            //M(z: 1, 2, x: 2);

            // 90
            //public void M()
            //{
            //X f1 = new X(); Z f2 = (Z)f1; f2.x = 5;
            //X f3 = new Z(); Z f4 = (Z)f3; f4.x = 5;
            //}

            // 91
            //Console.WriteLine(1/0.0);

        }

        public struct Odgovor
        {

            public Oznaka? oznaka;
            public string tekst;

        }

        public class Pitanje
        {
            public byte rb;
            public string tekst;
            public Tip tip;
            public Poeni poeni;
            public Odgovor resenje;

        }

        public enum Oznaka { A, B, C, D, E, F }

        public struct Poeni
        {
            public int tacno;
            public double netacno;

        }

        public class Ugovor
        {
            public Tip tip;
        }

        public enum Tip { Biznis = 1, Privatni }

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

        public class Skup
        {
            public int[] niz = { 2, 3, 4, 5, 6 };
            public int this[int pozicija]
            {
                get { return niz[1-pozicija]; }
            }
        }

        public enum Gender
        {
            Male,
            Female
        }

        public enum Enumeracija
        {
            Prolece = 1,
            Leto, // 3
            Jesen = 2,
            Zima
        }

        public enum Operacija { Kvadrat, Plus = 2, Puta, Minus = -1, Podeljeno = 4 } // Kvadrat = 0, Puta = 3

        public enum Smer { JA = 2, IS = 1, MA = 3, EE = 4 };

        class Klasa
        {
            public byte vrednostByte;
            public int vrednost = 0;
            public string tekst;
            public Enumeracija enumeracija;
            public Struktura s;

            public Klasa(int vrednost)
            {
                this.vrednost=vrednost;
            }
            public Klasa()
            {
            }



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

            // 66 !
            //public int Property => vrednost = value;
            //int Property { public get {  return vrednost; } }
            //int Property { public get { return vrednost; } public set { } }
            //public int Property { public get { return vrednost; } set { } }
            //public int Property { internal get { return vrednost; } set { } }

            // 67
            //public int F(int x) => { x = x+5; return x; }

            // 68
            //public int M(int x) => x = 0;
            //public void M(int x) => x = 0;

            // 69
            //public int M(ref int x) => x = 0;
            //public void M(out int x) => x = 0;
            //public int M(in int x) => 0;

            // 70
            //public static void M1() { M2(); }
            //public void M2() { M1(); }
            //public void M3() { M2(); }

            // 71
            //void M()
            //{
            //new Klasa2().staticka = 5;
            //Klasa2.staticka = 5;
            //}

            // 72
            //void M(int i) { }
            //void M(out int i) { i = 0; }
            //void M(ref int i) { }
            //void M(in int i) { }

            // 73
            //static void M(in Klasa k) => k.vrednost = 5;
            //static void M(in Struktura s) => s.x = 5;
            //static void M(out Struktura s) => s.x = 4;

            // 74
            //byte a = -1;
        }

        public static class Klasa2
        {
            public static int staticka;

            //void M() { this.staticka = 1; }
            //static void M1() { }
            //void M2() { this.M1(); }
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
    public static void M()
    {
        //1.2.UO();
        //Extensions.UO(1.2);
        //(double)('#').UO();
    }

    public static int UO(this double poena) => 0;
}

partial class Partial
{
    public virtual void M() { }
}

public partial class Partial
{
    public void M(int x) { }
}

public struct Uspeh
{
    public int bodova;

    public static Uspeh operator +(Uspeh u, double b)
    {
        u.bodova += (int)(b);
        return u;
    }

    public static int operator +(Uspeh u, int b)
    {
        u.bodova += b;
        return u.bodova;
    }

}
public struct Modul { }
public class Student
{
    //public Uspeh uspeh;
    //public static Uspeh uspeh;

    // 1
    //static void A(out int u) => u = uspeh.bodova;
    //static void B(out Uspeh u) => u = new Uspeh();
    //void C(out Student s) => s.uspeh.bodova =10;
    //void D(in Uspeh u) => u.bodova = 10;
    //void E(in Student s) => s = new Student();
    //void F(in Student s) => s.uspeh.bodova = 10;

    // 2
    //static void A(out int u) => u = this.uspeh.bodova;
    //static void A(out int u) => u = uspeh.bodova;
    //void A(out int u) => u = this.uspeh.bodova;
    //void A(out int u) => u = uspeh.bodova;
    //void D(in Uspeh u) => u.bodova = 10;
    //int M(Modul m, ref int i, short s = 0) => 0;

    // 3
    //int M(Modul m, out int i, short s, int d = 5) => 0;
    //short M(Modul m, ref int i, short s = 0) => 0;
    //int M(Modul m, int i, short s = 0) => 0;
    //static int M(Godina m, ref int i, short s) => 0;
    //public int M(Modul t, short s, ref int i) => 0;
    //int M(Modul m, in int i, short s = 0) => i = 5;
}


// 1
//interface I { void Metoda(); }
//abstract class A { public abstract int M { get; } }
//abstract class B : A, I { public void Metoda() { } }
//class C : B { public override int M => 1; }
//sealed class D { public int d; }
//class E : D { public int e; }
//partial class F : A { public int M => 1; }

// 2
class X { public int x; }
class Y : X { }
class Z : Y { }

class C
{

}

// 3 - In the class, overload with ref works
public class Podatak
{
    public int broj = 10;
    //public void M(int broj) { broj = this.broj; }
    //public void M(in int broj) {  }
    //public void M(ref int broj) { }
}