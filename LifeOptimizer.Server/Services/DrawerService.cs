using LifeOptimizer.Server.Data;
using LifeOptimizer.Server.Dtos;
using LifeOptimizer.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DrawerService : IDrawerService
{
    private readonly ApplicationDbContext _context;

    public DrawerService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Drawer>> GetAllDrawersAsync()
    {
        return await _context.Drawers.ToListAsync();
    }

    public async Task<Drawer> GetDrawerByIdAsync(int id)
    {
        return await _context.Drawers.FirstOrDefaultAsync(ii => ii.Id == id);
    }

    public async Task<Drawer> CreateDrawerAsync(Drawer inventoryItem)
    {
        _context.Drawers.Add(inventoryItem);
        await _context.SaveChangesAsync();
        return inventoryItem;
    }
    public async Task<ServiceResponse<InventoryItem>> AddItemToDrawerAsync(int drawerId, int itemId)
    {
        var response = new ServiceResponse<InventoryItem>();

        // Validate the Drawer exists
        var drawer = await _context.Drawers.FirstOrDefaultAsync(d => d.Id == drawerId);
        if (drawer == null)
        {
            response.Success = false;
            response.Message = $"Drawer with ID {drawerId} not found.";
            return response;
        }

        // Validate the InventoryItem exists
        var inventoryItem = await _context.InventoryItems.FirstOrDefaultAsync(ii => ii.Id == itemId);
        if (inventoryItem == null)
        {
            response.Success = false;
            response.Message = $"InventoryItem with ID {itemId} not found.";
            return response;
        }

        // Update the DrawerId of the InventoryItem
        inventoryItem.DrawerId = drawerId;
        await _context.SaveChangesAsync();

        response.Data = inventoryItem;
        response.Success = true;
        response.Message = "Item successfully added to the drawer.";
        return response;
    }
    //public async Task<Drawer> UpdateDrawerAsync(int id, UpdateDrawerDto updatedItemDto)
    //{
    //    var existingItem = await _context.Drawers.FirstOrDefaultAsync(ii => ii.Id == id);
    //    if (existingItem == null)
    //    {
    //        return null;
    //    }

    //    // Update only the fields that are provided
    //    if (!string.IsNullOrEmpty(updatedItemDto.Name))
    //    {
    //        existingItem.Name = updatedItemDto.Name;
    //    }

    //    if (!string.IsNullOrEmpty(updatedItemDto.Category))
    //    {
    //        existingItem.Category = updatedItemDto.Category;
    //    }

    //    if (updatedItemDto.Quantity.HasValue)
    //    {
    //        existingItem.Quantity = updatedItemDto.Quantity.Value;
    //    }

    //    if (!string.IsNullOrEmpty(updatedItemDto.Unit))
    //    {
    //        existingItem.Unit = updatedItemDto.Unit;
    //    }

    //    if (updatedItemDto.ExpirationDate.HasValue)
    //    {
    //        existingItem.ExpirationDate = updatedItemDto.ExpirationDate.Value;
    //    }

    //    if (updatedItemDto.IsExpired.HasValue)
    //    {
    //        existingItem.IsExpired = updatedItemDto.IsExpired.Value;
    //    }

    //    await _context.SaveChangesAsync();
    //    return existingItem;
    //}



    public async Task<bool> DeleteDrawerAsync(int id)
    {
        var inventoryItem = await _context.Drawers.FirstOrDefaultAsync(ii => ii.Id == id);
        if (inventoryItem == null)
        {
            return false;
        }

        _context.Drawers.Remove(inventoryItem);
        await _context.SaveChangesAsync();
        return true;
    }
}
