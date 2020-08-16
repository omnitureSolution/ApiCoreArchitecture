using iSocietyCare.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iSocietyCare.NotificationService.Models;

namespace iSocietyCare.NotificationService.DbEntity
{
    public class NotificationFeature : BaseEntity
    {
        [Key]
        public int NotificationFeatureId { get; set; }
        public string FeatureName { get; set; }
        public int TypeOfFeature { get; set; }
        public Boolean IsActive { get; set; }
        public String FeatureEndPoint { get; set; }
        public int? ParentFeatueId { get; set; }
        [ForeignKey("ParentFeatueId")]
        public NotificationFeature ParentFeature { get; set; }
        public IList<Notification> Notifications { get; set; }
    }

}
