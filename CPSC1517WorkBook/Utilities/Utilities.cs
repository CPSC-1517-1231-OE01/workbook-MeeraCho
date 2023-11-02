namespace Utils
{
    public static class Utilities
    {
        public static bool IsNullEmptyOrWhiteSpace(string value) => string.IsNullOrWhiteSpace(value);

        public static bool IsZeroOrNegative(int value) => value <= 0;   

        public static bool IsPositive(int value) => value > 0;
        public static bool IsPositive(double value) => value > 0.0;
        public static bool IsPositive(decimal value) => value > 0M; //decimal: financial monatary value 


        //Determines if a DateOnly is in the future, tomorrow or greater
        public static bool IsInTheFuture(DateOnly value) => value > DateOnly.FromDateTime(DateTime.Now);

    }
}
//이미 HockeyPlayer Property set 할 때 value를 거르지만, 또 여기에 적어서 앞에서 했을 실수를 한 번 더 거른다 
//it's good to put them in a seperate file 

