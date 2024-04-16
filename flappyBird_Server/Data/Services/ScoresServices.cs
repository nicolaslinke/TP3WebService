using flappyBird_Server.Migrations;
using flappyBird_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace flappyBird_Server.Data.Services
{
    public class ScoresServices
    {
        private readonly flappyBird_ServerContext _context;

        public ScoresServices(flappyBird_ServerContext context)
        {
            _context = context;
        }

        private bool IsContextNull()
        {
            return _context == null;
        }

        public async Task<IEnumerable<Score>?> GetAllPublic()
        {
            if (IsContextNull()) return null;

            return await _context.Score.Where(x => x.isPublic == true).ToListAsync();
        }

        public async Task<IEnumerable<Score>?> GetMyAll(string username)
        {
            if (IsContextNull()) return null;

            return await _context.Score.Where(x => x.Pseudo == username).ToListAsync();
        }

        public async Task<Score?> ChangeScore(int id, Score score)
        {
            if (IsContextNull()) return null;

            _context.Entry(score).State = EntityState.Modified;

            var newScore = _context.Score.Where(x => x.Id == id).FirstOrDefault();
            if (newScore != null) newScore.isPublic = !newScore.isPublic;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }

            return newScore;
        }

        public async Task<Score?> Add(Score score)
        {
            if (IsContextNull()) return null;

            _context.Score.Add(score);
            await _context.SaveChangesAsync();
            return score;
        }
    }
}
