namespace Utils
{
    public static class Utilities
    {
        public static bool IsZeroOrNegative(int value)
        {
            // Simple technique -> return expression 
            //return value <= 0; //true, false

            // Explicit technique -> declare all parts
            /*            bool result; 
                        if (value <= 0)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }

                        return result;  */

            //simple but explicit -> conditional/ternary operator
            return value <= 0 ? true : false;
        }

        public static bool IsPositive(int value) => value > 0;

        public static bool IsInTheFuture(DateOnly value) => value > DateOnly.FromDateTime(DateTime.Now);

    }
}
//이미 HockeyPlayer Property set 할 때 value를 거르지만, 또 여기에 적어서 앞에서 했을 실수를 한 번 더 거른다 
//it's good to put them in a seperate file 

