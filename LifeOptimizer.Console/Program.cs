//using LifeOptimizer.Infrastructure.Data;
//using Microsoft.EntityFrameworkCore;

//using (AppDbContext context = new AppDbContext())
//{
//    context.Database.EnsureDeleted();
//    context.Database.EnsureCreated();
//}

//Console.WriteLine("Hello, Life Optimizer!");


////Populate Database for Use after a EnsureDeleted Call (Line 8)
//AddDrawer();
//AddShelf();
//AddStorageElement();
//AddDwelling();



////Calling Item Methods for Testing Purposes
////------------------------------------------
////AddItem();
////GetAllItems();
////AddDrawer();
////ChangeItemById(1);
////GetAllItems();
////DeleteItemById(2);
////GetAllItems();


////AddDrawer();
////AddDrawerWithItem();
////GetDrawersWithItems();
////AddShelf();
////AddShelfWithItem();
////AddstorageElementWithShelf();
////AddstorageElement();
////GetShelvesWithItems();

////AddItemToShelf(1, 1);
////GetstorageElementsWithItems();

////DWELLING METHODS
//AddDwelling();


////TEST METHODS
////Items
//void AddItem()
//{
//    var item = new Item
//    {
//        Name = "Evening Item 3",
//        Category = "Test Item 3",
//        Quantity = 2,
//        Unit = "pcs",
//        ExpirationDate = null,
//        IsExpired = false
//    };
//    using var context = new AppDbContext();
//    context.Items.Add(item);
//    context.SaveChanges();
//    Console.WriteLine($"Item '{item.Name}' added with ID: {item.ItemId}");
//}

//void GetAllItems()
//{
//    using var context = new AppDbContext();
//    var items = context.Items.ToList();
//    foreach (var item in items)
//    {
//        Console.WriteLine($"Item ID: {item.ItemId}, Name: {item.Name}, Category: {item.Category}, Quantity: {item.Quantity}, Unit: {item.Unit}");
//    }
//}
//void ChangeItemById(int itemId)
//{
//    using var context = new AppDbContext();
//    var item = context.Items.Find(itemId);
//    if (item != null)
//    {
//        item.DrawerId = 1;
//        context.SaveChanges();
//        Console.WriteLine($"Item with ID: {itemId} updated successfully.");
//    }
//    else
//    {
//        Console.WriteLine($"Item with ID: {itemId} not found.");
//    }
//}
//void DeleteItemById(int itemId)
//{
//    using var context = new AppDbContext();
//    var item = context.Items.Find(itemId);
//    if (item != null)
//    {
//        context.Items.Remove(item);
//        context.SaveChanges();
//        Console.WriteLine($"Item with ID: {itemId} deleted successfully.");
//    }
//    else
//    {
//        Console.WriteLine($"Item with ID: {itemId} not found.");
//    }
//}





//void AddItemToShelf(int shelfId, int itemId)
//{
//    using var context = new AppDbContext();
//    var shelf = context.Shelves.Include(s => s.Items).FirstOrDefault(s => s.ShelfId == shelfId);

//    if (shelf != null)
//    {
//        var item = context.Items.Find(itemId);
//        shelf.Items.Add(item);
//        context.SaveChanges();
//        Console.WriteLine($"Item '{item.Name}' added to Shelf ID: {shelfId}, Shelf Name: {shelf.Label}");
//    }
//    else
//    {
//        Console.WriteLine($"Shelf with ID: {shelfId} not found.");
//    }

//}

//void AddStorageElementContainerWithShelf()
//{
//    var storageElement = new StorageElement
//    {
//        Name = "Living Room Bookshelf",
//        Type = "Bookshelf"
//    };

//    storageElement.Shelves.Add(new Shelf
//    {
//        Label = "Bottom Shelf",
//    });

//    using var context = new AppDbContext();
//    context.StorageElements.Add(storageElement);
//    context.SaveChanges();
//}

//void AddStorageElement()
//{
//    var storageElement = new StorageElement
//    {
//        Name = "Kitchen Cabinet",
//        Type = "Cabinet",
//    };
//    using var context = new AppDbContext();
//    context.StorageElements.Add(storageElement);
//    context.SaveChanges();
//}
//void AddShelf()
//{
//    var shelf = new Shelf
//    {
//        Label = "Top Shelf",
//    };
//    using var context = new AppDbContext();
//    context.Shelves.Add(shelf);
//    context.SaveChanges();
//}

//void AddShelfWithItem()
//{
//    var shelf = new Shelf
//    {
//        Label = "Item Shelf"
//    };

