using System.Collections.Generic;
using System.Threading.Tasks;
using SampleWebApi.Models;

namespace SampleWebApi.Repositories
{
    public interface IGenerateLinkRepository
    {
         /// <summary>
         /// رفتار بازگرداندن لینک که از لینک کوتاه استفاده میکند
         /// </summary>
         /// <param name="shortLink">لینک کوتاه</param>
         /// <returns></returns>
         Task<GenerateLinkEntity> GetWithShortLink(string shortLink);

        /// <summary>
        /// ایجاد لینک کوتاه
        /// </summary>
        /// <param name="toAdd">اینتیتی لینک کوتاه</param>
        /// <returns></returns>
        bool Add(GenerateLinkEntity toAdd);
     
    }
}
