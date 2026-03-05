public class Schwert : Waffe
{
    public Schwert(int schaden)
    {
        this.Schaden = schaden;
        this.Reichweite = 1;
        this.Schadensart = "Klingenschaden";
    }
}