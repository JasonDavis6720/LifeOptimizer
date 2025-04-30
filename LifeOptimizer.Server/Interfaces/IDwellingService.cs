public interface IDwellingService
{
    Task<DwellingResponseDto> GetDwellingResponseByIdAsync(int id);
    Task<DwellingResponseDto> CreateDwellingForUserAsync(string userId, DwellingRequestDto dwellingDto);
    Task<bool> DeleteDwellingByIdAsync(int id);
}
    //TODO: Methods To Add
    //UpdateDwellingAsync()

