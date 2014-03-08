using System;
using System.Collections.Generic;
using System.Text;
using DALProfile;
using Model;

namespace BLL
{
    public class SMSConfigManager
    {
        private SMSConfigOpera sco = new SMSConfigOpera();
        public SendSMS GetSMSconfig(string path)
        {
            return sco.GETSMSConfig(path);
        }


        public void ModiftySMSConf(string path, string ip, string port)
        {
            sco.ModiftySMSConf(path, ip, port);
        }
    }
}
