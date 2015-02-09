using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScoreKeeper.ViewModels;

namespace ScoreKeeper.Console2
{
    class Program
    {
        static void Main(string[] args)
        {
            GetScoresViewModel test = new GetScoresViewModel();

            Console.WriteLine(test);
        }
    }
}
