using AdvertisingService.Chat.Contracts;
using AdvertisingService.Chat.Entities;
using AdvertisingService.Chat.Interfaces;
using AdvertisingService.Chat.Repository;
using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AdvertisingService.Chat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MessageController(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("sendmsg")]
        public async Task<ActionResult<Message>> Send([FromBody] CreateMsgDto message)
        {
            var msg = await _unitOfWork.MessageRepository.Send(message);
            return CreatedAtAction(nameof(Send), new { id = msg.Id }, msg);
        }

        [HttpDelete("deletemsg/{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var username = User.FindFirst("User")?.Value;
            Task delTask = _unitOfWork.MessageRepository.Delete(id, username);
            await delTask.ConfigureAwait(false);
            return delTask.IsCompletedSuccessfully ? Ok() : BadRequest("Ошибка при удалении сообщения");
        }
    }
}
