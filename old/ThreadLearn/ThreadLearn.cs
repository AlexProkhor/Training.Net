using System;
using System.Threading;

namespace ThreadLearn
{

    class ThreadLearn
    {
        static object locker = new object();
        static void Main(string[] args)
        {
            // создаем новый поток
            Thread myPing = new Thread(new ThreadStart(PingThread));
            Thread myPong = new Thread(new ThreadStart(PongThread));

            myPing.Start(); // запускаем поток
            myPong.Start(); // запускаем поток
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// Print message to console.
        /// </summary>
        /// <param name="message">Thread message</param>
        public static void Print(string message)
        {
            lock (locker)
            {
                Console.WriteLine(message);
            }
        }

        /// <summary>
        /// Thread whith Ping.
        /// </summary>
        public static void PingThread()
        {
            string message = "Ping";
            while (true)
            {
                Thread.Sleep(300);
                Print(message);
            }
        }

        /// <summary>
        /// Thread whith Pong.
        /// </summary>
        public static void PongThread()
        {
            string message = "Pong";
            while (true)
            {
                Thread.Sleep(300);
                Print(message);
            }
        }
    }
}
