using BlandGroupApi.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlandGroupApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserSettingsController : ControllerBase
{
    public UserSettingsController(){}


    [HttpGet("getUserAge")]
    [ProducesResponseType(200, Type = typeof(UserResponse))]
    [ProducesResponseType(400, Type = typeof(string))]
    public IActionResult getUserAge([FromQuery] string birthDate)
    {
        if (DateTime.TryParseExact(birthDate, "MM/dd/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime convertedBirthDate))
        {
            DateTime today = DateTime.Today;
            TimeSpan ageDifference = today - convertedBirthDate;

            int years = today.Year - convertedBirthDate.Year;
            int months = today.Month - convertedBirthDate.Month;
            int days = today.Day - convertedBirthDate.Day;
            int hours = ageDifference.Hours;
            int minutes = ageDifference.Minutes;
            int seconds = ageDifference.Seconds;

            // Adjusting the negative differences
            if (days < 0)
            {
                months--;
                days += DateTime.DaysInMonth(today.Year, today.Month);
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            string result = $"{years} years, {months} months, {days} days, {hours} hours, {minutes} minutes, {seconds} seconds";

            return Ok(new UserResponse { Age = result });
        }

        return BadRequest("Invalid date format. Please use the format MM/dd/yyyy.");
    }
}

