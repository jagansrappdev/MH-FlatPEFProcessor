using MH.PEF.BLL.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.PEF.BLL.DAL
{
    public class DbContext : IDisposable
    {
        internal const int Timeout_30_Minutes = 1800;
        internal const int Timeout_20_Minutes = 1200;
        internal const int Timeout_10_Minutes = 600;
        internal const int Timeout_5_Minutes = 300;
        internal const int Timeout_3_Minutes = 180;
        internal const int Timeout_2_Minutes = 120;
        internal const int Timeout_1_Minutes = 60;

        public ConnectionStringSettings DatabaseDefault { internal get; set; }

        internal IConnectionStrings Databases { get; private set; }

        internal DbContext(IConnectionStrings databases)
        {
            DatabaseDefault = databases.MHPefDb;
            Databases = databases;
        }

        protected string GetMHPefDb()
        {
            return Databases.MHPefDb.Name;
        }


        public void Dispose()
        {
            //Do nothing
        }
    }
}
