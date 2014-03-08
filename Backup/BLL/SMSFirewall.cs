using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DALProfile;

namespace BLL
{
    public class SMSFirewall
    {
        /// <summary>
        ///根据报障号码过滤掉不合法的短信
        /// </summary>
        /// <param name="Stel"></param>
        /// <param name="FilterString"></param>
        /// <returns></returns>
        public bool FilterPhone(string Stel, string FilterString)
        {
            string[] Filters = FilterString.Split('|');
            if (FilterString.ToString().Trim().Length > 0 && Filters.Length == 0)
            {
                return Comparaphone(Stel, FilterString);
            }
            if (FilterString.ToString().Trim().Length == 0)
            {
                return true;
            }
            if (FilterString.ToString().Trim().Length > 0 && Filters.Length > 0)
            {
                bool result = false;
                for (int i = 0; i < Filters.Length; i++)
                {
                    if (Comparaphone(Stel, Filters[i].ToString().Trim()))
                    {
                        result = false;
                        break;
                    }
                    else
                    {
                        result = true;
                    }
                }
                return result;

            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 比较两个电话号码是否相同
        /// </summary>
        /// <param name="Stel"></param>
        /// <param name="comp"></param>
        /// <returns></returns>
        private bool Comparaphone(string Stel, string comp)
        {
            if (Stel.ToString().Trim() == comp.ToString().Trim())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
