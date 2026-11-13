using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Лаб_2;

namespace Лаб_2
{
    public class RaceRepository
    {
        private readonly string _connectionString;

        public RaceRepository(string path)
        {
            _connectionString = new SqliteConnectionStringBuilder { DataSource = path }.ToString();
        }

        public void Initialize()
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS RaceResults (
                    Id INTEGER PRIMARY KEY,
                    Driver TEXT NOT NULL,
                    Car TEXT NOT NULL,
                    Track TEXT NOT NULL,
                    LapSeconds INTEGER NOT NULL CHECK (LapSeconds BETWEEN 30 AND 600)
                );";
            cmd.ExecuteNonQuery();
        }

        public List<RaceResult> GetAll()
        {
            var list = new List<RaceResult>();
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, Driver, Car, Track, LapSeconds FROM RaceResults ORDER BY Id";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new RaceResult
                {
                    Id = reader.GetInt64(0),
                    Driver = reader.GetString(1),
                    Car = reader.GetString(2),
                    Track = reader.GetString(3),
                    LapSeconds = reader.GetInt32(4)
                });
            }
            return list;
        }

        public long Add(RaceResult row)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO RaceResults (Driver, Car, Track, LapSeconds)
                VALUES ($d, $c, $t, $s);
                SELECT last_insert_rowid();";
            cmd.Parameters.AddWithValue("$d", row.Driver);
            cmd.Parameters.AddWithValue("$c", row.Car);
            cmd.Parameters.AddWithValue("$t", row.Track);
            cmd.Parameters.AddWithValue("$s", row.LapSeconds);
            return (long)cmd.ExecuteScalar();
        }

        public void Update(RaceResult row)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                UPDATE RaceResults 
                SET Driver = $d, Car = $c, Track = $t, LapSeconds = $s 
                WHERE Id = $id";
            cmd.Parameters.AddWithValue("$d", row.Driver);
            cmd.Parameters.AddWithValue("$c", row.Car);
            cmd.Parameters.AddWithValue("$t", row.Track);
            cmd.Parameters.AddWithValue("$s", row.LapSeconds);
            cmd.Parameters.AddWithValue("$id", row.Id);
            cmd.ExecuteNonQuery();
        }

        public void Delete(long id)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM RaceResults WHERE Id = $id";
            cmd.Parameters.AddWithValue("$id", id);
            cmd.ExecuteNonQuery();
        }

        // ===== ЭТАП 8.3: ТРАНЗАКЦИОННАЯ ЗАМЕНА =====
        public void ReplaceAll(List<RaceResult> newData)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            using var transaction = conn.BeginTransaction();

            var deleteCmd = conn.CreateCommand();
            deleteCmd.Transaction = transaction;
            deleteCmd.CommandText = "DELETE FROM RaceResults";
            deleteCmd.ExecuteNonQuery();

            foreach (var item in newData)
            {
                var insertCmd = conn.CreateCommand();
                insertCmd.Transaction = transaction;
                insertCmd.CommandText = @"
                    INSERT INTO RaceResults (Id, Driver, Car, Track, LapSeconds)
                    VALUES ($id, $d, $c, $t, $s)";
                insertCmd.Parameters.AddWithValue("$id", item.Id);
                insertCmd.Parameters.AddWithValue("$d", item.Driver);
                insertCmd.Parameters.AddWithValue("$c", item.Car);
                insertCmd.Parameters.AddWithValue("$t", item.Track);
                insertCmd.Parameters.AddWithValue("$s", item.LapSeconds);
                insertCmd.ExecuteNonQuery();
            }

            transaction.Commit();
        }
    }
}