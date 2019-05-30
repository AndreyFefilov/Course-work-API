using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Data.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClustersController : ControllerBase
    {
        private readonly DataContext _context;

        public ClustersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Clusters
        [HttpGet("get-clusters")]
        public async Task<ActionResult<IEnumerable<Cluster>>> GetClusters()
        {
            return await _context.Clusters.ToListAsync();
        }
    }
}
