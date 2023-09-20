using Utils; //namespace

namespace Hockey.Data
{
    public class HockeyPlayer
    {
        //data fields: private + data type + _fieldName (camel case) 
        private string _firstName;
        private string _lastName;
        private string _birthPlace;
        private DateOnly _dateOfBirth;
        private int _heightInInches;
        private int _weightInPounds;

        //we don't need the following Enumerations
        //private Position _position;
        //private Shot _shot;

        //properties
        public string BirthPlace
        {
            get
            {
                return _birthPlace;
            }
            set //public void set(string value)
            {
                if (string.IsNullOrWhiteSpace(value)){
                    throw new ArgumentException("Birth place cannot be null or empty.");
                    //creating new instance.object. Constructor. function for argumentException class 
                } 
                //if we get here, then no exception happened
                 _birthPlace = value; 
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name cannot be null or empty.");
                }
                _firstName = value; 
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name cannot be null or empty.");
                }
                _firstName = value;
            }
        }

        public int HeightInInches
        {
            get
            {
                return _heightInInches;
            }
            set
            {
                if(Utilities.IsZeroOrNegative(value))
                {
                    throw new ArgumentException("Height must be positive.");
                }
                _heightInInches = value;
            }
        }

        public int WeightInPound
        {
            get
            {
                return _weightInPounds;
            }
            set
            {
                if (!Utilities.IsPositive(value))
                {
                    throw new ArgumentException("Weight must be positive.");
                }
                _weightInPounds = value;
            }
        }
 
        public DateOnly DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                //a validity check for dates in the future
                // check the documentation for DateOnly
                if (Utilities.IsInTheFuture(value))
                {
                    throw new ArgumentException("Date of birth cannot be in the future.");
                }
                _dateOfBirth = value;
            }
        }

        //Auto-implemented property -can't be null. no need to do validation ckeck. Position is set already
        public Position Position { get; set; }
        public Shot Shot { get; set; }

        //constructors
        //default constructor- 1.public 2. no return type 3. same Class name 
        //Create default instance hockey player 
        public HockeyPlayer() 
        {
            _firstName = string.Empty; //no specific name, null here, why? 
            _lastName = string.Empty;
            _birthPlace = string.Empty;
            _dateOfBirth = new DateOnly();
            _weightInPounds = 0;
            _heightInInches = 0;
            Position = Position.Center;
            Shot = Shot.Left;
        }

        public HockeyPlayer(string firstName, string lastName, string birthPlace, DateOnly dateOfBirth, int weightInPounds, int heightInInches, Position position = Position.Center, Shot shot = Shot.Left)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthPlace = birthPlace;
            HeightInInches = heightInInches;
            WeightInPound = weightInPounds;
            DateOfBirth = dateOfBirth;
            Position = position;
            Shot = shot; 
        }
    }
}