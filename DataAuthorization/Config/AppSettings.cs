using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAuthorization.Config
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string DbConnection { get; set; }
    }
}
