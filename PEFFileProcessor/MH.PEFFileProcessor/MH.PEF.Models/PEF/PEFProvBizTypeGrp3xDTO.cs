using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.PEF.Models.PEF
{
   public  class PEFProvBizTypeGrp3xDTO
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


        [StringLength(1)]
        public string ProvBizTypeCode { get; set; }
        [StringLength(10)]
        public string ProvBizTypeBeginDt { get; set; }
        [StringLength(10)]
        public string ProvBizTypeEndDt { get; set; }
    }
}
