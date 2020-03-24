using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace week3Run
{

    
    public class MyTimerClass
    {
        private int secondsInterval;
        private bool doLoop;
        private int maxLoopCount;
        private int loopCount;
        public event EventHandler Elapsed;

        public virtual void OnElapsed(EventArgs e)
        {
            if (this.Elapsed != null)
                {
                this.Elapsed(this, e);
                }

            Console.WriteLine("Event Triggered # :"+LoopCount +"of " + MaxLoopCount +  " at each "+ (Interval/ 1000)+" seconds ");
        }

        public int Interval { get => secondsInterval; set => secondsInterval = value; }

        public bool DoLoop { get => doLoop; set => doLoop = value; }

        public int MaxLoopCount { get =>maxLoopCount; set => maxLoopCount = value; }

        public int LoopCount { get =>loopCount; set =>loopCount=value; }

        public MyTimerClass(int seconds)
        {
            Interval = seconds;
            DoLoop = false;
            
        }

        public MyTimerClass(int seconds, bool doLoop)
        {
            Interval = seconds; 
            DoLoop   = true;
            MaxLoopCount = 10;

        }

        //Start Function 
        public void Start()
        {
            //check if we have a loop defined
            if(DoLoop)
            {

                //execute until a event finishes the loop
                while(true)
                {
                    Thread.Sleep(Interval);
                    OnElapsed(EventArgs.Empty);
                    LoopCount++;
                    
                    if(LoopCount > MaxLoopCount)
                    {
                        break;
                    }
                }
            }
            else
            {
                //one time event
                Thread.Sleep(Interval);
                OnElapsed(EventArgs.Empty);
            }
        }

        public void Dispose()
        {
            Interval = 0;
            DoLoop = false;
            MaxLoopCount = 0;

        }

    }
}
