using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaHotel.Entidades.DTOs;
using SistemaHotel.Entidades.Models;
using SistemaHotel.Negocios.Services.Interfaces;
using SistemaHotel.Negocios.UoW;

namespace SistemaHotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioServices _usuarioServices;
        private readonly IMapper _mapper;

        public AuthController(IUnitOfWork unitOfWork, IMapper mapper, IUsuarioServices usuarioServices)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _usuarioServices = usuarioServices;
        }


        [HttpPost]
        public IActionResult Login(UserLoginDto login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = _usuarioServices.Login(login);
                    if (user != null)
                    {
                        return StatusCode(StatusCodes.Status202Accepted, _usuarioServices.GetToken(_mapper.Map<UserDto>(user)));
                    }
                    return StatusCode(StatusCodes.Status400BadRequest, "Usuario y/o contraseña incorrecto.");
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            else
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }

    }
}
