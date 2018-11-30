﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Friendship.Data;
using Friendship.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

//testing

namespace Friendship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(UserManager<User> userMananger, SignInManager<User> signinManager)
        {
            _userManager = userMananger;
            _signInManager = signinManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginVM user)
        {
            if (ModelState.IsValid)
            {
                var userInfo = await _userManager.FindByNameAsync(user.UserName);
                var result = await _signInManager.CheckPasswordSignInAsync(userInfo, user.Password, false);
                //var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, false);
                if (result.Succeeded)
                {
                    LoginDTO validUser = new LoginDTO();
                    validUser.UserName = user.UserName;
                    validUser.Password = user.Password;
                    string tok = BuildToken(validUser);
                    var user2 = await _signInManager.UserManager.FindByNameAsync(validUser.UserName);
                    return Ok(new { Msg = "Login succeeded", User = user.UserName, ID = user2.Id, tokenString = tok });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterVM user)
        {
            return await SeedDb();
            if (!string.IsNullOrEmpty(user.UserName))
            {
                // Make user name lower case
                user.UserName = user.UserName.ToLower();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User newUser = new User { UserName = user.UserName };
            var result = await _userManager.CreateAsync(newUser, user.Password);

            if (result.Succeeded)
            {
                return Ok(new { Msg = "Registration succeeded", User = newUser.UserName, ID = newUser.Id });
            }
            return BadRequest(result);

        }

        private string BuildToken(LoginDTO user)
        {
            var subject = new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserName),
                        new Claim(ClaimTypes.Name, user.UserName)
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Secret Testing Key"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(null, null, subject,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<IActionResult> SeedDb()
        {
            var userData = System.IO.File.ReadAllText("Data/UserData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);

            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();
                string pw = user.PasswordHash;
                user.PasswordHash = null;
                var result = await _userManager.CreateAsync(user, pw);
                if (!result.Succeeded)
                {
                    return Ok(result);
                }
            }
            return Ok("DB seeded");
        }
    }
}