using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class PhoneBook
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string telbook;

        public string Telbook
        {
            get { return telbook; }
            set { telbook = value; }
        }
    }
}
