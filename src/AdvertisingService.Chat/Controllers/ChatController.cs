using AdvertisingService.Chat.Contracts;
using AdvertisingService.Chat.Entities;
using AdvertisingService.Chat.Interfaces;
using AdvertisingService.Chat.Repository;
using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingService.Chat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ChatController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("startchat")]
        public async Task<ActionResult> StartChat([FromBody] ChatDto chat)
        {
            try
            {
                await _unitOfWork.ChatRepository.Create(chat);
                await _unitOfWork.Commit();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getmsgsthread")]
        public async Task<IEnumerable<MessageDto>> GetMessageThread([FromBody] ChatDto chatDto)
        {
            return await _unitOfWork.ChatRepository.GetMessageThread(chatDto);
        }

        [HttpGet("getmsgsforuser/{username}")]
        public async Task<IEnumerable<MessageDto>> GetMessagesForUser(string username)
        {
            return await _unitOfWork.ChatRepository.GetMessagesForUser(username);
        }
    }
}
