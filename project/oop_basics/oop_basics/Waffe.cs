namespace oop_basics
{
    public class Waffe
    {
        // Eigenschaften (Properties)
        // { get; } bedeutet, dass diese Werte nach der Erstellung des Objekts nicht mehr geändert werden können.
        public string Name { get; }
        public int[] Schlagschaden { get; }
        public int[] Klingenschaden { get; }
        public int Reichweite { get; }

        // Konstruktor: Wird aufgerufen, wenn wir eine neue Waffe mit 'new Waffe(...)' erstellen.
        public Waffe(string name, int[] schlagschaden, int[] klingenschaden, int reichweite)
        {
            Name = name;
            Schlagschaden = schlagschaden;
            Klingenschaden = klingenschaden;
            Reichweite = reichweite;
            
        }
    }
}


