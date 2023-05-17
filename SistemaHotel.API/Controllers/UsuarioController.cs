using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaHotel.Entidades.DTOs;
using SistemaHotel.Entidades.Models;
using SistemaHotel.Negocios.Services.Interfaces;
using SistemaHotel.Negocios.UoW;

namespace SistemaHotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioServices _service;
        private readonly IMapper _mapper;


        public UsuarioController(IUnitOfWork unitOfWork, IMapper mapper, IUsuarioServices service)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _service = service;
        }


        [HttpPost]
        public IActionResult Insert(UserRegisterDto userRegisterDto)
        {
            try
            {
                if (_unitOfWork.Usuarios.ExisteUsuario(userRegisterDto.Correo.Trim().ToLower()))
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                var response = _service.Register(userRegisterDto, userRegisterDto.Clave);
                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = _unitOfWork.Usuarios.GetByCondition(a => a.IdUsuario == id);
                return (user != null)
                    ? StatusCode(StatusCodes.Status200OK, _mapper.Map<UserDto>(user))
                    : StatusCode(StatusCodes.Status400BadRequest);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listaUsuarios = _unitOfWork.Usuarios.GetAll();
                return (listaUsuarios.Count > 0)
                    ? StatusCode(StatusCodes.Status200OK, _mapper.Map<List<UserDto>>(listaUsuarios))
                    : StatusCode(StatusCodes.Status204NoContent);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Update(UserRegisterDto userRegister, int id)
        {
            try
            {
                if(id == userRegister.Id)
                {
                    var user = _mapper.Map<Usuario>(userRegister);
                    return (_unitOfWork.Usuarios.Update(user))
                        ? StatusCode(StatusCodes.Status200OK, _mapper.Map<UserDto>(user))
                        : StatusCode(StatusCodes.Status400BadRequest);
                }
                else
                    return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var user = _unitOfWork.Usuarios.GetByCondition(a => a.IdUsuario == id);
                if(user != null)
                {
                    return (_unitOfWork.Usuarios.Delete(user))
                        ? StatusCode(StatusCodes.Status200OK)
                        : StatusCode(StatusCodes.Status400BadRequest);
                }
                else
                    return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
