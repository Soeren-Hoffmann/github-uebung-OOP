internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Spielwelt welt = new Spielwelt();
        welt.besetzt(0, 0);
    }
}