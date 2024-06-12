namespace GymMe.Models
{
    public class SupplementType
    {
        public int SupplementTypeID { get; set; }
        public string Name { get; set; }
        public ICollection<Supplement> Supplements { get; set; }
    }
}
