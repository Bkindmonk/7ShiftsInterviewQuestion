using System;

namespace SevenShiftsInterview
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                TestAddQuestion1();
                TestAddQuestion2();
                TestAddQuestion3();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
        }
        
        
        private static void TestAddQuestion1(){
            //The numbers in the string are separated by a comma
            bool case1 = (Add("1,2,3,4")==10);

            //Empty strings should return 0
            bool case2 = (Add("") == 0);
            
            //Testing multiple digits numbers
            bool case3 = (Add("1000,500,30,9") == 1539);
            
            //Testing single number strings
            bool case4 = (Add("500") == 500);
            
            //Testing zeroes in numbers
            bool case5 = (Add("1,0,2,0,3,0,0,4") == 10);

            if(!case1){throw new Exception("Test1 case1 failed");}
            if(!case2){throw new Exception("Test1 case2 failed");}
            if(!case3){throw new Exception("Test1 case3 failed");}
            if(!case4){throw new Exception("Test1 case4 failed");}
            if(!case5){throw new Exception("Test1 case5 failed");}
        }

        private static void TestAddQuestion2()
        {
            //handle new lines in the input format
            //Testing New lines in all positions and next to multi-digit numbers
            bool case1 = (Add("1\n,2,3") == 6);
            bool case2 = (Add("3,4\n,5") == 12);
            bool case3 = (Add("6,7,8\n") == 21);
            bool case4 = (Add("60\n,7,8") == 75);
            
            
            
            if(!case1){throw new Exception("Test2 case1 failed");}
            if(!case2){throw new Exception("Test2 case2 failed");}
            if(!case3){throw new Exception("Test2 case3 failed");}
            if(!case4){throw new Exception("Test2 case4 failed");}
        }

        private static void TestAddQuestion3()
        {
            bool case1 = (Add("//;\n1;3;4") == 8);
            bool case2 = (Add("//j\n1j3j4") == 8);
            
            if(!case1){throw new Exception("Test3 case1 failed");}
            if(!case2){throw new Exception("Test3 case2 failed");}
        }

        private static void TestAddQuestion4()
        {
            //Calling add with a negative number should throw an exception
            bool case1 = true;
            try
            {
                Add("1,2,-3,4");
                //if no exception is thrown, fail the case
                case1 = false;
            }
            catch (Exception e)
            {
                //if the message is not exactly this, fail the case
                case1 = e.Message.Equals("Negatives not allowed: -3");
            }
            
            //Testing two digits negative numbers and multiple negative numbers
            bool case2 = true;
            try
            {
                Add("1,-22,-3,-4");
                //if no exception is thrown, fail the case
                case2 = false;
            }
            catch (Exception e)
            {
                //if the message is not exactly this, fail the case
                case2 = e.Message.Equals("Negatives not allowed: -3");
            }
            
            if(!case1){throw new Exception("Test4 case1 failed");}
            if(!case2){throw new Exception("Test4 case2 failed");}
            
        }
        
        private static int Add(string numbers)
        {
            //Empty strings should return 0
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            
            int sum = 0;
            //default delimiter is comma
            string[] delimiter = new string[] {","};

            bool customDelimiter = false;
            if (numbers.Substring(0,2) == "//")
            {
                //find the first newline and take everything before it
                string newDelimiter = numbers.Split('\n')[0];
                //remove the slashes from the delimiter
                delimiter[0] = newDelimiter.Substring(2);
                customDelimiter = true;
            }
            
            //splitting up the string using the delimiter
            string[] individualNumbers = numbers.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            int index = 0;

            if (customDelimiter)
            {
                //skipping the first to avoid parsing the slashes as a number
                index = 1;
            }
            
            for (;index < individualNumbers.Length; index++)
            {
                string num = individualNumbers[index];
                int interpreted = int.Parse(num);
                sum += interpreted;
                
            }
            
            return sum;
        }
    }
}