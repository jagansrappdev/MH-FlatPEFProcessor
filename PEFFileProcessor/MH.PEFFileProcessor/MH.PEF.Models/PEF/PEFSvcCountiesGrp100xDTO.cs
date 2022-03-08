using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.PEF.Models.PEF
{
   public  class PEFSvcCountiesGrp100xDTO
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
        // Order # - for unique record 
        public Int64? Order { get; set; }

        [StringLength(3)]
        public string SvcCountyCode { get; set; }
        [StringLength(10)]
        public string SvcCountyBeginDt { get; set; }
        [StringLength(10)]
        public string SvcCountyEndDt { get; set; }
    }

    public class SvcCountiesGrp
    {
        public string SvcCountyCode { get; set; }
        public string SvcCountyBeginDt { get; set; }
        public string SvcCountyEndDt { get; set; }
    }
}
