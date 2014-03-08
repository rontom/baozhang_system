using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class CommonGuzhang
    {
        public CommonGuzhang() { }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string guzhangcontent;

        public string Guzhangcontent
        {
            get { return guzhangcontent; }
            set { guzhangcontent = value; }
        }
    }
}
