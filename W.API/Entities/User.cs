namespace W.API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int Points { get; set; }
        public Tier Tier { get; set; }
    }
}
