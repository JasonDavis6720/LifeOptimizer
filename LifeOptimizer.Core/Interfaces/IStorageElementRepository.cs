using LifeOptimizer.Core.Entities;


namespace LifeOptimizer.Core.Interfaces
{
    public interface IStorageElementRepository
    {
        Task<StorageElement> AddStorageElementAsync(StorageElement storageElement);
        Task<List<StorageElement>> GetStorageElementsByUserIdAsync(string userId);

    }
}
