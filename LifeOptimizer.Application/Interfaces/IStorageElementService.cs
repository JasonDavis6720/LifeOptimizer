using LifeOptimizer.Application.DTOs;
using LifeOptimizer.Core.Entities;

namespace LifeOptimizer.Application.Interfaces
{
    public interface IStorageElementService
    {
        Task<StorageElement> CreateStorageElementAsync(CreateStorageElementDto storageElementDto);
    }
}
