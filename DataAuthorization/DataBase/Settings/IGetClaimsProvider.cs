using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAuthorization.DataBase.Extentions
{
    public interface IGetClaimsProvider
    {
        string UserId { get; }
    }
}
