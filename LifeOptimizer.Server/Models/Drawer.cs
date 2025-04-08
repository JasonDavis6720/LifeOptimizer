namespace LifeOptimizer.Server.Models
{
    public class Drawer
    {
        public int DrawerNumber { get; set; } // e.g., 1, 2, 3
        public string Label { get; set; } // e.g., "Stationery", "Files"
        public bool IsLocked { get; set; } // e.g., true or false
    }
}
