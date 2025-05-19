using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using ZHEKApp.Models;

namespace ZHEKApp.Services
{
    public static class DatabaseService
    {
        private static readonly string connectionString = "Data Source=zhek.db";

        public static void Initialize()
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Residents (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT,
                    Phone TEXT,
                    Email TEXT
                );
                CREATE TABLE IF NOT EXISTS Requests (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ResidentId INTEGER,
                    Description TEXT,
                    Status TEXT
                );";
            command.ExecuteNonQuery();
        }

        public static void AddResident(Resident r)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Residents (Name, Phone, Email) VALUES ($name, $phone, $email)";
            command.Parameters.AddWithValue("$name", r.Name);
            command.Parameters.AddWithValue("$phone", r.Phone);
            command.Parameters.AddWithValue("$email", r.Email);
            command.ExecuteNonQuery();
        }

        public static List<Resident> GetResidents()
        {
            var list = new List<Resident>();
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Residents";
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Resident
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Phone = reader.GetString(2),
                    Email = reader.GetString(3)
                });
            }
            return list;
        }
    }
}
