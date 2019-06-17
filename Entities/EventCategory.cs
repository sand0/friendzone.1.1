namespace Entities
{
    public class EventCategory
    {
        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
