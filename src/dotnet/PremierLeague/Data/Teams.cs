
namespace PremierLeague.Data
{
    using System.Collections.Generic;
    using PremierLeague.Models;

    public static class Teams
    {
        public static List<Team> GetTeams()
        {
            return new List<Team>
            {
                new Team{TeamId = "1",TeamName = "Arsenal", Stadium="Emirates"},
                new Team{TeamId = "2",TeamName = "Aston Villa", Stadium="Villa Park"},
                new Team{TeamId = "3",TeamName = "AFC Bournemouth", Stadium="Dean Court"},
                new Team{TeamId = "4",TeamName= "Brighton & Hove Albion", Stadium="American Express Community Stadium"},
                new Team{TeamId = "5",TeamName = "Burnley", Stadium="Turf Moor"},
                new Team{TeamId = "6",TeamName = "Chelsea", Stadium="Stamform Bridge"},
                new Team{TeamId = "7",TeamName = "Crystal Palace", Stadium="Selhurst Stadium"},
                new Team{TeamId = "8",TeamName = "Everton", Stadium="Goodison Park"},
                new Team{TeamId = "9",TeamName = "Leicester City", Stadium="King Power Stadium"},
                new Team{TeamId = "10",TeamName = "Liverpool", Stadium="Anfield"},
                new Team{TeamId = "11",TeamName = "Manchester City", Stadium="Emirates"},
                new Team{TeamId = "12",TeamName = "Manchester United", Stadium="Old Trafford"},
                new Team{TeamId = "13", TeamName = "Newcastle United", Stadium= "St James' Park"},
                new Team{TeamId = "14",TeamName = "Norwich City", Stadium="Carrow Road"},
                new Team{TeamId = "15",TeamName = "Sheffield United", Stadium="Bramall Lane"},
                new Team{TeamId = "16",TeamName = "Southampton", Stadium="St Mary's Stadium"},
                new Team{TeamId = "17",TeamName = "Tottenham Hotspur", Stadium="Tottenham Hotspur Stadium"},
                new Team{TeamId = "18",TeamName = "Watford", Stadium="Vicarage Road"},
                new Team{TeamId = "19",TeamName = "West Ham United", Stadium="London Stadium"},
                new Team{TeamId = "20",TeamName = "Wolverhampton Wanderers", Stadium="Molineux Stadium"}
            };
        }
    }
}