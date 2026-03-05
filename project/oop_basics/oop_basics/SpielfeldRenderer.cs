
class SpielfeldRenderer
{
        public string GetSpielfeld(Spielwelt welt)
    {
        // string result = "\033[1;1H";
        string result = "";
        try
        {
            Console.SetCursorPosition(1,1);
        } catch (Exception e)
        {
            
        }

        for(int i = 0; i < welt.board.GetLength(0); i++)
        {
            for(int j = 0; j < welt.board.GetLength(1); j++)
            {
                Spielfigur? figur = welt.board[j, i];
                if(figur == null)
                {
                    result += ".";
                }
                else
                {
                    result += figur.Type;
                }
            }
            result += "\n";
        }
        return result;
    }
}