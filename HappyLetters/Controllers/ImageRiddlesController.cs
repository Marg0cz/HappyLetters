//using HappyLetters.Dto;

//using Microsoft.AspNetCore.Mvc;

//namespace HappyLetters.Controllers;

//[Route("api/[controller]")]
//[ApiController]
//public class ImageRiddlesController : ControllerBase
//{
//    [HttpGet]
//    public IActionResult GetImageRiddles()
//    {
//        return Ok(TempDataStore.GetImageRiddles());
//    }

//    [HttpGet("random")]
//    public IActionResult GetRandomImageRiddle()
//    {
//        return Ok(TempDataStore.GetRandomLetterRiddle());
//    }

//    [HttpPost]
//    public IActionResult PostSolution(ImageRiddleSolutionDto imageRiddleSolution)
//    {
//        if (!TempDataStore.DoesAnswerExist(imageRiddleSolution))
//        {
//            return NotFound($"Solution with id: {imageRiddleSolution} does not exist");
//        }

//        return Ok(TempDataStore.IsAnswerCorrect(imageRiddleSolution));
//    }
//}
