namespace LifeOptimizer.Application.Dtos
{
    public class ItemDto
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool IsExpired { get; set; }
    }
}
