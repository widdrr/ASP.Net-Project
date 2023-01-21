using AutoMapper;
using Backend.Enums;
using Backend.Helpers.Attributes;
using Backend.Services.LibraryService;
using Backend.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/library")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;
        private readonly IMapper _mapper;

        public LibraryController(ILibraryService libraryService, IMapper mapper)
        {
            _libraryService = libraryService;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetLibrary(Guid userId)
        {
            var lib = await _libraryService.GetByOwnerAsync(userId);

            if(lib == null)
            {
                return NotFound();
            }

            return Ok(lib);
        }
        [HttpPut("{userId}")]
        [OwnerAuthorization]
        public async Task<IActionResult> CreateLibrary(Guid userId)
        {
            var lib = await _libraryService.CreateAsync(userId);

            if (lib == null)
            {
                return BadRequest("Something went very very wrong...");
            }

            return Ok(lib);
        }
        [HttpPut("{userId}/transfer")]
        [RoleAuthorization(Role.Admin)]
        public async Task<IActionResult> CreateLibrary(Guid userId, Guid recipientId)
        {
            var lib = await _libraryService.TransferOwenership(userId,recipientId);

            if (lib == null)
            {
                return BadRequest("Something went very very wrong...");
            }

            return Ok(lib);
        }
    }
}
