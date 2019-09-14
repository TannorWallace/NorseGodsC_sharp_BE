using System;
using System.Linq;
using NorseGodApi.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NorseGodApi.Models;



namespace NorseGodApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class GodsController : ControllerBase
  {
    private readonly GodsRepository _repository;
    public GodsController(GodsRepository repository)
    {
      _repository = repository;
    }
    // POST api/values
    [HttpPost]
    public ActionResult<Gods> Post([FromBody] Gods gods)
    {
      try
      {
        return Ok(_repository.CreateGods(gods));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Gods>> GetAllGods()
    {
      try
      {
        return Ok(_repository.GetAllGods());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Gods> Get(int id)
    {
      try
      {
        return Ok(_repository.GetGodsById(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }


    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<Gods> DeleteGodById(int id)
    {
      try
      {
        return Ok(_repository.DeleteGodById(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
  }
}
