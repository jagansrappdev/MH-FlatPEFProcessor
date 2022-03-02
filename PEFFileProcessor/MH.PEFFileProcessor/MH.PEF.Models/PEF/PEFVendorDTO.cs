using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.PEF.Models.PEF
{
   public class PEFVendorDTO
    {

        public string ProvNPI { get; set; }
        public string ProvNCTracksId { get; set; }

        // Enrol-type  = 2 & 4 for Prov.Vendor table
        public string ProvEnrollmentType { get; set; }

        public string ProvTaxId { get; set; }

        // Set A TrxSetId for tracking 
        public int MhTrnxId { get; set; }
        //
        // #6. REPEATS ; Refer: Affiliation Organization Group (10x)
     //   public string AffilOrgGroup10x { get; set; }
        public string AffilOrgTypeCode { get; set; }
        public string AffilOrgNPI { get; set; }
        public string AffilOrgTaxId { get; set; }
        public string AffilOrgName { get; set; }
        public string AffilOrgSvcLocation { get; set; }
        public string AffilOrgBeginDt { get; set; }
        public string AffilOrgEndDt { get; set; }

    }
}
