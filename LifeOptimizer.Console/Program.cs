using LifeOptimizer.Data;
using LifeOptimizer.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

using (OptimizerContext context = new OptimizerContext())
{
    //context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}

Console.WriteLine("Hello, Life Optimizer!");
//AddDrawer();
//AddDrawerWithItem();
//GetDrawersWithItems();
//AddShelf();
//AddShelfWithItem();
//AddStorageItemWithShelf();
//AddStorageItem();
//GetShelvesWithItems();
//AddItem();
//AddItemToShelf(1, 1);
GetStorageItemsWithItems();
//TEST METHODS

void AddItem()
{
    var item = new Item
    {
        Name = "Sample Item",
        Category = "General",
        Quantity = 10,
        Unit = "pcs",
        ExpirationDate = null,
        IsExpired = false
    };
    using var context = new OptimizerContext();
    context.Items.Add(item);
    context.SaveChanges();
    Console.WriteLine($"Item '{item.Name}' added with ID: {item.ItemId}");
}

void AddItemToShelf(int shelfId, int itemId)
{
    using var context = new OptimizerContext();
    var shelf = context.Shelves.Include(s => s.Items).FirstOrDefault(s => s.ShelfId == shelfId);

    if (shelf != null)
    {
        var item = context.Items.Find(itemId);
        shelf.Items.Add(item);
        context.SaveChanges();
        Console.WriteLine($"Item '{item.Name}' added to Shelf ID: {shelfId}, Shelf Name: {shelf.Label}");
    }
    else
    {
        Console.WriteLine($"Shelf with ID: {shelfId} not found.");
    }

}

void AddStorageItemWithShelf()
{
    var storageItem = new StorageItem
    {
        Name = "Living Room Bookshelf",
        Type = "Bookshelf"
    };

    storageItem.Shelves.Add(new Shelf
    {
        Label = "Bottom Shelf",
    });

    using var context = new OptimizerContext();
    context.StorageItems.Add(storageItem);
    context.SaveChanges();
}

void AddStorageItem()
{
    var storageItem = new StorageItem
    {
        Name = "Kitchen Cabinet",
        Type = "Cabinet",
    };
    using var context = new OptimizerContext();
    context.StorageItems.Add(storageItem);
    context.SaveChanges();
}
void AddShelf()
{
    var shelf = new Shelf
    {
        Label = "Top Shelf",
    };
    using var context = new OptimizerContext();
    context.Shelves.Add(shelf);
    context.SaveChanges();
}

void AddShelfWithItem()
{
    var shelf = new Shelf
    {
        Label = "Item Shelf"
    };

    shelf.Items.Add(new Item
    {
        Name = "Shelf Book Test",
        Category = "Test",
        Quantity = 5,
        Unit = "copy",
    });

    using var context = new OptimizerContext();
    context.Shelves.Add(shelf);
    context.SaveChanges();
}

void GetStorageItemsWithItems()
{
    using var context = new OptimizerContext();
    var storageItems = context.StorageItems
        .Include(si => si.Items)
        .Include(si => si.Shelves)
        .ThenInclude(s => s.Items)
        .ToList();
    foreach (var storageItem in storageItems)
    {
        Console.WriteLine($"Storage Item ID: {storageItem.StorageItemId}, Name: {storageItem.Name}, Type: {storageItem.Type}");

        foreach (var item in storageItem.Items)
        {
            Console.WriteLine($"  Item Name: {item.Name}, Category: {item.Category}, Quantity: {item.Quantity}, Unit: {item.Unit}");
        }
        foreach (var shelf in storageItem.Shelves)
        {
            Console.WriteLine($"  Shelf ID: {shelf.ShelfId}, Label: {shelf.Label}");
            foreach (var shelfItem in shelf.Items)
            {
                Console.WriteLine($"    Shelf Item Name: {shelfItem.Name}, Category: {shelfItem.Category}, Quantity: {shelfItem.Quantity}, Unit: {shelfItem.Unit}");
            }
        }
    }
}
void GetShelvesWithItems()
{
    using var context = new OptimizerContext();
    var shelves = context.Shelves.Include(a => a.Items).ToList();

    foreach (var shelf in shelves)
    {
        Console.WriteLine($"Shelf ID: {shelf.ShelfId}, Label: {shelf.Label}");
        foreach (var item in shelf.Items)
        {
            Console.WriteLine($"  Item Name: {item.Name}, Category: {item.Category}, Quantity: {item.Quantity}, Unit: {item.Unit}");
        }
    }
}
void AddDrawerWithItem()
{
    var drawer = new Drawer
    {
        DrawerNumber = 8,
        Label = "DrawerWithItem",
        IsLocked = true
    };
    drawer.Items.Add(new Item
    {
        Name = ".NET Programming",
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
void GetDrawersWithItems()
{
    using var context = new OptimizerContext();
    var drawers = context.Drawers.Include(a => a.Items).ToList();

    foreach (var drawer in drawers)
    {
        Console.WriteLine($"Drawer ID: {drawer.DrawerId}, Label: {drawer.Label}, Is Locked: {drawer.IsLocked}");
        foreach (var item in drawer.Items)
        {
            Console.WriteLine($"  Item Name: {item.Name}, Category: {item.Category}, Quantity: {item.Quantity}, Unit: {item.Unit}");
        }
    }
}
void GetDrawers()
{
    using var context = new OptimizerContext();
    var drawers = context.Drawers.ToList();
    foreach (var drawer in drawers)
    {
        Console.WriteLine($"Drawer ID: {drawer.DrawerId}, Label: {drawer.Label}, Is Locked: {drawer.IsLocked}");
    }

}

void AddDrawer()
{
    var drawer = new Drawer
    {
        DrawerNumber = 7,
        Label = "Documents",
        IsLocked = false
    };
    using var context = new OptimizerContext();
    context.Drawers.Add(drawer);
    context.SaveChanges();
}

