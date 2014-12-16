using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScoreKeeper.Models;

namespace ScoreKeeper.Repositories
{
    public interface IScoreRepository
    {
        IEnumerable<Score> GetAllScores();
    }
}
