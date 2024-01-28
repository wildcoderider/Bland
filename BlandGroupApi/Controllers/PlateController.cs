using System;
using BlandGroupApi.Interfaces;
using BlandGroupApi.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlandGroupApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlateController : ControllerBase
    {
        private readonly IPlateReaderService _plateReaderService;

        public PlateController(IPlateReaderService plateReaderService) {

            _plateReaderService = plateReaderService;
        }


        [HttpGet("filterPlate")]
        [ProducesResponseType(200, Type = typeof(FilterPlateResponse))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> filterPlate([FromQuery] string camera, DateTime dateFrom, DateTime dateTo)
        {
            if (!string.IsNullOrEmpty(camera) && IsValidDateRange(dateFrom, dateTo))
            {
                var response = await _plateReaderService.GetPlatesAsync(camera, dateFrom, dateTo);
                return Ok(new FilterPlateResponse { Plates = response });
            }

            return BadRequest("Invalid input. Please provide a valid camera and date range.");
        }

        private bool IsValidDateRange(DateTime dateFrom, DateTime dateTo)
        {
            if (dateFrom > dateTo)
            {
                return false;
            }

            return true;
        }
    }
}

