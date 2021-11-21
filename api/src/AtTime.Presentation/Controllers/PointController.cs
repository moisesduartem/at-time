using AtTime.Core.Models;
using AtTime.Infra.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtTime.Presentation.Controllers
{
    [ApiController]
    [Route("points")]
    public class PointController : ControllerBase
    {
        private readonly IPointRepository _pointRepository;
        private readonly IUserRepository _userRepository;

        public PointController(IPointRepository pointRepository, IUserRepository userRepository)
        {
            _pointRepository = pointRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("author/{authorId:int}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Point>>> GetByAuthorId(int authorId)
        {
            return Ok(
                await _pointRepository.GetByAuthorId(authorId)
            );
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Point>> Register()
        {
            var author = await _userRepository.GetByName(User.Identity.Name);
            var point = new Point(DateTime.Now, author.Id);
            await _pointRepository.Add(point);
            
            return Ok(point);
        }
    }
}
