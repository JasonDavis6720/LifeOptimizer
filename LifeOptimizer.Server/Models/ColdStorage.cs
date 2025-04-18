namespace LifeOptimizer.Server.Models
{
    public class ColdStorage: BaseStorage
    {
        public double Temperature { get; set; } // e.g., -18 degrees Celsius for a freezer
        public bool IsFrostFree { get; set; } // e.g., true or false        
        public DateTime LastDefrosted { get; set; } // e.g., 2023-10-01
        public DateTime NextDefrosted => LastDefrosted.AddMonths(12); // 12 months from LastDefrosted
    }
}
