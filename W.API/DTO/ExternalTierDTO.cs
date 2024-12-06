namespace W.API.DTO
{
    public class ExternalTierDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public List<ExternalDiscountCategoryDTO> ExternalDiscountCategoryDTOList { get; set; }
    }
}
