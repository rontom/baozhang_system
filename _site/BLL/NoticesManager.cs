using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DALProfile;

namespace BLL
{
    public class NoticesManager
    {
        NoticeOpera nop = new NoticeOpera();


        /// <summary>
        /// 添加新消息
        /// </summary>
        /// <param name="fromuser">通知的发布者</param>
        /// <param name="touser">通知的接受者（不同的接受者之间用|号隔开）</param>
        /// <param name="noticecontent">通知内容</param>
        /// <param name="sendtime">发送时间</param>
        /// <param name="menth">发布方式</param>
        /// <param name="validity">有效期限</param>
        public void AddNotices(string title, string fromuser, string touser, string noticecontent, DateTime sendtime, string menth, int validity, string usernamestring)
        {
            nop.addnotice(title,fromuser, touser, noticecontent, sendtime, menth, validity,usernamestring);
        }
    }
}
