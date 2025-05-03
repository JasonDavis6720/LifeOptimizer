namespace LifeOptimizer.Domain
{

    public class Shelf
    {
        public int ShelfId { get; set; }
        public string Label { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();


    }
}