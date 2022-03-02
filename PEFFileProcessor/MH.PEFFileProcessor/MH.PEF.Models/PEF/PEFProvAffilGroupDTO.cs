using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.PEF.Models.PEF
{
  public   class PEFProvAffilGroupDTO
    {
        public string ProvNPI { get; set; }
        public string ProvNCTracksId { get; set; }
        public string ProvEnrollmentType { get; set; }
        public string ProvSvcLocCode { get; set; }

        //
         public string AffilOrgGroup10x { get; set; }
        //
        public string AffilOrgTypeCode { get; set; }
        public string AffilOrgNPI { get; set; }
        public string AffilOrgTaxId { get; set; }
        public string AffilOrgName { get; set; }
        public string AffilOrgSvcLocation { get; set; }
        public string AffilOrgBeginDt { get; set; }
        public string AffilOrgEndDt { get; set; }
    }

    //
    public class AffilGroup
    {
        public string AffilOrgTypeCode { get; set; }
        public string AffilOrgNPI { get; set; }
        public string AffilOrgTaxId { get; set; }
        public string AffilOrgName { get; set; }
        public string AffilOrgSvcLocation { get; set; }
        public string AffilOrgBeginDt { get; set; }
        public string AffilOrgEndDt { get; set; }
    }
}
