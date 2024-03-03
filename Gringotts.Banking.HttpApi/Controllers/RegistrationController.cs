using Gringotts.Banking.Application.Contracts.Users;
using Gringotts.Banking.Application.Contracts.Users.Dto;
using Gringotts.Banking.HttpApi.Authentication;
using Gringotts.Banking.Shared.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Gringotts.Banking.HttpApi.Controllers
{

    [BasicAuthorization]
    [ApiController]
    [Route($"api/onboarding/registrations")]
    public class RegistrationController(IUserService userService) : ControllerBase
    {

        [HttpGet("user/is-exist/{id}")]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserIsExist(Guid id, CancellationToken cancellationToken)
        {
            var isUserRegistered = await userService.IsExistAsync(id, cancellationToken);

            return Ok(isUserRegistered);
        }

        [HttpPost("user/register")]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        public async Task<IActionResult> RegisterUser(UserCreateRequest userCreateRequest, CancellationToken cancellationToken)
        {
            var registerUserResult = await userService.CreateAsync(userCreateRequest, cancellationToken);

            return Ok(registerUserResult);
        }


        [HttpGet("user/{id}")]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUser(Guid id, CancellationToken cancellationToken)
        {
            var isUserRegistered = await userService.GetAsync(id, cancellationToken);

            return Ok(isUserRegistered);
        }
    }
}
