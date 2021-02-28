﻿using AndroidKotlinNetCore.Auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace AndroidKotlinNetCore.Auth.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        public IActionResult Test()
        {
            return Ok("test ok kerim.");
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel)
        {
            var user = new ApplicationUser();
            user.UserName = signUpViewModel.Username;
            user.Email = signUpViewModel.Email;
            user.City = signUpViewModel.City;

            var result = await _userManager.CreateAsync(user, signUpViewModel.Password);

            if (!result.Succeeded)
            {
                //Hata mesajı gönderilecek
                return BadRequest();
            }

            return NoContent();
        }
    }
}
