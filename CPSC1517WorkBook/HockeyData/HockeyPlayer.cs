using System.Globalization;
using Utils;


namespace Hockey.Data
{
    public class HockeyPlayer
    {
        private string _firstName;
        private string _lastName;
        private DateOnly _dateOfBirth;
        private int _heightInInches;
        private int _weightInPounds;
        private int _jerseyNumber;
        private string _birthPlace; 

        public HockeyPlayer(string firstName, string lastName, string birthPlace, DateOnly dateOfBirth, 
                            int heightInInches, int weightInInches, int jerseyNumber, Position position = Position.Center, Shot shot = Shot.Right)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthPlace = birthPlace;
            DateOfBirth = dateOfBirth;  
            HeightInInches = heightInInches;
            WeightInPounds = weightInInches;
            JerseyNumber = jerseyNumber;
            Shot = shot;
            Position = position;
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                if(Utilities.IsNullEmptyOrWhiteSpace(value))
                {
                    throw new ArgumentException($"First name cannot be null or empty.");
                }
                _firstName = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (Utilities.IsNullEmptyOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Last name cannot be null or empty.");
                }
                _lastName = value;
            }
        }

        public string BirthPlace
        {
            get => _birthPlace;
            set
            {
                if (Utilities.IsNullEmptyOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Birth place cannot be null or empty.");
                }
                _birthPlace = value;
            }
        }

        public DateOnly DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                if(Utilities.IsInTheFuture(value))
                {
                    throw new ArgumentException("Date of birth cannot be in the future.");
                }
                _dateOfBirth = value;
            }
        }

        public int HeightInInches
        {
            get => _heightInInches;
            set
            {
                if (Utilities.IsZeroOrNegative(value))
                {
                    throw new ArgumentException("Height must be positive.");
                }
                _heightInInches = value;
            }
        }

        public int WeightInPounds
        {
            get => _weightInPounds;
            set
            {
                if (Utilities.IsZeroOrNegative(value))
                {
                    throw new ArgumentException("Weight must be positive.");
                }
                _weightInPounds = value;
            }
        }

        public Position Position { get; set; }
        public Shot Shot { get; set; }

        public int JerseyNumber
        {
            get => _jerseyNumber;
            set
            {
                if(value < 1 || value > 98)
                {
                    throw new ArgumentException("Jersey number must be between 1 and 98.");
                }
                _jerseyNumber = value;
            }
        }

        public int Age => (DateOnly.FromDateTime(DateTime.Now).DayNumber - DateOfBirth.DayNumber) / 365;

        //데이터에 입력되는 순서 
        public override string ToString() 
        {
            return $"{FirstName},{LastName},{JerseyNumber},{Position},{Shot},{HeightInInches},{WeightInPounds},{DateOfBirth.ToString("MMM-dd-yyyy", CultureInfo.InvariantCulture)},{BirthPlace.Replace(", ", "-")}";
        }

        public static HockeyPlayer Parse(string line)
        {
            HockeyPlayer player;

            //Validate
            if (string.IsNullOrWhiteSpace(line))
            {
                throw new ArgumentNullException("Line cannot be null or empty.", new ArgumentException());
            }

            // Split on commas that are not within double quoted strings
            string[] fields = line.Split(',');

            if (fields.Length != 9)
            {
                throw new InvalidDataException("Incorrect number of fields.");
            }

            try
            {
                //FirstName,LastName,JerseyNumber,Position,Shot,Height,Weight,DOB,BirthPlace - expected line format 
                //   0          1       2           3       4       5      6    7    8
                
                player = new HockeyPlayer(fields[0], fields[1], fields[8], DateOnly.ParseExact(fields[7], "MMM-dd-yyyy", CultureInfo.InvariantCulture), int.Parse(fields[6]), int.Parse(fields[5]), int.Parse(fields[2]), Enum.Parse<Position>(fields[3]), Enum.Parse<Shot>(fields[4]));
                                       // firstName, lastName, birthPlace, dateOfBirth,                                                                  heightInInches,        weightInInches,           jerseyNumber,         position,                   shot
            }
            catch
            {
                throw new FormatException($"Error parsing line {line}");
            }

            return player;
        }

        public static bool TryParse(string line, out HockeyPlayer? player)
        {
            bool isParsed = false;
            try
            {
                player = HockeyPlayer.Parse(line);
                isParsed = true;
            }
            catch
            {
                player = null;
                isParsed = false;
            }

            return isParsed; 
        }

    }
}

