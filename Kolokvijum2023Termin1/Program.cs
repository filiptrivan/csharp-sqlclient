namespace Kolokvijum2023Termin1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            string st = "alestaaaaa4a";
            bool hasDifferentCharacters = st.Any(x => char.IsLetter(x) == false);

            //Console.WriteLine(char.IsLetter(c));

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}