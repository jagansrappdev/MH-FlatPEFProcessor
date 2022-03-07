using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.PEF.Models.PEF
{
    public class PEFProvRepeatGroups
    {
        // -- Unique key combination   
        public string ProvNPI { get; set; }
        public string ProvNCTracksId { get; set; }
        public string ProvEnrollmentType { get; set; }
        // Refer: Service Location Code (key)
        public string ProvSvcLocCode { get; set; }

        //R-1 :
        public string DhhsSpAmhTierInfoGroup5x { get; set; } // Len: 105 ; start: 1484

        //R-2:Provider Taxonomy Group (20x) : 2060-len (1589 to 3648)
        public string ProvTaxonomyGroup20x { get; set; }

        //R-3: Provider Business Type Group (3x)
        public string ProvBizTypeGroup3x { get; set; }  //Len : 60 ; Start: 3730

        //R-4: Affiliation Organization Group (10x)
        public string AffilOrgGroup10x { get; set; } // Len : 1350 ; start : 3833

        //R-5: Servicing Counties Group (100x)
        public string SvcCountiesGroup100x { get; set; } // len: 2300 ; Start: 5402
    }
}
