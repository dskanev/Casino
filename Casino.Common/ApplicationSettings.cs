using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Common
{
    public class ApplicationSettings
    {
        public string Secret { get; private set; }

        public string Username { get; set; }
    }
}
