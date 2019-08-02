using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataAuthorization.DataBase.Extentions;

namespace DataAuthorization.DataBase.Entities
{
    public class OwnedByBase : IOwnedBy
    {
        public string OwnedBy { get; private set; }

        public void SetOwnedBy(string protectKey)
        {
            OwnedBy = protectKey;
        }
    }
}
