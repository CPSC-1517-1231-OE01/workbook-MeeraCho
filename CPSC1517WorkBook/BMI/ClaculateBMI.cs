namespace BMI
{
    public class ClaculateBMI
    {
        private double _height;
        private double _weight;

        public string Name { get; private set; }

        public double Height
        {
            get { return _height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height must be positive non-zero value.");
                }
                _height = value;
            }
        }
        public double Weight
        {
            get { return _weight; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Weight must be positive non-zero value.");
                }
                _weight = value;
            }
        }

        public double Bmi()
        {
            double bmiValue = 703 * Weight / Math.Pow(2, Height);
            bmiValue = Math.Round(bmiValue);
            return bmiValue;
        }

        public string BmiCategory()
        {
            string category = "Unknown";
            double bmiValue = Bmi(); 

            if (bmiValue < 18.5)
            {
                category = "underweight";
            }
            else if (bmiValue < 24.9)
            {
                category = "normal";
            }
            else if (bmiValue < 29.9)
            {
                category = "overweight";
            }
            else if (bmiValue >= 30)
            {
                category = "obese";
            }
            return category;
        }

        public BodyMassIndex(string name, double weight, double height)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name cannot be blank");
            }
            Name = name;
            Weight = weight;
            Height = height;
        }
    }
}