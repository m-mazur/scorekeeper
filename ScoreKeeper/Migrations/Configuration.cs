namespace ScoreKeeper.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ScoreKeeper.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ScoreKeeper.Models.ScoreKeeperContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ScoreKeeper.Models.ScoreKeeperContext context)
        {
            context.Users.AddOrUpdate(x => x.UserId,
                new User() { UserId = 1, UserName = "MM"},
                new User() { UserId = 2, UserName = "PJ"},
                new User() { UserId = 3, UserName = "BJ"},
                new User() { UserId = 4, UserName = "TP"}
                );

            context.Scores.AddOrUpdate(x => x.ScoreId,
                new Score() { ScoreId = 1, ScorePoints = 10, ScoreDate = DateTime.Today, UserId = 1},
                new Score() { ScoreId = 2, ScorePoints = 8, ScoreDate = DateTime.Today, UserId = 2}
                );
        }
    }
}
