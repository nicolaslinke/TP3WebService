using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using flappyBird_Server.Data;
using flappyBird_Server.Models;
using System.Security.Claims;
using flappyBird_Server.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using flappyBird_Server.Data.Services;

namespace flappyBird_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        readonly UserManager<User> userManager;

        private readonly ScoresServices _scoreService;

        public ScoresController(ScoresServices scoreServices, UserManager<User> userManager)
        {
            _scoreService = scoreServices;

            this.userManager = userManager;
        }

        // GET: api/Scores
        [HttpGet("GetPublicScores")]
        public async Task<ActionResult<IEnumerable<Score>>> GetScore()
        {
            IEnumerable<Score>? scores = await _scoreService.GetAllPublic();

            if (scores == null)
            {
                return NotFound();
            }
            return Ok(await _scoreService.GetAllPublic());
        }

        // GET: api/Scores
        [HttpGet("GetMyScores")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Score>>> GetMyScore()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await userManager.FindByIdAsync(userId);
            if (user != null)
            {
                return Ok(await _scoreService.GetMyAll(user.UserName));
            }
            return StatusCode(StatusCodes.Status400BadRequest,
                new { Message = "Utilisateur non trouvé" });
        }

        // PUT: api/Scores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("ChangeScoreVisibility/{id}")]
        public async Task<IActionResult> PutScore(int id, Score score)
        {
            if (id != score.Id)
            {
                return BadRequest();
            }

            Score? updatedScore = await _scoreService.ChangeScore(id, score);

            if (updatedScore != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "Le score a été supprimé ou modifié. Veuillez réessayer" });
            }

            return Ok(updatedScore);
        }

        // POST: api/Scores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Score>> PostScore(Score score)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await userManager.FindByIdAsync(userId);
            if (user != null)
            {
                score.Pseudo = user.UserName;
                Score? newScore = await _scoreService.Add(score);
                if (newScore == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                return CreatedAtAction("GetScore", new { id = score.Id }, score);
            }
            return StatusCode(StatusCodes.Status400BadRequest,
                new { Message = "Utilisateur non trouvé" });
        }
    }
}
