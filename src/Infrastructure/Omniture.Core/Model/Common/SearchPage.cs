using System;
using System.Collections.Generic;
using System.Text;

namespace Omniture.Core.Model.Common
{
    public class SearchByDate
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public int? ExpeneTypeId { get; set; }
    }
}
