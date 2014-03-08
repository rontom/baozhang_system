using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class room
    {
        public room() { }
        private int roomid;

        public int Roomid
        {
            get { return roomid; }
            set { roomid = value; }
        }
        private string roomname;

        public string Roomname
        {
            get { return roomname; }
            set { roomname = value; }
        }
        private int build;

        public int Build
        {
            get { return build; }
            set { build = value; }
        }
        private string intro;

        public string Intro
        {
            get { return intro; }
            set { intro = value; }
        }
    }
}
