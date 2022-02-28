using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.PEF.Models.PEF
{
    public class PEFProviderOfficeDTO
    {

        public string ProvNPI { get; set; }
        public string ProvNCTracksId { get; set; }
        // Always =1 for Prov.office table
        public string ProvEnrollmentType { get; set; }

        // ****  ------ NotSure ifthe below is exact ask from SUE for SvcLocation   ------------

        // Refer: Service Location Code (key)
        public string ProvSvcLocCode { get; set; }
        public string ProvSvcLocBeginDt { get; set; }
        public string ProvSvcLocEndDt { get; set; }
        public string ProvSvcLocName { get; set; }
        public string ProvSvcLocAddress1 { get; set; }
        public string ProvSvcLocAddress2 { get; set; }
        public string ProvSvcLocCity { get; set; }
        public string ProvSvcLocState { get; set; }
        public string ProvSvcLocZip { get; set; }
        public string ProvSvcLocCountryCode { get; set; }
        public string ProvSvcLocPhone { get; set; }
        public string ProvSvcLocSiteVisitIndicator { get; set; }


    }
}
