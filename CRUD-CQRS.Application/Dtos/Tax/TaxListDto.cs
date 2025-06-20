namespace CRUD_CQRS.Application.Dtos.Tax
{
    public class TaxListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Value { get; set; }
    }
}
