using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.PEF.Models.PEF
{
  public   class PEFDhhsAMhTierInfoGrp5xDTO
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

        // #3. REPEATS-3 ; Refer: DHHS SP AMH Tier Information Group (5x) : 105-len(1484 to 1588)
    //    [StringLength(105)]
    //    public string DhhsSpAmhTierInfoGroup5x { get; set; }

        [StringLength(1)]
        public string DHHSSpAMHTierTypeCode { get; set; }          //Length: 1 
        [StringLength(10)]
        public string DHHSSpAMHTierEffectiveDt { get; set; }      //Length: 10
        [StringLength(10)]
        public string DHHSSpAMHTierEndDt { get; set; }           //Length: 10 

    }
}
