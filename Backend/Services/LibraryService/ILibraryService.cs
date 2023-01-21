using Backend.Models;

namespace Backend.Services.LibraryService
{
    public interface ILibraryService
    {
        Task<Library?> GetByOwnerAsync(Guid userId);
        Task<Library?> CreateAsync(Guid userId);
        Task<Library?> TransferOwenership(Guid senderId, Guid recipientId);

    }
}
