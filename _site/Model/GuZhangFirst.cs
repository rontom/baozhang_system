using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class GuZhangFirst
    {
        private int guZhangFirstID;

        public int GuZhangFirstID
        {
            get { return guZhangFirstID; }
            set { guZhangFirstID = value; }
        }
        private string telephone;

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        private string messageContent;

        public string MessageContent
        {
            get { return messageContent; }
            set { messageContent = value; }
        }
        private bool isTyped;

        public bool IsTyped
        {
            get { return isTyped; }
            set { isTyped = value; }
        }
        private DateTime receivedDate;
        private string menth;

        public string Menth
        {
            get { return menth; }
            set { menth = value; }
        }

        public DateTime ReceivedDate
        {
            get { return receivedDate; }
            set { receivedDate = value; }
        }

        private bool _isdoing;

        public bool Isdoing
        {
            get { return _isdoing; }
            set { _isdoing = value; }
        }
        private bool _issend;

        public bool Issend
        {
            get { return _issend; }
            set { _issend = value; }
        }
        private bool _isnewsest;

        public bool Isnewsest
        {
            get { return _isnewsest; }
            set { _isnewsest = value; }
        }
    }
}
