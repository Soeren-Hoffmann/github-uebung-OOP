using System.Dynamic;
using System.Reflection.Metadata;

public class Spielfigur
{
    public int Health { private set; get; }
    public int Speed { get; }
    public int[]? Position { set; get; }
    private Spielwelt Welt = Spielwelt.GetInstance();
    public Waffe Waffe { set; get; }
    public int KlingenResistenz;
    public int SchlagResistenz;
    public string Type { set; get; }


    public Spielfigur(string Type, int Health, int Speed, Waffe Waffe, int KlingenResistenz, int SchlagResistenz)
    {
        this.Type = Type;
        this.Health = Health;
        this.Speed = Speed;
        this.Waffe = Waffe;
        this.KlingenResistenz = KlingenResistenz;
        this.SchlagResistenz = SchlagResistenz;
    }

    public void SchadenNehmen(Spielfigur figur)
    {
        int EndSchaden = 0;
        if(figur.Waffe.Schadensart == "Klingenschaden")
        {
            EndSchaden = figur.Waffe.Schaden - this.KlingenResistenz;    
        } 
        else if (figur.Waffe.Schadensart == "Schlagschaden")
        {
            EndSchaden = figur.Waffe.Schaden - this.SchlagResistenz;    
        }

        if (this.Health > EndSchaden)
        {
            this.Health -= EndSchaden;
        }
        else
        {
            // spieler tot (meldung ausgeben)
            this.Health = 0;
            Welt.Entferne(this);
        }
    }
    public enum Richtung
    {
        Hoch,
        Runter,
        Links,
        Rechts,
        Angriff,
        NONE
    };
        public void ZieheAufFeld(Spielfigur.Richtung richtung)
    {
        // hat der player eine position von der map bekommen? nein? -> fehlermeldung
        if(Position == null)
        {
            return;
        }

        switch (richtung)
        {
            case Richtung.Hoch:
                if(!Welt.Besetzt(Position[0], Position[1] - Speed))
                {
                    Welt.SpielerBewegen(this, Position[0], Position[1] - Speed);
                    Position[1] -= Speed;
                }
                break;
            case Richtung.Runter:
                if(!Welt.Besetzt(Position[0], Position[1] + Speed))
                {
                    Welt.SpielerBewegen(this, Position[0], Position[1] + Speed);
                    Position[1] += Speed;
                }
                break;
            case Richtung.Rechts:
                if(!Welt.Besetzt(Position[0] + Speed, Position[1]))
                {
                    Welt.SpielerBewegen(this, Position[0] + Speed, Position[1]);
                    Position[0] += Speed;
                }
                break;
            case Richtung.Links:
                if(!Welt.Besetzt(Position[0] - Speed, Position[1]))
                {
                    Welt.SpielerBewegen(this, Position[0] - Speed, Position[1]);
                    Position[0] -= Speed;
                }
                break;
        }
    }
}