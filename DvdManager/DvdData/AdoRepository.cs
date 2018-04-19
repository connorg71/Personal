using DvdModels;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DvdData
{
	public class AdoRepository : IDvdRepository
	{
		public Dvd CreateDvd(Dvd dvd)
		{
			var commandText = "sp_insertDvd";
			using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
			{
				using (var command = new SqlCommand(commandText, connection))
				{
					connection.Open();
					command.Parameters.Add(new SqlParameter("title", dvd.Title));
					command.Parameters.Add(new SqlParameter("releasedate", dvd.ReleaseYear));
					command.Parameters.Add(new SqlParameter("director", dvd.Director));
					command.Parameters.Add(new SqlParameter("rating", dvd.Rating));
					command.Parameters.Add(new SqlParameter("notes", dvd.Notes));
					command.CommandType = CommandType.StoredProcedure;
					var result = command.ExecuteScalar();
					dvd.Id = (int)result;
					return dvd;
				}
			}
		}

		public void DeleteDvd(int id)
		{
			var commandText = "sp_deleteDvd";
			using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
			{
				using (var command = new SqlCommand(commandText, connection))
				{
					connection.Open();
					command.Parameters.Add(new SqlParameter("id", id));
					command.CommandType = CommandType.StoredProcedure;
					command.ExecuteNonQuery();
				}
			}
		}

		public List<Dvd> GetAllDvds()
		{
			var output = new List<Dvd>();
			var query = "SELECT * FROM DVDS";
			using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
			{
				using (var command = new SqlCommand(query, connection))
				{
					connection.Open();
					var sqlResult = command.ExecuteReader();
					if (sqlResult.HasRows)
					{
						while (sqlResult.Read())
						{
							output.Add(MapDvd(sqlResult));
						}
					}
				}
			}
			return output;
		}

		private Dvd MapDvd(SqlDataReader sqlResult)
		{
			var dvd = new Dvd();
			dvd.Id = sqlResult.GetInt32(0);
			dvd.Director = sqlResult.GetString(3);
			dvd.Notes = sqlResult.GetString(5);
			dvd.Rating = sqlResult.GetString(4);
			dvd.ReleaseYear = sqlResult.GetInt32(2);
			dvd.Title = sqlResult.GetString(1);
			return dvd;
		}

		public List<Dvd> GetByDirector(string directorName)
		{
			var output = new List<Dvd>();
			var commandText = "sp_getDvdByDirector";
			using (var connection = new SqlConnection())
			{
				using (var command = new SqlCommand(commandText, connection))
				{
					connection.Open();
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(new SqlParameter("director", directorName));
					var sqlResult = command.ExecuteReader();
					if (sqlResult.HasRows)
					{
						while (sqlResult.Read())
						{
							output.Add(MapDvd(sqlResult));
						}
					}
				}
			}
			return output;
		}

		public List<Dvd> GetByRating(string rating)
		{
			var output = new List<Dvd>();
			var commandText = "sp_getDvdByRating";
			using (var connection = new SqlConnection())
			{
				using (var command = new SqlCommand(commandText, connection))
				{
					connection.Open();
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(new SqlParameter("rating", rating));
					var sqlResult = command.ExecuteReader();
					if (sqlResult.HasRows)
					{
						while (sqlResult.Read())
						{
							output.Add(MapDvd(sqlResult));
						}
					}
				}
			}
			return output;
		}

		public List<Dvd> GetByTitle(string title)
		{
			var output = new List<Dvd>();
			var commandText = "sp_getDvdByTitle";
			using (var connection = new SqlConnection())
			{
				using (var command = new SqlCommand(commandText, connection))
				{
					connection.Open();
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(new SqlParameter("title", title));
					var sqlResult = command.ExecuteReader();
					if (sqlResult.HasRows)
					{
						while (sqlResult.Read())
						{
							output.Add(MapDvd(sqlResult));
						}
					}
				}
			}
			return output;
		}

		public List<Dvd> GetByYear(int year)
		{
			var output = new List<Dvd>();
			var commandText = "sp_getDvdByYear";
			using (var connection = new SqlConnection())
			{
				using (var command = new SqlCommand(commandText, connection))
				{
					connection.Open();
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(new SqlParameter("year", year));
					var sqlResult = command.ExecuteReader();
					if (sqlResult.HasRows)
					{
						while (sqlResult.Read())
						{
							output.Add(MapDvd(sqlResult));
						}
					}
				}
			}
			return output;
		}

		public Dvd GetDvd(int id)
		{
			var commandText = "sp_getDvd";
			using (var connection = new SqlConnection())
			{
				using (var command = new SqlCommand(commandText, connection))
				{
					connection.Open();
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(new SqlParameter("id", id));
					var sqlResult = command.ExecuteReader();
					if (sqlResult.HasRows)
					{
						sqlResult.Read();
						return MapDvd(sqlResult);
					}
					return null;
				}
			}
		}

		public void UpdateDvd(int id, Dvd dvd)
		{
			var commandText = "sp_updateDvd";
			using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
			{
				using (var command = new SqlCommand(commandText, connection))
				{
					connection.Open();
					command.Parameters.Add(new SqlParameter("title", dvd.Title));
					command.Parameters.Add(new SqlParameter("releasedate", dvd.ReleaseYear));
					command.Parameters.Add(new SqlParameter("director", dvd.Director));
					command.Parameters.Add(new SqlParameter("rating", dvd.Rating));
					command.Parameters.Add(new SqlParameter("notes", dvd.Notes));
					command.CommandType = CommandType.StoredProcedure;
					command.ExecuteNonQuery();
				}
			}
		}
	}
}