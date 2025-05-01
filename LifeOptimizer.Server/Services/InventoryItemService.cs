using LifeOptimizer.Server.Data;
using LifeOptimizer.Server.Dtos;
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

    public async Task<InventoryItem> UpdateInventoryItemAsync(int id, UpdateInventoryItemDto updatedItemDto)
    {
        var existingItem = await _context.InventoryItems.FirstOrDefaultAsync(ii => ii.Id == id);
        if (existingItem == null)
        {
            return null;
        }

        // Update only the fields that are provided
        if (!string.IsNullOrEmpty(updatedItemDto.Name))
        {
            existingItem.Name = updatedItemDto.Name;
        }

        if (!string.IsNullOrEmpty(updatedItemDto.Category))
        {
            existingItem.Category = updatedItemDto.Category;
        }

        if (updatedItemDto.Quantity.HasValue)
        {
            existingItem.Quantity = updatedItemDto.Quantity.Value;
        }

        if (!string.IsNullOrEmpty(updatedItemDto.Unit))
        {
            existingItem.Unit = updatedItemDto.Unit;
        }

        if (updatedItemDto.ExpirationDate.HasValue)
        {
            existingItem.ExpirationDate = updatedItemDto.ExpirationDate.Value;
        }

        if (updatedItemDto.IsExpired.HasValue)
        {
            existingItem.IsExpired = updatedItemDto.IsExpired.Value;
        }

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
