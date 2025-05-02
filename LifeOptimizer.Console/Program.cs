using LifeOptimizer.Data;
using LifeOptimizer.Domain;
using Microsoft.EntityFrameworkCore;

using (OptimizerContext context = new OptimizerContext())
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}

Console.WriteLine("Hello, Life Optimizer!");
//GetDrawers();
//AddDrawer();
//GetDrawers();

AddDrawerWithItem();
GetDrawersWithBooks();

void AddDrawerWithItem()
{
    var drawer = new Drawer
    {
        DrawerNumber = 1,
        Label = "Books",
        IsLocked = false
    };
    drawer.Items.Add(new Item
    {
        Name = "C# Programming",
        Category = "Books",
        Quantity = 1,
        Unit = "copy",
        ExpirationDate = null,
        IsExpired = false,
    });

    using var context = new OptimizerContext();
    context.Drawers.Add(drawer);
    context.SaveChanges();
}
void GetDrawersWithBooks()
{
    using var context = new OptimizerContext();
    var drawers = context.Drawers.Include(a => a.Items).ToList();

    foreach (var drawer in drawers)
    {
        Console.WriteLine($"Drawer ID: {drawer.Id}, Label: {drawer.Label}, Is Locked: {drawer.IsLocked}");
        foreach (var item in drawer.Items)
        {
            Console.WriteLine($"  Item Name: {item.Name}, Category: {item.Category}, Quantity: {item.Quantity}, Unit: {item.Unit}");
        }
    }

    void GetDrawers()
    {
        using var context = new OptimizerContext();
        var drawers = context.Drawers.ToList();
        foreach (var drawer in drawers)
        {
            Console.WriteLine($"Drawer ID: {drawer.Id}, Label: {drawer.Label}, Is Locked: {drawer.IsLocked}");
        }

    }

    void AddDrawer()
    {
        var drawer = new Drawer
        {
            DrawerNumber = 2,
            Label = "Files",
            IsLocked = true
        };
        using var context = new OptimizerContext();
        context.Drawers.Add(drawer);
        context.SaveChanges();
    }
}