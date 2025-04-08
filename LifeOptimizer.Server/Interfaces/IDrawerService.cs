using LifeOptimizer.Server.Models;

namespace LifeOptimizer.Server.Interfaces
{
    public interface IDrawerService
    {
        void AddDrawer(OfficeCabinet cabinet, Drawer drawer);
        void RemoveDrawer(OfficeCabinet cabinet, int drawerNumber);
        void UpdateDrawerLabel(OfficeCabinet cabinet, int drawerNumber, string newLabel);
    }

}
