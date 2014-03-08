using System;
using System.Collections.Generic;
using System.Text;
using DALProfile;
using System.Data;
using Model;

namespace BLL
{
    public class PhoneBookManager
    {
        private PhoneBookOpera pbo=new PhoneBookOpera();
        public void Add(string phonebookname, string usernames)
        {
            pbo.Add(phonebookname, usernames);
        }

        public DataTable GetPhoneBook()
        {
            return pbo.GetPhoneBook();
        }


        /// <summary>
        /// 获取一个电话簿对象
        /// </summary>
        /// <param name="phonebookid"></param>
        /// <returns></returns>
        public PhoneBook GetAphoneBook(int phonebookid)
        {
            return pbo.GetAphoneBook(phonebookid);
        }



        /// <summary>
        /// 更新电话簿组
        /// </summary>
        /// <param name="Phonebookid"></param>
        /// <param name="telbook"></param>
        /// <param name="users"></param>
        public void UpdatePhoneBook(int Phonebookid, string telbook, string users)
        {
            pbo.UpdatePhoneBook(Phonebookid, telbook, users);
        }
    }


}
