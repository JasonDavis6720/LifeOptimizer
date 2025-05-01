using LifeOptimizer.Server.Data;
using LifeOptimizer.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class InventoryItemService : IInventoryItemService
{
    private readonly ApplicationDbContext _context;

    public InventoryItemService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<InventoryItem>> GetAllInventoryItemsAsync()
    {
        return await _context.InventoryItems.ToListAsync();
    }

    public async Task<InventoryItem> GetInventoryItemByIdAsync(int id)
    {
        return await _context.InventoryItems.FirstOrDefaultAsync(ii => ii.Id == id);
    }

    public async Task<InventoryItem> CreateInventoryItemAsync(InventoryItem inventoryItem)
    {
        _context.InventoryItems.Add(inventoryItem);
        await _context.SaveChangesAsync();
        return inventoryItem;
    }

    public async Task<InventoryItem> UpdateInventoryItemAsync(int id, InventoryItem updatedItem)
    {
        var existingItem = await _context.InventoryItems.FirstOrDefaultAsync(ii => ii.Id == id);
        if (existingItem == null)
        {
            return null;
        }

        // Update the entity in the database
        _context.Entry(existingItem).CurrentValues.SetValues(updatedItem);

        await _context.SaveChangesAsync();
        return existingItem;
    }

    public async Task<bool> DeleteInventoryItemAsync(int id)
    {
        var inventoryItem = await _context.InventoryItems.FirstOrDefaultAsync(ii => ii.Id == id);
        if (inventoryItem == null)
        {
            return false;
        }

        _context.InventoryItems.Remove(inventoryItem);
        await _context.SaveChangesAsync();
        return true;
    }
}
