using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.PEF.Models.PEF
{
  public   class PEFProvTaxonomyGrp
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

        // #4. REPEATS-4 ; Refer: Provider Taxonomy Group (20x) : 2060-len (1589 to 3648)

      //  public string ProvTaxonomyGroup20x { get; set; }

        [StringLength(10)]
        public string TaxonomyCode { get; set; }
        [StringLength(10)]
        public string TaxonomyLvl2Code { get; set; }
        [StringLength(10)]
        public string TaxonomyLvl3Code { get; set; }
        //
        [StringLength(1)]
        public string TaxonomyCodeStatusCurrent { get; set; }
        [StringLength(10)]
        public string TaxonomyCodeEffDateCurrent { get; set; }
        [StringLength(10)]
        public string TaxonomyCodeEndDateCurrent { get; set; }
        //
        [StringLength(1)]
        public string TaxonomyCodeStatusPrev01 { get; set; }
        [StringLength(10)]
        public string TaxonomyCodeEffDatePrev01 { get; set; }
        [StringLength(10)]
        public string TaxonomyCodeEndDatePrev01 { get; set; }
        //
        [StringLength(1)]
        public string TaxonomyCodeStatusPrev02 { get; set; }
        [StringLength(10)]
        public string TaxonomyCodeEffDatePrev02 { get; set; }
        [StringLength(10)]
        public string TaxonomyCodeEndDatePrev02 { get; set; }
        //
        [StringLength(10)]
        public string TaxonomyCodeRetroTrigger { get; set; }
        // kept for 
       //  public string Filler60of3649Pos { get; set; }
    }


    public class ProvTaxonomyLineDTO
    {
        public string ProvNPI { get; set; }
        public string ProvNCTracksId { get; set; }
        public string ProvEnrollmentType { get; set; }
        // Refer: Service Location Code (key)
        public string ProvSvcLocCode { get; set; }

        // -- Unique key combination   -- END  

        // #4. REPEATS-4 ; Refer: Provider Taxonomy Group (20x) : 2060-len (1589 to 3648)

        public string ProvTaxonomyGroup20x { get; set; }
    }


     public class TaxonomyGroup
    {
      //public string ProvTaxonomyGroup20x { get; set; }
        public string TaxonomyCode { get; set; }
        public string TaxonomyLvl2Code { get; set; }
        public string TaxonomyLvl3Code { get; set; }
        public string TaxonomyCodeStatusCurrent { get; set; }
        public string TaxonomyCodeEffDateCurrent { get; set; }
        public string TaxonomyCodeEndDateCurrent { get; set; }
        //
        public string TaxonomyCodeStatusPrev01 { get; set; }
        public string TaxonomyCodeEffDatePrev01 { get; set; }
        public string TaxonomyCodeEndDatePrev01 { get; set; }
        //
        public string TaxonomyCodeStatusPrev02 { get; set; }
        public string TaxonomyCodeEffDatePrev02 { get; set; }
        public string TaxonomyCodeEndDatePrev02 { get; set; }
        public string TaxonomyCodeRetroTrigger { get; set; }
        // kept for 
       //ublic string Filler60of3649Pos { get; set; }
    }


}
