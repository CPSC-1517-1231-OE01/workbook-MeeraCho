namespace Hockey.Data
{
    public class HockeyTeam
    {
        private const int MinPlayers = 20;
        private const int MaxPlayers = 23;
        private const int MinGoalies = 2;
        private const int MaxGoalies = 3;

        public List<HockeyPlayer> Players { get; private set; } = new List<HockeyPlayer>();
        public string Name { get; private set; }
        public string City { get; private set; }
        public int TotalPlayers => Players.Count;
        public bool IsValidRoster
        {
            get
            {
                int numOfGoalies = Players.Where(p => p.Position == Position.Goalie).Count();
                return TotalPlayers >= MinPlayers && TotalPlayers <= MaxPlayers && numOfGoalies >= MinGoalies && numOfGoalies <= MaxGoalies;
            }
        }

        public HockeyTeam(string city, string name)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentException("City cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty.");
            }

            City = city;
            Name = name;
        }

        public void AddPlayer(HockeyPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException("Player cannot be null.");
            }
            Players.Add(player);
        }

        public void RemovePlayer(HockeyPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException("Player cannot be null.");
            }

            if (!Players.Contains(player))
            {
                throw new InvalidOperationException($"Player {player} is not on the team.");
            }

            Players.Remove(player);
        }


    }
}
