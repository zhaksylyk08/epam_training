using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL.Models
{
    public interface IAwardRepository
    {
        IEnumerable<Award> GetAllAwards();
    }
}
