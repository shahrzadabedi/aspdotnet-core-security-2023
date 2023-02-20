using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecurityApp.Core.Dtos;
using SecurityApp.API;
using SecurityApp.API.ViewModels;
using SecurityApp.Service.Interfaces;
using AutoMapper;
using SecurityApp.Core.Models;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    protected readonly IRepositoryManager _repository;
    //protected readonly ILoggerManager _logger;
    protected readonly IMapper _mapper;
    public AccountController(
        IRepositoryManager repository, IMapper mapper
        //, ILoggerManager logger
        )
    {
        _repository = repository;
        _mapper = mapper;
        //_logger = logger;
    }

    [HttpPost]
  //  [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userRegistration)
    {

        var userResult = await _repository.UserAuthentication.RegisterUserAsync(userRegistration);
        return !userResult.Succeeded ? new BadRequestObjectResult(userResult) : StatusCode(201);
    }

    [HttpPost("login")]
    //[ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Authenticate([FromBody] UserLoginDto user)
    {
        return !await _repository.UserAuthentication.ValidateUserAsync(user)
            ? Unauthorized()
            : Ok(new { Token = await _repository.UserAuthentication.CreateTokenAsync() });
    }
    
}
