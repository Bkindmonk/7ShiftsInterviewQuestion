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

            if(!case1){throw new Exception("case1 failed");}
            if(!case2){throw new Exception("case2 failed");}
            if(!case3){throw new Exception("case3 failed");}
            if(!case4){throw new Exception("case4 failed");}
        }
        private static int Add(string numbers){
            return -1;
        }
    }
}