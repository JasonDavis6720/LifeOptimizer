using LifeOptimizer.Server.Models;

namespace LifeOptimizer.Server.Interfaces
{
    public interface IDrawerService
    {
        void AddDrawer(Cabinet cabinet, Drawer drawer);
        void RemoveDrawer(Cabinet cabinet, int drawerNumber);
        void UpdateDrawerLabel(Cabinet cabinet, int drawerNumber, string newLabel);
    }

}
