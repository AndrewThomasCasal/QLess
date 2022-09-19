using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QLess.Models
{
    [Table("CardType")]
    public class CardType
    {
        public int Id { get; set; }
        public string CardTypeName { get; set; }
        public float InitialLoad { get; set; }
        public float RegularRate { get; set; }
        public float BaseDiscount { get; set; }
        public float AdditionalDiscount { get; set; }
        public int AdditionalDiscountMaxUsePerDay { get; set; }
        public int ValidityPeriod { get; set; }
    }
}
