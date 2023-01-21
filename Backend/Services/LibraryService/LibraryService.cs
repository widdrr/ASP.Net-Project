using Backend.Data;
using Backend.Models;
using Backend.Repositories.LibraryRepository;
using Backend.Services.UserService;
using Microsoft.OpenApi.Models;

namespace Backend.Services.LibraryService
{
    public class LibraryService : ILibraryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILibraryRepository _libraryRepository;
        private readonly IUserService _userService;
        
        public LibraryService(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _libraryRepository = _unitOfWork.LibraryRepository;
            _userService = userService;
        }
        public async Task<Library?> CreateAsync(Guid userId)
        {
            var library = await _libraryRepository.GetLibraryByOwnerAsync(userId);
            if(library != null)
            {
                return library;
            }
           
            library = new Library{ UserId = userId };

            await _libraryRepository.CreateAsync(library);
            
            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                 return null;
            }

            return library;
        }

        public async Task<Library?> GetByOwnerAsync(Guid userId)
        {
            return await _libraryRepository.GetLibraryByOwnerAsync(userId);
        }

        public async Task<Library?> TransferOwenership(Guid senderId, Guid recipientId)
        {
            var library = await _libraryRepository.GetLibraryByOwnerAsync(senderId);
            if (library == null)
            {
                return null;
            }

            var existingLibrary = await _libraryRepository.GetLibraryByOwnerAsync(recipientId);
            if(existingLibrary != null)
            {
                return existingLibrary;
            }

            library.UserId = recipientId;

            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                return null;
            }
            return library;
        }
    }
}
