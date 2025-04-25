using LifeOptimizer.Server.Interfaces;
using LifeOptimizer.Server.Models;

namespace LifeOptimizer.Server.Services
{
    public class DrawerService : IDrawerService
    {
        public void AddDrawer(Cabinet cabinet, Drawer drawer)
        {
            if (cabinet.Drawers.Any(d => d.DrawerNumber == drawer.DrawerNumber))
            {
                throw new InvalidOperationException($"Drawer {drawer.DrawerNumber} already exists in the cabinet.");
            }

            cabinet.Drawers.Add(drawer);
        }

        public void RemoveDrawer(Cabinet cabinet, int drawerNumber)
        {
            var drawer = cabinet.Drawers.FirstOrDefault(d => d.DrawerNumber == drawerNumber);
            if (drawer != null)
            {
                cabinet.Drawers.Remove(drawer);
            }
            else
            {
                throw new InvalidOperationException($"Drawer {drawerNumber} does not exist in the cabinet.");
            }
        }

        public void UpdateDrawerLabel(Cabinet cabinet, int drawerNumber, string newLabel)
        {
            var drawer = cabinet.Drawers.FirstOrDefault(d => d.DrawerNumber == drawerNumber);
            if (drawer != null)
            {
                drawer.Label = newLabel;
            }
            else
            {
                throw new InvalidOperationException($"Drawer {drawerNumber} does not exist in the cabinet.");
            }
        }
    }
}