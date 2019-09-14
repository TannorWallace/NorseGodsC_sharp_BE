using System;
using Dapper;
using System.Data;
using NorseGodApi.Models;
using System.Collections.Generic;

namespace NorseGodApi.Data
{
  public class GodsRepository
  {
    private readonly IDbConnection _db;
    public GodsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Gods CreateGods(Gods gods)
    {
      int id = _db.ExecuteScalar<int>(@"INSERT INTO gods (name, img, description) VALUES (@Name, @Img, @Description); SELECT LAST_INSERT_ID();", gods);
      gods.Id = id;
      return gods;
    }

    public IEnumerable<Gods> GetAllGods()
    {
      return _db.Query<Gods>("SELECT * FROM gods");
    }

    public Gods GetGodsById(int id)
    {
      try
      {
        return _db.QuerySingle<Gods>("SELECT * FROM gods WHERE id = @id", new { id });
      }
      catch (Exception e)
      {

        throw new Exception(e.Message);
      }
    }

    public bool DeleteGodById(int id)
    {
      var complete = _db.Execute("DELETE FROM gods WHERE id = @id", new { id });
      return complete > 0;
      {
        throw new Exception("failed to delete");
      }
    }
    // NOTE next work on getting the SQL database set up and create the tabels that reflect the model you made! Keep it up bud! Practice makes...better in coding (LAWL!)
  }
}