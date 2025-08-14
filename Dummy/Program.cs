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

        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
