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

namespace flappyBird_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        readonly UserManager<User> userManager;

        private readonly flappyBird_ServerContext _context;

        public ScoresController(flappyBird_ServerContext context, UserManager<User> userManager)
        {
            _context = context;

            this.userManager = userManager;
        }

        // GET: api/Scores
        [HttpGet("GetPublicScores")]
        public async Task<ActionResult<IEnumerable<Score>>> GetScore()
        {
          if (_context.Score == null)
          {
              return NotFound();
          }
          return await _context.Score.Where(x => x.isPublic == true).ToListAsync();
        }

        // GET: api/Scores
        [HttpGet("GetMyScores")]
        public async Task<ActionResult<IEnumerable<Score>>> GetMyScore()
        {
            if (_context.Score == null)
            {
                return NotFound();
            }
            User? user = await userManager.FindByNameAsync("allo");
            if (user != null)
            {
                return user.Scores;
            }
            return StatusCode(StatusCodes.Status400BadRequest,
                new { Message = "Utilisateur non trouvé" });
        }

        // GET: api/Scores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Score>> GetScore(int id)
        {
          if (_context.Score == null)
          {
              return NotFound();
          }
            var score = await _context.Score.FindAsync(id);

            if (score == null)
            {
                return NotFound();
            }

            return score;
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

            _context.Entry(score).State = EntityState.Modified;

            var newScore = _context.Score.Where(x => x.Id == id).FirstOrDefault();
            newScore.isPublic = !newScore.isPublic;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScoreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Scores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Score>> PostScore(Score score)
        {
          if (_context.Score == null)
          {
              return Problem("Entity set 'flappyBird_ServerContext.Score'  is null.");
          }
            _context.Score.Add(score);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScore", new { id = score.Id }, score);
        }

        // DELETE: api/Scores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScore(int id)
        {
            if (_context.Score == null)
            {
                return NotFound();
            }
            var score = await _context.Score.FindAsync(id);
            if (score == null)
            {
                return NotFound();
            }

            _context.Score.Remove(score);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScoreExists(int id)
        {
            return (_context.Score?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
