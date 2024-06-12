using System.Collections.Generic;

namespace GymMe.Models
{
    public class MsSupplementType
    {
        public int SupplementTypeID { get; set; }
        public string SupplementTypeName { get; set; }

        public virtual ICollection<MsSupplement> Supplements { get; set; }
    }
}
