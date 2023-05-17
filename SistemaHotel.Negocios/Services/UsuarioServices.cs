using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SistemaHotel.Entidades.DTOs;
using SistemaHotel.Entidades.Models;
using SistemaHotel.Negocios.Services.Interfaces;
using SistemaHotel.Negocios.UoW;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SistemaHotel.Negocios.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;


        public UsuarioServices(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
        }

        public string GetToken(UserDto user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Actor, user.IdUsuario.ToString()),
                new Claim(ClaimTypes.Name, $"{user.Nombre}"),
                new Claim(ClaimTypes.Name, $"{user.Apellido}"),
                new Claim(ClaimTypes.Email, $"{user.Correo}")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiracion = DateTime.UtcNow.AddHours(24);

            JwtSecurityToken token = new JwtSecurityToken(
                claims: claims,
                expires: expiracion,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public UserDto Login(UserLoginDto userLogin)
        {
            try
            {
                if (_unitOfWork.Usuarios.ExisteUsuario(userLogin.Correo))
                {
                    var user = _unitOfWork.Usuarios.GetByCondition(a => a.Correo.Trim().ToLower().Equals(userLogin.Correo.Trim().ToLower()));

                    if(!VerifyPassword(userLogin.Clave, user.PasswordHash, user.PasswordSalt))
                    {
                        return null;
                    }
                    return _mapper.Map<UserDto>(user);
                }
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public UserRegisterDto Register(UserRegisterDto userregister, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;

            CrearPassHash(password, out passwordHash, out passwordSalt);
            Usuario user = _mapper.Map<Usuario>(userregister);
            user.FechaCreacion = DateTime.Now;
            user.Estado = true;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _unitOfWork.Usuarios.Insert(user);
            _unitOfWork.Usuarios.Save();

            return _mapper.Map<UserRegisterDto>(user); ;
        }


        #region Métodos Privados

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var hMac = new HMACSHA512(passwordSalt);
            var hash = hMac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (var i = 0; i < hash.Length; i++)
            {
                if (hash[i] != passwordHash[i])
                {
                    return false;
                }
            }
            return true;
        }


        private void CrearPassHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            var hMac = new HMACSHA512();
            passwordSalt = hMac.Key;
            passwordHash = hMac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        #endregion
    }
}
