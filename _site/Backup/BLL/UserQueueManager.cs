using System;
using System.Collections.Generic;
using System.Text;
using DALProfile;

namespace BLL
{
    public class UserQueueManager
    {
        UserQueueManager uqm = new UserQueueManager();
        public void AddUserQueue(string username, int queueid)
        {
            uqm.AddUserQueue(username, queueid);
        }
    }
}
