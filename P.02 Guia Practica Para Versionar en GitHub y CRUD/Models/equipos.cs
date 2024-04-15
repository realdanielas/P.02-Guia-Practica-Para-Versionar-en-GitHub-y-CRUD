using System.ComponentModel.DataAnnotations;

namespace P._02_Guia_Practica_Para_Versionar_en_GitHub_y_CRUD.Models
{
    public class Equipos
    {
        [Key]

        public int id_equipos { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
        public int tipo_equipo_id { get; set; }
        public int marca_id { get; set; }
        public string? modelo { get; set; }
        public int anio_compra { get; set; }
        public decimal costo { get; set; }
        public int vida_util { get; set; }
        public int estado_equipo_id { get; set; }
        public char estado { get; set; }
    }
}
