using AutoMapper;
using Backend.Helpers.Attributes;
using Backend.Models.DTOs;
using Backend.Models.DTOs.Transactions;
using Backend.Services.TransactionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private ITransactionService _transactionService;
        private IMapper _mapper;
        public TransactionController(ITransactionService transactionService, IMapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper;

        }

        [HttpGet("{userId}")]
        [OwnerAuthorization]
        public async Task<IActionResult> GetTransactionHistoryAsync(Guid userId)
        {
            var res = await _transactionService.GetTransactionsForUser(userId);
            return Ok(res);
        }
        [HttpPost("{userId}/deposit")]
        [OwnerAuthorization]
        public async Task<IActionResult> MakeDepositAsync(Guid userId,double depositSum)
        {
            var res = await _transactionService.MakeDepositAsync(userId,depositSum);
            
            if (res == null)
                //too lazy to return internal server error
                return BadRequest();

            return Ok(res);
        }
        [HttpPost("{userId}/purchase")]
        [OwnerAuthorization]
        public async Task<IActionResult> MakePurchaseAsync(Guid userId, PurchaseRequestDto purchase)
        {
            var res = await _transactionService.MakePurchaseAsync(userId, purchase);
            
            if (res == null)
                return BadRequest("Insufficient funds");
            
            return Ok(res);
        }

    }
}
