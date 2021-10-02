using System;
using System.Threading;
using System.Diagnostics;

namespace ConsoleApplication2
{
    public class Exo2
    {
        static Mutex mut = new Mutex();
        public static void StartWork(Object obj)
        {
            var th = Thread.CurrentThread;
            if (th.Name == "t1")
                job('_', 1000, 50);
            else if (th.Name == "t2")
                job('*', 11000, 40);
            else if (th.Name == "t3")
                job('°', 9000, 20);
            
        }

        public static void job(char caractere, int time, int beat)
        {
            var sw = new Stopwatch();
            sw.Start();
            do
            {
                mut.WaitOne();
                Console.Write(caractere);
                mut.ReleaseMutex();
                Thread.Sleep(beat);
            } while (sw.ElapsedMilliseconds < time);
            sw.Stop();
        }

        public static void run()
        {
            Console.WriteLine("Lancement des threads :");
            
            Thread t1 = new Thread(StartWork);
            Thread t2 = new Thread(StartWork);
            Thread t3 = new Thread(StartWork);
            
            t1.Name = "t1";
            t2.Name = "t2";
            t3.Name = "t3";
            
            t1.Start();
            t2.Start();
            t3.Start();
        }
    }
}