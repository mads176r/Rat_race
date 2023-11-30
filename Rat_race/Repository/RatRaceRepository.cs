using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace Rat_race.Repository
{
    public class RatRaceRepository
    {
        private readonly string connectionString;

        public RatRaceRepository()
        {
            connectionString = "Data Source=DESKTOP-R65I9QQ\\RATRACESERVER;Initial Catalog=Rat;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        }

        public void Save<T>(List<T> save)
        {
            string type = typeof(T).Name;
            string json = JsonConvert.SerializeObject(save, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            File.WriteAllText(String.Format(@"C:\Users\HFGF\source\repos\Rat_race\Repository\Data\{0}.json", type), json);

            foreach (var item in save)
            {
                switch (item)
                {
                    case Player player:
                        SavePlayerToDb(player);
                        break;
                    case Rat rat:
                        SaveRatToDb(rat);
                        break;
                    case Race race:
                        SaveRaceToDb(race);
                        break;
                    case Track track:
                        SaveTrackToDb(track);
                        break;
                    case Bet bet:
                        SaveBetToDb(bet);
                        break;
                }
            }
        }



        private void SavePlayerToDb(Player player)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Player (userName, password, money) VALUES (@userName, @password, @money)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@userName", player.UserName);
                    command.Parameters.AddWithValue("@password", player.Password);
                    command.Parameters.AddWithValue("@money", player.Money);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        private void SaveRatToDb(Rat rat)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Rat (name, position) VALUES (@name, @position)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", rat.Name);
                    command.Parameters.AddWithValue("@position", rat.Position);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        private void SaveRaceToDb(Race race)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO Race (raceTrack, log, winnerID) VALUES (@raceTrack, @log, @winnerID)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@raceTrack", race.RaceTrack.Name);
                    command.Parameters.AddWithValue("@log", "Race log will be updated after the race."); // Placeholder log

                    // Check if there is a winner
                    if (race.Winner != null)
                    {
                        command.Parameters.AddWithValue("@winnerID", race.Winner.Name); 
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@winnerID", DBNull.Value);
                    }

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        private void UpdateRaceLogInDb(int raceID, string actualLog)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "UPDATE Race SET log = @log WHERE raceID = @raceID";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@log", actualLog);
                    command.Parameters.AddWithValue("@raceID", raceID);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }


        private void SaveTrackToDb(Track track)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Track (name, trackLength) VALUES (@name, @trackLength)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", track.Name);
                    command.Parameters.AddWithValue("@trackLength", track.TrackLength);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        private void SaveBetToDb(Bet bet)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Bet (money, userName, raceID,ratName) VALUES (@money, @userName, @raceID, @ratName)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@money", bet.Money);
                    command.Parameters.AddWithValue("@userName", bet.Player.UserName);
                    command.Parameters.AddWithValue("@raceID", bet.Race.RaceID);
                    command.Parameters.AddWithValue("@ratName", bet.Rat.Name);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }


        public RaceManager Load()
        {
            RaceManager raceManager = new RaceManager();

            string trackFile = (@"C:\Users\HFGF\source\repos\Rat_race\Repository\Data\Track.json");
            string jsonStringTrack = File.ReadAllText(trackFile);
            raceManager.Tracks = JsonConvert.DeserializeObject<List<Track>>(jsonStringTrack);

            string playerListFile = (@"C:\Users\HFGF\source\repos\Rat_race\Repository\Data\Player.json");
            string jsonStringPlayerList = File.ReadAllText(playerListFile);
            raceManager.PlayerList = JsonConvert.DeserializeObject<List<Player>>(jsonStringPlayerList);

            string raceFile = (@"C:\Users\HFGF\source\repos\Rat_race\Repository\Data\Race.json");
            string jsonStringRace = File.ReadAllText(raceFile);
            raceManager.Races = JsonConvert.DeserializeObject<List<Race>>(jsonStringRace);

            string ratFile = (@"C:\Users\HFGF\source\repos\Rat_race\Repository\Data\Rat.json");
            string jsonStringrat = File.ReadAllText(ratFile);
            raceManager.Rats = JsonConvert.DeserializeObject<List<Rat>>(jsonStringrat);

            return raceManager;
        }
    }
}