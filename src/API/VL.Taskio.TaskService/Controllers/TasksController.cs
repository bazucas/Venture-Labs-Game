using Microsoft.AspNetCore.Mvc;
using VL.Taskio.TaskService.Models;

namespace VL.Taskio.TaskService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    //private readonly Serilog.ILogger logger = Log.ForContext<TasksController>();

    private readonly ILogger<TasksController> _logger;

    public TasksController(ILogger<TasksController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogInformation(
            "Starting request {@RequestName}, {@DateTimeUtc}",
            nameof(TasksController),
            DateTime.UtcNow);
        //logger.Information(
        //    "Starting request {@RequestName}, {@DateTimeUtc}",
        //    nameof(TasksController),
        //    DateTime.UtcNow);

        try
        {
            var t = 1;
            throw new ArgumentNullException();
        }
        catch (Exception e)
        {
            _logger.LogError(
                "Request failure {@RequestName}, {@Error}, {@Exception}, {@DateTimeUtc}",
                nameof(TasksController), "Some error", e, DateTime.UtcNow);
            //logger.Error(
            //    "Request failure {@RequestName}, {@Error}, {@Exception}, {@DateTimeUtc}",
            //    nameof(TasksController), "Some error", e, DateTime.UtcNow);
        }


        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
            .ToArray();
    }
}