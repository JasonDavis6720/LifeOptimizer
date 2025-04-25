using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeOptimizer.Server.Models
{
    public class Cabinet : BaseStorage
    {
        // Name of the cabinet (e.g., "Office Cabinet")

        // Navigation Property to Drawers
        public List<Drawer> Drawers { get; set; } = new List<Drawer>();
    }
}
