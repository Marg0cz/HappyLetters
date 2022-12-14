using System.Text.Json;
using HappyLetters.Dto.LetterRiddles;
using HappyLetters.Services;
using Microsoft.AspNetCore.Mvc;

namespace HappyLetters.Controllers;

[Route("api/[controller]")]
[Produces("application/json")]
[ApiController]
public class LetterRiddlesController : ControllerBase
{
    private const int MaxRiddlesPageSize = 20;
    private readonly ILetterRiddlesService _letterRiddlesService;

    public LetterRiddlesController(ILetterRiddlesService letterRiddlesService)
    {
        _letterRiddlesService = letterRiddlesService;
    }


    /// <summary>
    /// Get riddles.
    /// </summary>
    /// <param name="content"></param>
    /// <param name="searchQuery"></param>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <returns>
    /// The <see cref="IActionResult"/>.
    /// </returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRiddles(string? content, string? searchQuery, int pageNumber = 1,
        int pageSize = 10)
    {
        if (pageSize > MaxRiddlesPageSize)
        {
            pageSize = MaxRiddlesPageSize;
        }

        var (riddles, paginationMetadata) =
            await _letterRiddlesService.GetRiddlesAsync(content, searchQuery, pageNumber, pageSize);

        Response.Headers.Add("X-Pagination",
            JsonSerializer.Serialize(paginationMetadata));

        return Ok(riddles);
    }

    /// <summary>
    /// Get riddle by Guid.
    /// </summary>
    /// <param name="guid"></param>
    /// <returns>
    /// The <see cref="IActionResult"/>.
    /// </returns>
    [HttpGet("{guid}", Name = nameof(GetRiddle))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRiddle(Guid guid)
    {
        var riddle = await _letterRiddlesService.GetRiddleAsync(guid);
        if (riddle == null)
        {
            return NotFound();
        }

        return Ok(riddle);
    }

    /// <summary>
    /// Get random riddle.
    /// </summary>
    /// <returns>
    /// The <see cref="IActionResult"/>.
    /// </returns>
    [HttpGet("random")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRandomRiddle()
    {
        var riddle = await _letterRiddlesService.GetRandomRiddleAsync();
        if (riddle == null)
        {
            return NotFound();
        }
        return Ok(riddle);
    }

    /// <summary>
    /// Add new riddle
    /// </summary>
    /// <param name="letterRiddle"></param>
    /// <returns>
    /// The <see cref="IActionResult"/>.
    /// </returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> AddRiddle(LetterRiddleForCreationDto letterRiddle)
    {
        var newRiddleGuid = await _letterRiddlesService.AddRiddleAsync(letterRiddle);

        var routeValues = new {guid = newRiddleGuid};
        var createdResource = new
        {
            Guid = newRiddleGuid,
            Content = letterRiddle.Content,
            Solution = letterRiddle.Solution
        };

        return CreatedAtRoute(nameof(GetRiddle), routeValues, createdResource);
    }

    //[HttpPost]
    //public IActionResult PostSolution()
    //{

    //}
}