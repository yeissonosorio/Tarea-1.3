using SQLite;

namespace Tarea_1._3.Models
{
    [Table("Autores")]
    public class DateBase
    {

        [PrimaryKey, AutoIncrement]
        public int Id_autor { get; set; }

        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(100)]
        public string Pais { get; set; }
    }
}
