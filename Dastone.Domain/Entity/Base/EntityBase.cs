using Dastone.Domain.Enum;

namespace Dastone.Domain.Entity.Base
{
    public class EntityBase
    {
        public long Id { get; set; }
        public DateTime RegisterDate { get; set; }= DateTime.Now;
        public DateTime? ChangeDate { get; set; }
        public Situations Situations { get; set; }
        public string Observation { get; set; }
    }
}
