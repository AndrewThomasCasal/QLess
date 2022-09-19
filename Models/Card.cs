using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QLess.Models
{
    [Table("Card")]
    public class Card
    {
        public int Id { get; set; }
        public int CardTypeId { get; set; }
        public float Balance { get; set; }
        public DateTime ValidityDate { get; set; }
        public DateTime? LastUsedDate { get; set; }
        public string SeniorCitizenNum { get; set; }
        public string PWDNum { get; set; }

        public Card()
        {

        }

        public Card(
            int id, 
            int cardTypeId, 
            float balance, 
            DateTime validityDate, 
            DateTime? lastUsedDate,
            string seniorCitizenNum,
            string pwdNum)
        {
            Id = id;
            CardTypeId = cardTypeId;
            Balance = balance;
            ValidityDate = validityDate;
            LastUsedDate = lastUsedDate;
            SeniorCitizenNum = seniorCitizenNum;
            PWDNum = pwdNum;
        }

        public Card(
            int cardTypeId, 
            float balance, 
            DateTime validityDate,
            DateTime? lastUsedDate,
            string seniorCitizenNum,
            string pwdNum)
        {
            CardTypeId = cardTypeId;
            Balance = balance;
            ValidityDate = validityDate;
            LastUsedDate = lastUsedDate;
            SeniorCitizenNum = seniorCitizenNum;
            PWDNum = pwdNum;
        }
    }
}
