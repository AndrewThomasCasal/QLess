using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QLess.Models
{
    [Table("TransactionType")]
    public class TransactionType
    {
        public int Id { get; set; }
        public string TransactionTypeName { get; set; }
    }
}
