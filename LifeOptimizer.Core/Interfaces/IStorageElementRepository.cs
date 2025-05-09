using LifeOptimizer.Core.Entities;


namespace LifeOptimizer.Core.Interfaces
{
    public interface IStorageElementRepository
    {
        Task<StorageElement> CreateStorageElementAsync(StorageElement storageElement);
        Task<List<StorageElement>> GetStorageElementsByUserIdAsync(string userId);

    }
}
