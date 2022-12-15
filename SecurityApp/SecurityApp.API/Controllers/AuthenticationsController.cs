﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecurityApp.API.Models;
using SecurityApp.API.ViewModels;

public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountController(
        UserManager<User> userManager,
        SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginViewModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            return BadRequest("Invalid email or password.");
        }

        // Check if the user provided the correct password
        var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
        if (!result.Succeeded)
        {
            // Increment the failed access attempt count for the user and lock them out if necessary
            return BadRequest("Invalid email or password.");
        }

        // Sign the user in and return the access token
        var token = await GenerateJwtToken(user);
        return Ok(new { token });
    }

    private Task<string> GenerateJwtToken(User user)
    {
        throw new NotImplementedException();
    }
}
