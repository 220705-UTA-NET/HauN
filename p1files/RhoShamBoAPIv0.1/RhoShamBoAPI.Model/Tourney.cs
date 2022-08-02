namespace RhoShamBoAPI.Model
{
    public class Tourney
    {
        // Fields
        public int Id { get; set; }
        public int PlayerCount { get; set; }
        public string Winner { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Tourney() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Tourney(int id, int playerCount, string winner)
        {
            Id = id;
            PlayerCount = playerCount;
            Winner = winner;
        }
        
    }
}