namespace LifeOptimizer.Server.Models
{
    public class OfficeCabinet : BaseStorage
    {
        public List<Drawer> Drawers { get; set; } = new List<Drawer>(); // Collection of drawers
    }
}
