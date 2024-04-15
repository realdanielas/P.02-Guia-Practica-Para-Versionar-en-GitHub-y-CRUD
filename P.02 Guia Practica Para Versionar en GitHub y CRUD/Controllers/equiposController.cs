using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P._02_Guia_Practica_Para_Versionar_en_GitHub_y_CRUD.Models;

namespace P._02_Guia_Practica_Para_Versionar_en_GitHub_y_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class equiposController : ControllerBase
    {
        private readonly equiposContext _equiposContexto;

        public equiposController(equiposContext equiposContexto)
        {
            _equiposContexto = equiposContexto;
        }

        [HttpGet]
        [Route("GetAll")]

        //LEER TODOS LOS REGISTROS 
        public IActionResult Get()
        {
            List<Equipos> ListadoEquipo = (from e in _equiposContexto.equipos
                                           select e).ToList();
            if (ListadoEquipo.Count() == 0)
            {
                return NotFound();
            }
            return Ok(ListadoEquipo);
        }

        //BUSCAR POR ID
        [HttpGet]
        [Route("GetById/{id}")]

        public IActionResult Get(int id)
        {
            Equipos? equipo = (from e in _equiposContexto.equipos
                               where e.id_equipos == id
                               select e).FirstOrDefault();
            if (equipo == null)
            {
                return NotFound();
            }
            return Ok(equipo);
        }

        //BUSCAR POR DESCRIPCIÓN

        [HttpGet]
        [Route("Find/{filtro}")]

        public IActionResult FindByDescription(string filtro)
        {
            Equipos? equipo = (from e in _equiposContexto.equipos
                               where e.descripcion.Contains(filtro)
                               select e).FirstOrDefault();
            if (equipo == null)
            {
                return NotFound();
            }
            return Ok(equipo);
        }

        //CREAR
        [HttpPost]
        [Route("Add")]

        public IActionResult SaveEquipo([FromBody] Equipos equipo)
        { 
            try
            {
                _equiposContexto.equipos.Add(equipo);
                _equiposContexto.SaveChanges();
                return Ok(equipo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //MODIFICAR
        [HttpPut]
        [Route("actualizar/{id}")]

        public IActionResult UpdateEquipo(int id, [FromBody] Equipos equipoModify)
        {
            Equipos? currentEquipo = (from e in _equiposContexto.equipos
                                      where e.id_equipos == id
                                      select e).FirstOrDefault();
            if (currentEquipo == null)
            {
                return NotFound();
            }
            currentEquipo.nombre = equipoModify.nombre;
            currentEquipo.descripcion = equipoModify.descripcion;
            currentEquipo.marca_id = equipoModify.marca_id;
            currentEquipo.tipo_equipo_id = equipoModify.tipo_equipo_id;
            currentEquipo.anio_compra = equipoModify.anio_compra;
            currentEquipo.costo = equipoModify.costo;

            _equiposContexto.Entry(currentEquipo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _equiposContexto.SaveChanges();

            return Ok(equipoModify);
        }

        //ELIMINAR
        [HttpDelete]
        [Route("eliminar/{id}")]

        public IActionResult deleteEquipo(int id)
        {
            Equipos? equipo = (from e in _equiposContexto.equipos
                               where e.id_equipos == id
                               select e ).FirstOrDefault();
            if (equipo == null)
            {
                return NotFound();
            }

            _equiposContexto.equipos.Attach(equipo);
            _equiposContexto.equipos.Remove(equipo);
            _equiposContexto.SaveChanges();

            return Ok(equipo);
        }

    }
}
