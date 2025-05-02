namespace LifeOptimizer.Domain
{
    public class Drawer
    {
        public int Id { get; set; }
        public int DrawerNumber { get; set; }
        public string Label { get; set; }
        public bool IsLocked { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
    }
}
