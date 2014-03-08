using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class queue
    {
        public queue() {}
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string queuename;

        public string Queuename
        {
            get { return queuename; }
            set { queuename = value; }
        }
        private DateTime createtime;

        public DateTime Createtime
        {
            get { return createtime; }
            set { createtime = value; }
        }

    }
}
