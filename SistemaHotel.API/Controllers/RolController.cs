using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaHotel.Entidades.DTOs;
using SistemaHotel.Entidades.Models;
using SistemaHotel.Negocios.UoW;

namespace SistemaHotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RolController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var rol = _unitOfWork.Roles.GetByCondition(r => r.IdRolUsuario == id);
                return (rol != null)
                    ? StatusCode(StatusCodes.Status200OK, _mapper.Map<RolWriteDto>(rol))
                    : StatusCode(StatusCodes.Status204NoContent); 
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listaRoles = _unitOfWork.Roles.GetAll();
                return (listaRoles != null)
                    ? StatusCode(StatusCodes.Status200OK, _mapper.Map<List<RolReadDto>>(listaRoles))
                    : StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public IActionResult Insert(RolWriteDto dto)
        {
            try
            {
                var rol = _unitOfWork.Roles.GetByCondition(r => r.Descripcion.Trim().ToLower().Equals(dto.Descripcion.Trim().ToLower()));
                if (rol == null)
                {
                    var rolInsert = _mapper.Map<RolUsuario>(dto);
                    rolInsert.FechaCreacion = DateTime.UtcNow;
                    rolInsert.Estado = true;

                    return (_unitOfWork.Roles.Insert(rolInsert))
                        ? StatusCode(StatusCodes.Status201Created, _mapper.Map<RolReadDto>(rolInsert))
                        : StatusCode(StatusCodes.Status400BadRequest);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        [HttpPut]
        public IActionResult Update(RolWriteDto dto, int id)
        {
            try
            {

                if(dto.IdRolUsuario == id)
                {
                    var rol = _mapper.Map<RolUsuario>(dto);
                    rol.FechaCreacion = DateTime.UtcNow;
                    rol.Estado = true;

                    return (_unitOfWork.Roles.Update(rol))
                        ? StatusCode(StatusCodes.Status200OK, _mapper.Map<RolReadDto>(rol)) 
                        : StatusCode(StatusCodes.Status400BadRequest);
                }
                else 
                    return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        [HttpDelete("desactivar/{id}")]
        public IActionResult Desactivar(int id) 
        {
            try
            {
                var rol = _unitOfWork.Roles.GetByCondition(r => r.IdRolUsuario == id);
                if(rol != null)
                {
                    return (_unitOfWork.Roles.Desactivar(rol.IdRolUsuario))
                        ? StatusCode(StatusCodes.Status200OK, "Borrado con éxito.")
                        : StatusCode(StatusCodes.Status400BadRequest); 
                }
                else
                    return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


    }
}
