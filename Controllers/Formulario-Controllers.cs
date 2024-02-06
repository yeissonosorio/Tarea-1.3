using System;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using Tarea_1._3.Models;

namespace Tarea_1._3.Controllers
{
    public class FormularioController
    {
        SQLiteAsyncConnection _connection;

        // Constructor Vacío
        public FormularioController(){}
        public async Task Init()
        {
            if (_connection is not null)
            {
                return;
            }

            SQLiteOpenFlags extensiones = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "DBFormulario.db3"), extensiones);
            await _connection.CreateTableAsync<DateBase>();
        }

        // Método para guardar un nuevo autor
        public async Task<int> StoreAutor(DateBase author)
        {
            await Init();

            if (author.Id_autor == 0)
            {
                return await _connection.InsertAsync(author);
            }
            else
            {
                return await _connection.UpdateAsync(author);
            }
        }

        public async Task<List<DateBase>> ObtenerTodasLasPersonas()
        {
            await Init();
            return await _connection.Table<DateBase>().ToListAsync();
        }
    }
}
