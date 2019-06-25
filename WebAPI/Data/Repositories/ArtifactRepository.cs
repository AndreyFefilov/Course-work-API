using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Entities;

namespace WebAPI.Data.Repositories
{
    public class ArtifactRepository: IArtifactRepository
    {
        private readonly DataContext _context;

        public ArtifactRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Artifact> AddArtifact(Artifact artifact)
        {
            await _context.Artifacts.AddAsync(artifact);
            await _context.SaveChangesAsync();

            return artifact;
        }

        public async Task<Artifact> GetArtifact(int id)
        {
            return await _context.Artifacts.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Artifact>> GetArtifactThread(int userId, int recipientId)
        {
            var artifacts = await _context.Artifacts
                .Include(u => u.Student)
                .Include(u => u.Teacher)
                .Where(a => (a.TeacherId == userId && a.StudentId == recipientId)
                    || (a.TeacherId == recipientId && a.StudentId == userId))
                .OrderBy(a => a.DateSend)
                .ToListAsync();

            return artifacts;
        }
    }
}
