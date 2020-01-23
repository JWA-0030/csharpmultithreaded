using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment9
{

    public class Program
    {
        //assignment says int but in class you use double and a double makes more sense
        static double[] data = new double[10000000];
        static Thread[] multithread = new Thread[4];

        static void Main(string[] args)
        {
            DateTime startTime = DateTime.Now;
            Calc(0, data.Length);
            TimeSpan endTime = DateTime.Now - startTime;

            Console.WriteLine("Sequentially, calc takes {0} milliseconds to run.",endTime.TotalMilliseconds);

            int quarterData = data.Length / 4;
            int j=0;

            DateTime startTimeThread = DateTime.Now;
            
            for(int i=0;i< 4 ;i++)
            {
                multithread[i] = new Thread(new ThreadStart(() => Calc( (j++) * quarterData, quarterData)));
                multithread[i].Start();
            }

            foreach(Thread t in multithread)
            {
                t.Join();
            }

            TimeSpan endTimeMulti = DateTime.Now - startTime;

            Console.WriteLine("Multithreaded, calc takes {0} milliseconds to run.", endTimeMulti.TotalMilliseconds);

        }

        static void Calc(int startingIndex, int reps)
        {

            for(int i = startingIndex; i < startingIndex + reps; i++)
            {

                data[i] = Math.Atan(i) * Math.Acos(i) * Math.Cos(i) * Math.Sin(i);
            }
        }
    }
}
