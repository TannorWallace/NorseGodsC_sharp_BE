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
    // NOTE next work on getting the SQL database set up and create the tabels that reflect the model you made! Keep it up bud! Practice makes...better in coding (LAWL!)
  }
}