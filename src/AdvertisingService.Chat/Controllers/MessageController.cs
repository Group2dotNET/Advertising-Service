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
        public MessageController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("sendmsg")]
        public async Task<ActionResult<Message>> Send([FromBody] CreateMsgDto message)
        {
            try
            {
                await _unitOfWork.MessageRepository.Send(message);
                await _unitOfWork.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deletemsg")]
        public async Task<ActionResult> Delete([FromBody] DeleteMsgDto message)
        {
            try
            {
                await _unitOfWork.MessageRepository.Delete(message);
                await _unitOfWork.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
