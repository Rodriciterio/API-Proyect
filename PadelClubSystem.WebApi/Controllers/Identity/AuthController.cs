using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PadelClubSystem.Application.Dtos.Identity.User;
using PadelClubSystem.Application.Dtos.Login;
using PadelClubSystem.Entities.MicrosoftIdentity;
using PadelClubSystem.Services.AuthServices;
using PadelClubSystem.WebApi.Configurations;

namespace PadelClubSystem.WebApi.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ILogger<SociosController> _logger;
        private readonly ITokenHandlerService _servicioToken;
        public AuthController(
            UserManager<User> userManager
            , RoleManager<Role> roleManager
            , ILogger<SociosController> logger
            , ITokenHandlerService servicioToken)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _servicioToken = servicioToken;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegistrarUsuario([FromBody] UserRegistroRequestDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest("Los datos enviados no son válidos.");

            // ------------------------------
            // 1) Validar si el mail ya existe
            // ------------------------------
            var existeUsuario = await _userManager.FindByEmailAsync(user.Email);
            if (existeUsuario != null)
                return BadRequest("Existe un usuario registrado con el mail " + user.Email + ".");

            // ------------------------------
            // 2) VALIDAR ROL ELEGIDO (NUEVO)
            // ------------------------------
            var allowedRoles = new[] { "Socio", "Cliente", "Jugador" };

            if (string.IsNullOrWhiteSpace(user.Rol))
                return BadRequest("Debe seleccionar un rol.");

            if (!allowedRoles.Contains(user.Rol))
                return BadRequest("El rol seleccionado no está permitido para auto-registro.");

            // ------------------------------
            // 3) Crear usuario
            // ------------------------------
            var nuevoUsuario = new User()
            {
                Email = user.Email,
                UserName = user.Email.Substring(0, user.Email.IndexOf('@')),
                Nombres = user.Nombres,
                Apellidos = user.Apellidos,
                FechaNacimiento = user.FechaNacimiento
            };

            var Creado = await _userManager.CreateAsync(nuevoUsuario, user.Password);

            // ------------------------------
            // 4) Asignar rol (NUEVO)
            // ------------------------------
            if (Creado.Succeeded)
            {
                await _userManager.AddToRoleAsync(nuevoUsuario, user.Rol);

                return Ok(new UserRegistroResponseDto
                {
                    NombreCompleto = string.Join(" ", user.Nombres, user.Apellidos),
                    Email = user.Email,
                    UserName = user.Email.Substring(0, user.Email.IndexOf('@')),
                    RolAsignado = user.Rol
                });
            }
            else
            {
                return BadRequest(Creado.Errors.Select(e => e.Description).ToList());
            }
        }


        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserRequestDto userlogin)
        {
            if (ModelState.IsValid)
            {
                var existeUsuario = await _userManager.FindByEmailAsync(userlogin.Email);
                if (existeUsuario != null)
                {
                    var isCorrect = await _userManager.CheckPasswordAsync(existeUsuario, userlogin.Password);
                    if (isCorrect)
                    {
                        try
                        {
                            var roles = await _userManager.GetRolesAsync(existeUsuario);
                            var parametros = new TokenParameters()
                            {
                                Id = existeUsuario.Id.ToString(),
                                PaswordHash = existeUsuario.PasswordHash,
                                UserName = existeUsuario.UserName,
                                Email = existeUsuario.Email,
                                Roles = roles
                            };
                            var jwt = _servicioToken.GenerateJwtTokens(parametros);
                            return Ok(new LoginUserResponseDto()
                            {
                                Login = true,
                                Token = jwt,
                                UserName = existeUsuario.UserName,
                                Mail = existeUsuario.Email
                            });
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }
            }
            return BadRequest(new LoginUserResponseDto()
            {
                Login = false,
                Errores = new List<string>()
                    {
                       "Usuario o contraseña incorrecto!"
                    }
            });
        }
    }
}
