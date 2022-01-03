﻿using CkwSocial.Application.Models;
using CwkSocial.Api.Contracts.Common;
using Microsoft.AspNetCore.Mvc;

namespace CwkSocial.Api.Controllers.V1
{
    public class BaseController: ControllerBase
    {
        protected IActionResult HandleErrorResponse(List<Error> errors)
        {
            var apiError = new ErrorResponse();

            if (errors.Any(e => e.Code == CkwSocial.Application.Enums.ErrorCode.NotFound))
            {
                var error = errors.FirstOrDefault(e =>e.Code == CkwSocial.Application.Enums.ErrorCode.NotFound);
                apiError.StatusCode = 404;
                apiError.StatusPhrase = "Not Found";
                apiError.Timestamp = DateTime.Now;
                apiError.Errors.Add(error.Message);

                return NotFound(apiError);
            }
            apiError.StatusCode = 500;
            apiError.StatusPhrase = "Internal server error";
            apiError.Timestamp = DateTime.Now;
            apiError.Errors.Add("Unknown error");
            return StatusCode(500, apiError);

        }
    }
}
