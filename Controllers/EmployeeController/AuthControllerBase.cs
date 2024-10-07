using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers.EmployeeController
{
    [ApiController]
    [Route("api/v1/auth")]
    [Produces("application/json")]
    public abstract class AuthControllerBase : ControllerBase
    {
        protected readonly IAuthRepository _authRepository;

        public AuthControllerBase(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
    }
}