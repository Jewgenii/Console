using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace console
{
    public class OutOfRange : Exception
    {
        protected readonly string message;
        public OutOfRange():base()
        {
            
        }
        public OutOfRange(string str): base(str)
        {
            message = str;
        }
        public OutOfRange(string message, Exception innerException):
            base(message, innerException)
        {

        }
        public override string Message
        {
            get
            {
                return this.message;
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            #region MyRegion
            /*
           foreach (string s in args)
               Console.WriteLine(s);
           try
           {
               int[] arr1 = { 1, 2, 3, 4, 5, 0 };
               int[] arr2 = { 1, 0, 0 };

               for (int i = 0; i < arr1.Length; i++)
                   try
                   {
                       int res = arr1[i] / arr2[i];
                       throw new Exception();
                   }
                   catch (DivideByZeroException e)
                   {

                       Console.WriteLine(e.Message);
                       throw new OutOfRange("hmmm",e);
                   }
                   catch (IndexOutOfRangeException e)
                   {
                       Console.WriteLine(e.Message);
                       throw;
                   }
                   catch (OutOfRange)
                   {
                       throw;
                   }
           }
           catch (Exception e)
           {
               Console.WriteLine(e);
               Console.WriteLine();
               Console.WriteLine(e.InnerException);
               Console.WriteLine();
               Console.WriteLine(e.Message);
               Console.WriteLine();
               Console.WriteLine(e.TargetSite);
               Console.WriteLine();
               Console.WriteLine("source {0}",e.Source);
               Console.WriteLine();
               Console.WriteLine(e.StackTrace);

           }
           */
            #endregion

            RangeArray r1 = new RangeArray(-1, 2);
            try
            {
                for (int i = r1.LowerBound; i <= 55; i++)
                {
                    checked//overflow exception is thrown is its overflowed
                    {
                        r1[i] = i*i;
                    }

                    unchecked//ignors overflow  for block
                    {
                        r1[i] = i * i;
                    }

                    r1[i] = checked(i * i);//overflow exception is thrown is its overflowed

                    r1[i] = unchecked(i * i);//ignores overflow for specific expression

                    Console.WriteLine(r1[i]);
                }
            }
          
            catch (OutOfRange e)
            {
                Console.WriteLine(e);
            }
            catch (OverflowException)
            {

            }
            catch (Exception)
            {

            }



            Console.ReadKey(true);
        }
    }

    public class RangeArray:IEnumerator,IEnumerable
    {
        public RangeArray(int lower,int upper)
        {
            if (lower >= upper) throw new OutOfRange("Out of range");
            LowerBound = lower;
            UpperBound = upper;
            arr = new int[++upper - LowerBound];
            Length = UpperBound - LowerBound;
        }

        public int Length { get; private set; }
        int[] arr;
        private int index;
        public int LowerBound { get; private set; }
        public int UpperBound { get; private set; }

        public int this[int index]
        {
            get
            {
                if (ok(index))
                {
                    return arr[index - LowerBound];
                }
                else
                {
                    throw new OutOfRange("Out of range");
                }
            }
            set
            {
                if (ok(index))
                {
                    arr[index - LowerBound] = value;
                }
                else
                    throw new OutOfRange("Out of range");
            }
        }

        private bool ok(int index)
        {
            if (index >= LowerBound && index <= UpperBound)
                return true;
            else
                return false;
        }

        public object Current
        {
            get
            {
                return arr[index];
            }
        }

        public bool MoveNext()
        {
           return  ++index< UpperBound - LowerBound;
        }

        public void Reset()
        {
            index = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }
    }
}
