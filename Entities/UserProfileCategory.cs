namespace Entities
{
    public class UserProfileCategory
    {
        public string UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        
    }
}
