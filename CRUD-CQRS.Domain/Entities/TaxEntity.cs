namespace CRUD_CQRS.Domain.Entities
{
    public class TaxEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Value { get; set; }
    }
}
