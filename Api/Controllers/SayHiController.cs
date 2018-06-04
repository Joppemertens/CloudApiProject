using Microsoft.AspNetCore.Mvc;


public class SayHiController :Controller{

    //this action is accesible via the url( route): localhost:5000/hi


    [Route("hi")]
    [HttpGet]

    public IActionResult Hello()
    {
        var result = Content("Hello world !");
        result.StatusCode =200;
        return result;
    }
}

public class Return404Controller :Controller{
    [Route("give404")]
    public IActionResult Givenothing()
    {
        return NotFound("404 no resource found");
        
    }
}