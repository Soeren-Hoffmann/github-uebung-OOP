public class Schwert : Waffe
{
    public Schwert(int damage)
    {
        this.Damage = damage;
        this.Reichweite = 1;
        this.Schadensart = "Klingenschaden";
    }
}