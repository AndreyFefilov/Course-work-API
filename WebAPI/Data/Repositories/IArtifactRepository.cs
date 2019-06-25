using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Entities;

namespace WebAPI.Data.Repositories
{
    public interface IArtifactRepository
    {
        Task<Artifact> AddArtifact(Artifact artifact);

        Task<Artifact> GetArtifact(int id);

        Task<IEnumerable<Artifact>> GetArtifactThread(int userId, int recipientId);
    }
}
