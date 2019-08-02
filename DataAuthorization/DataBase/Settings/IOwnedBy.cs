using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAuthorization.DataBase.Extentions
{
    public interface IOwnedBy
    {
        //This holds the UserId of the person who created it
        string OwnedBy { get; }
        //This the method to set it
        void SetOwnedBy(string protectKey);
    }
}
