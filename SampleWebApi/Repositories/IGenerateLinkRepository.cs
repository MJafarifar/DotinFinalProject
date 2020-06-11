using System.Collections.Generic;
using System.Threading.Tasks;
using SampleWebApi.Models;

namespace SampleWebApi.Repositories
{
    public interface IGenerateLinkRepository
    {

         Task<GenerateLinkEntity> GetWithShortLink(string shortLink);
        bool Add(GenerateLinkEntity toAdd);
     
    }
}
