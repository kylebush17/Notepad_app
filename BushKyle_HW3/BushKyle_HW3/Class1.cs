using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BushKyle_HW3
{
    /*
     * class inherits from System.IO.TextReader and uses overridden Textreader methods ReadToEnd and a new ReadLine function 
     * to generate the first x numbers of the fibonacci sequence given into the constructor. 
     */
    class FibonacciTextReader : System.IO.TextReader
    {
        private int Max;
      

        //constructor
        public FibonacciTextReader(int max)
        {
            Max = max;
        }

        //this function returns the next integer in the fibonacci sequence
        public string ReadLine(int i)
        {
            System.Numerics.BigInteger first = 0, second = 1, result = 0;   //use big integer to get past 47th fibonacci number

            if (i == 0) return "0"; //return the first two numbers as strings
            if (i == 1) return "1";

            for(int n = 2; n<=i;n++)    //fibonacci algorithm. could also use recursion if necessary
            {
                result = first + second;
                first = second;
                second = result;
            }

            return result.ToString(); //return the next number in the sequence as a string
        }

        //overridden ReadToEnd() function that calls the ReadLine function as many times as you want 
        //numbers in the sequence
        public  override string ReadToEnd()
        {
            StringBuilder fib = new StringBuilder();
            for(int i = 0; i<Max; i++)
            {
                fib.Append((i+1) + ": " + ReadLine(i)+ Environment.NewLine);

            }
            return fib.ToString(); //change string builder to a string
        }

    }
}
