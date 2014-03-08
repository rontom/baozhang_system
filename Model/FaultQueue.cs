using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class FaultQueue
    {
        public FaultQueue() { }
        private int queueid;

        public int Queueid
        {
            get { return queueid; }
            set { queueid = value; }
        }
        private int faultid;

        public int Faultid
        {
            get { return faultid; }
            set { faultid = value; }
        }
        private int priority;

        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }
    }
}
