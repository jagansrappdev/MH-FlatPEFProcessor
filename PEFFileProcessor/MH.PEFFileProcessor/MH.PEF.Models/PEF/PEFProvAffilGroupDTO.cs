using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.PEF.Models.PEF
{
  public   class PEFProvAffilGroupDTO
    {
        // -- Unique key combination   -- start 
        [StringLength(10)]
        public string ProvNPI { get; set; }
        [StringLength(10)]
        public string ProvNCTracksId { get; set; }
        [StringLength(1)]
        public string ProvEnrollmentType { get; set; }
        // Refer: Service Location Code (key)
        [StringLength(3)]
        public string ProvSvcLocCode { get; set; }
        // -- Unique key combination   -- END 

        [StringLength(2)]
        public string AffilOrgTypeCode { get; set; }
        [StringLength(10)]
        public string AffilOrgNPI { get; set; }
        [StringLength(50)]
        public string AffilOrgTaxId { get; set; }
        [StringLength(50)]
        public string AffilOrgName { get; set; }
        [StringLength(3)]
        public string AffilOrgSvcLocCode { get; set; }
        [StringLength(10)]
        public string AffilOrgBeginDt { get; set; }
        [StringLength(10)]
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
