﻿using Microsoft.AspNetCore.Mvc;
using centralProjectApi.Application.DTOs;
using centralProjectApi.Application.Interfaces;
using centralProjectApi.Application.Exceptions;

namespace centralProjectApi.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: /auth/login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto model)
        {
            try
            {
                await _userService.ValidateCredentialsAsync(model.Email, model.Password);
                var token = _userService.GenerateJwtToken(model.Email);

                return Ok(new { Token = token });
            }
            catch (InvalidOperationException ex) { return Unauthorized(ex.Message); }
            catch (UserAlreadyExistsException ex) { return Conflict(ex.Message); }
            catch (Exception ex) { return StatusCode(500, $"Internal server error: {ex.Message}"); }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto model)
        {
            try
            {
                await _userService.Register(model);

                return Ok(new { message = "User registered successfully" });
            }
            catch (UserAlreadyExistsException ex) { return Conflict(ex.Message); }
            catch (Exception ex) { return StatusCode(500, $"Internal server error: {ex.Message}"); }
        }
    }
}
