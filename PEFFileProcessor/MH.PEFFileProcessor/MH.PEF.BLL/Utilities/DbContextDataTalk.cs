using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MH.PEF.BLL.Utilities
{
    public class DbContextDataTalk
    {
        protected const int Timeout_30_Minutes = 1800;
        protected const int Timeout_20_Minutes = 1200;
        protected const int Timeout_10_Minutes = 600;
        protected const int Timeout_5_Minutes = 300;
        protected const int Timeout_3_Minutes = 180;
        protected const int Timeout_2_Minutes = 120;
        protected const int Timeout_1_Minutes = 60;

        public ConnectionStringSettings ConnectionStringReadSettings { get; private set; }
        public ConnectionStringSettings ConnectionStringWriteSettings { get; private set; }


        public DbContextDataTalk(ConnectionStringSettings connectionStringRead, ConnectionStringSettings connectionStringWrite)
        {
            ConnectionStringReadSettings = connectionStringRead;
            ConnectionStringWriteSettings = connectionStringWrite;
        }
    }
}
