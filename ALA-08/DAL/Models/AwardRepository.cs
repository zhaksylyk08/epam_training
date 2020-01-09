using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.EFData;
using DAL.Models;

namespace DAL.Models
{
    public class AwardRepository : IAwardRepository
    {
        private readonly WebAppContext _webAppContext;

        public AwardRepository(WebAppContext webAppContext)
        {
            _webAppContext = webAppContext;
        }

        public IEnumerable<Award> GetAllAwards()
        {
            return _webAppContext.Awards.ToList();
        }
    }
}
