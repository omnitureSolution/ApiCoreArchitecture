using Omniture.Db;
using System;
using System.ComponentModel.DataAnnotations;
using Omniture.Db.Abstractions.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Omniture.Db.Entity.Notification
{
  
    public class User : BaseEntity
    {
        [Key]
        public int UserId { get; set; }
        public object Email { get; set; }
        public string ImageUrl { get; set; }
    }
}
