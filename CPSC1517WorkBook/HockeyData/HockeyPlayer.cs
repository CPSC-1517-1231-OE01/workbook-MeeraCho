namespace HockeyData
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
                if (string.IsNullOrWhiteSpace(value){
                    throw new ArgumentException("Birth place cannot be null or empty.");
                    //creating new instance.object. Constructor. function for argumentException class 
                } 
                //if we get here, then no exception happened
                 _birthPlace = value; //value가 조건에 안맞으면 throw an exception 한다    
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
                if(value <= 0)
                {
                    throw new ArgumentException("Height must be positive.");
                }
                _heightInInches = value;
            }
        }

        //TODO: complete the remaining int property 
        public DateOnly DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                //TODO: inplement a validity check for dates in the future
                // check the documentation for DateOnly
                _dateOfBirth = value;
            }
        }

        //Auto-implemented property -can't be null. Position is 정해져 있어서 validation ckeck 필요없음 
        public Position Position { get; set; }
        public Shot Shot { get; set; }

        //constructors
        //default constructor- 1.public 2. no return type 3. same Class name 
        //Create default instance hockey player 
        public HockeyPlayer() 
        {
            _firstName = string.Empty; //특정이름 안넣음, null 안된다고 했는데 했음 나중에 설명 
            _lastName = string.Empty;
            _birthPlace = string.Empty;
            _dateOfBirth = new DateOnly();
            _weightInPounds = 0;
            _heightInInches = 0;
            Position = Position.Center;
            Shot = Shot.left;
        }

        public HockeyPlayer(string firstName, string lastName, string birthPlace, DateOnly dateOfBirth, int weightInPounds, int heightInInches, Position position.Center, Shot shot.Left)
        {
            BirthPlace = birthPlace;
            HeightInInches = heightInInches;
            Position = position;
            Shot = shot; 
            //TODO: assign the remaining properties once you've completed them 
        }
    }
}