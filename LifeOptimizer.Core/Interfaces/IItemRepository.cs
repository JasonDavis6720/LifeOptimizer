﻿using LifeOptimizer.Core.Entities;


namespace LifeOptimizer.Core.Interfaces
{
    public interface IItemRepository
    {
        Task<Item> AddItemAsync(Item item);
        Task<List<Item>> GetAllItemsAsync(string userId);
        Task<Item> GetItemByIdAsync(int id);
    }
}
