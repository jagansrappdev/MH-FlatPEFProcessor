using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.PEF.BLL.Configuration
{
    public interface IConnectionStrings
    {

        ConnectionStringSettings MHPefDb { get; }
        ConnectionStringSettings DataWarehouseTrustedConnection { get; }
        ConnectionStringSettings IntegrationApplication { get; }

    }
}
