using Microsoft.AspNetCore.Mvc;


public class SayTestController :Controller{

    //this action is accesible via the url( route): localhost:5000/hi


    [Route("test")]
    [HttpGet]

    public IActionResult Test()
    {
        var result = Content("Hello this is a test page");
        result.ContentType="text/plain";
        result.StatusCode =200;
        return result;
    }
}

