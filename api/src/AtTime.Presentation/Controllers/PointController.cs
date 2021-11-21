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
        
        [HttpGet]
        [Route("today")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Point>>> GetFromToday()
        {
            var user = await GetAuthenticatedUser();
            var points = await _pointRepository.GetFromToday(user.Id);

            return Ok(points);
        }
        
        [HttpGet]
        [Route("last")]
        [Authorize]
        public async Task<ActionResult<Point>> GetLastPoint()
        {
            var user = await GetAuthenticatedUser();
            var point = await _pointRepository.GetUserLastPoint(user.Id);

            if (point == null)
                return NotFound(new { Message = "There are no point history for this user" });

            return Ok(point);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Point>> Register()
        {
            var author = await GetAuthenticatedUser();
            var point = new Point(DateTime.Now, author.Id);
            await _pointRepository.Add(point);

            return Ok(point);
        }

        private Task<User> GetAuthenticatedUser()
        {
            return _userRepository.GetByName(User.Identity.Name);
        }
    }
}
