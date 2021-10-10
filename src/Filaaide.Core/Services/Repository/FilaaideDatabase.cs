using System;
using System.IO;
using Filaaide.Core.Model;
using SQLite;

namespace Filaaide.Core.Services.Repository
{
	public partial class FilaaideDatabase
	{
		readonly SQLiteAsyncConnection _connection;

		public FilaaideDatabase(string path)
		{
			this._connection = new SQLiteAsyncConnection(path);

			this._connection.CreateTableAsync<Filament>().Wait();
			this._connection.CreateTableAsync<Thing>().Wait();
		}

		private static FilaaideDatabase _database; 

		public static FilaaideDatabase Database
		{
			get {
				if (_database == null) {
					_database = new FilaaideDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Filaaide.db3"));
				}
				return _database;
			}
		}
	}
}