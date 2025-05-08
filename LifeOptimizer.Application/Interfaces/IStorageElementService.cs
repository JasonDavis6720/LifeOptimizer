using LifeOptimizer.Application.Dtos;


namespace LifeOptimizer.Application.Interfaces
{
    public interface IStorageElementService
    {
        Task<StorageElementReturnDto> CreateStorageElementByIdAsync(CreateStorageElementDto storageElementDto);
    }
}
