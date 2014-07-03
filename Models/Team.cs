using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_TestBed.Models
{

    public class GoalContext
    {
        public IList<Game> AllGames;
        public IList<Team> AllTeams;
        public IList<Team> CurrentTeams;

        public string addedTeam;
        public string removedTeam;

        public GoalContext()
        {
            CurrentTeams = new List<Team>();

            AllTeams = new List<Team>();
            AllTeams.Add(new Team() { Name = "Brazil" });
            AllTeams.Add(new Team() { Name = "Greece" });
            AllTeams.Add(new Team() { Name = "Argentina" });
            AllTeams.Add(new Team() { Name = "Uruguay" });
            AllTeams.Add(new Team() { Name = "Ireland" });

            AllGames = new List<Game>();
            List<Goal> goals = new List<Goal>();
            Team homeTeam,awayTeam;

            goals.Clear();
            homeTeam = AllTeams.FirstOrDefault(t=>t.Name=="Brazil");
            awayTeam = AllTeams.FirstOrDefault(t=>t.Name=="Greece");
            goals.Add(AddGoal(homeTeam, awayTeam, 15));
            goals.Add(AddGoal(homeTeam, awayTeam, 35));
            goals.Add(AddGoal(awayTeam, homeTeam, 53));
            goals.Add(AddGoal(homeTeam, awayTeam, 93));
            AddGame(homeTeam, awayTeam, goals);

            goals.Clear();
            homeTeam = AllTeams.FirstOrDefault(t => t.Name == "Brazil");
            awayTeam = AllTeams.FirstOrDefault(t => t.Name == "Argentina");
            goals.Add(AddGoal(homeTeam, awayTeam, 25));
            goals.Add(AddGoal(homeTeam, awayTeam, 56));
            goals.Add(AddGoal(awayTeam, homeTeam, 63));
            AddGame(homeTeam, awayTeam, goals);

            goals.Clear();
            homeTeam = AllTeams.FirstOrDefault(t => t.Name == "Brazil");
            awayTeam = AllTeams.FirstOrDefault(t => t.Name == "Uruguay");
            goals.Add(AddGoal(awayTeam, homeTeam, 13));
            AddGame(homeTeam, awayTeam, goals);

            goals.Clear();
            homeTeam = AllTeams.FirstOrDefault(t => t.Name == "Brazil");
            awayTeam = AllTeams.FirstOrDefault(t => t.Name == "Uruguay");
            goals.Add(AddGoal(awayTeam, homeTeam, 13));
            AddGame(homeTeam, awayTeam, goals);



        }

        public void AddGame(Team homeTeam, Team awayTeam, IList<Goal> goals)
        {
            AllGames.Add(new Game()
            {
                HomeTeam = homeTeam,
                AwayTeam = awayTeam,
                HomeTeamGoals = goals.Where(t => t.ScoringTeam == homeTeam).ToList(),
                AwayTeamGoals = goals.Where(t => t.ScoringTeam == awayTeam).ToList()
            });

        }

        public Goal AddGoal(Team scoringTeam, Team concedingTeam, int minute)
        {
            return new Goal()
            {
                ScoringTeam = scoringTeam,
                ConcedingTeam=concedingTeam,
                Minute= minute
            };
        }

    }



    public class Team
    {
        public string Name { get; set; }
        
    }

    public class Game
    {
        public DateTime When { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public IList<Goal> HomeTeamGoals { get; set; }
        public IList<Goal> AwayTeamGoals { get; set; }

    }

    public class Goal
    {
        public Game Game { get; set; }
        public int Minute { get; set; }
        public Team ScoringTeam { get; set; }
        public Team ConcedingTeam { get; set; }

    }
}