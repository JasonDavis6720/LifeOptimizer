using LifeOptimizer.Application.DTOs;
using LifeOptimizer.Core.Entities;

namespace LifeOptimizer.Application.Interfaces
{
    public interface IStorageElementService
    {
        Task<StorageElementReturnDto> CreateStorageElementByIdAsync(CreateStorageElementDto storageElementDto);
    }
}
