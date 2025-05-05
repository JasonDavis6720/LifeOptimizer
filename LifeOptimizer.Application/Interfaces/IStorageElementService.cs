using LifeOptimizer.Core.Entities;

namespace LifeOptimizer.Application.Interfaces
{
    public interface IStorageElementService
    {
        Task<StorageElement> CreateStorageElementAsync(StorageElementDto storageElementDto);
    }
}
