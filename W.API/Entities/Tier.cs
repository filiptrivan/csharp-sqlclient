namespace W.API.Entities
{
    public class Tier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<DiscountProductCategory> DiscountProductCategories { get; set; }
    }
}
