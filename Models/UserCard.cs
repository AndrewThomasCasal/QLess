using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QLess.Models
{
    [Table("UserCard")]
    public class UserCard
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        
        public int CardId { get; set; }

        public UserCard(int id, int userId, int cardId)
        {
            Id = id;
            UserId = userId;
            CardId = cardId;
        }
        public UserCard(int userId, int cardId)
        {
            UserId = userId;
            CardId = cardId;
        }
    }
}