//    shelf.Items.Add(new Item
//    {
//        Name = "Shelf Book Test",
//        Category = "Test",
//        Quantity = 5,
//        Unit = "copy",
//    });

//    using var context = new AppDbContext();
//    context.Shelves.Add(shelf);
//    context.SaveChanges();
//}

//void GetStorageElementsWithItems()
//{
//    using var context = new AppDbContext();
//    var storageElements = context.StorageElements
//        .Include(si => si.Items)
//        .Include(si => si.Shelves)
//        .ThenInclude(s => s.Items)
//        .ToList();
//    foreach (var storageElement in storageElements)
//    {
//        Console.WriteLine($"Storage Item ID: {storageElement.StorageElementId}, Name: {storageElement.Name}, Type: {storageElement.Type}");

//        foreach (var item in storageElement.Items)
//        {
//            Console.WriteLine($"  Item Name: {item.Name}, Category: {item.Category}, Quantity: {item.Quantity}, Unit: {item.Unit}");
//        }
//        foreach (var shelf in storageElement.Shelves)
//        {
//            Console.WriteLine($"  Shelf ID: {shelf.ShelfId}, Label: {shelf.Label}");
//            foreach (var shelfItem in shelf.Items)
//            {
//                Console.WriteLine($"    Shelf Item Name: {shelfItem.Name}, Category: {shelfItem.Category}, Quantity: {shelfItem.Quantity}, Unit: {shelfItem.Unit}");
//            }
//        }
//    }
//}
//void GetShelvesWithItems()
//{
//    using var context = new AppDbContext();
//    var shelves = context.Shelves.Include(a => a.Items).ToList();

//    foreach (var shelf in shelves)
//    {
//        Console.WriteLine($"Shelf ID: {shelf.ShelfId}, Label: {shelf.Label}");
//        foreach (var item in shelf.Items)
//        {
//            Console.WriteLine($"  Item Name: {item.Name}, Category: {item.Category}, Quantity: {item.Quantity}, Unit: {item.Unit}");
//        }
//    }
//}
//void AddDrawerWithItem()
//{
//    var drawer = new Drawer
//    {
//        DrawerNumber = 8,
//        Label = "DrawerWithItem",
//        IsLocked = true
//    };
//    drawer.Items.Add(new Item
//    {
//        Name = ".NET Programming",
//        Category = "Books",
//        Quantity = 1,
//        Unit = "copy",
//        ExpirationDate = null,
//        IsExpired = false,
//    });

//    using var context = new AppDbContext();
//    context.Drawers.Add(drawer);
//    context.SaveChanges();
//}
//void GetDrawersWithItems()
//{
//    using var context = new AppDbContext();
//    var drawers = context.Drawers.Include(a => a.Items).ToList();

//    foreach (var drawer in drawers)
//    {
//        Console.WriteLine($"Drawer ID: {drawer.DrawerId}, Label: {drawer.Label}, Is Locked: {drawer.IsLocked}");
//        foreach (var item in drawer.Items)
//        {
//            Console.WriteLine($"  Item Name: {item.Name}, Category: {item.Category}, Quantity: {item.Quantity}, Unit: {item.Unit}");
//        }
//    }
//}
//void GetDrawers()
//{
//    using var context = new AppDbContext();
//    var drawers = context.Drawers.ToList();
//    foreach (var drawer in drawers)
//    {
//        Console.WriteLine($"Drawer ID: {drawer.DrawerId}, Label: {drawer.Label}, Is Locked: {drawer.IsLocked}");
//    }

//}

//void AddDrawer()
//{
//    var drawer = new Drawer
//    {
//        DrawerNumber = 7,
//        Label = "Documents",
//        IsLocked = false
//    };
//    using var context = new AppDbContext();
//    context.Drawers.Add(drawer);
//    context.SaveChanges();
//}

////DWELLING METHODS
//void AddDwelling()
//{
//    var dwelling = new Dwelling
//    {
//        Name = "My House",
//        StreetAddress = "123 Main St",
//        ApartmentNumber = "Apt 4B",
//        City = "Springfield",
//        State = "IL",
//        ZipCode = "62704",
//        Country = "USA",
//        UserId = "user123" // Replace with the actual UserId
//    };

//    using var context = new AppDbContext();
//    context.Dwellings.Add(dwelling);
//    context.SaveChanges();

//    Console.WriteLine($"Dwelling '{dwelling.Name}' added with ID: {dwelling.DwellingId}");
//}
