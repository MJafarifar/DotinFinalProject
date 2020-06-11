using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SampleWebApi.Models;

namespace SampleWebApi.Repositories
{
    public class GenerateLinkRepository : IGenerateLinkRepository
    {
        private ApplicationDbContext _applicationDbContext = new ApplicationDbContext();

        public GenerateLinkRepository()
        {
    
        }

        //به منظور کلیک هر بار  باید به صورت اسنکرون نوشته شود
        public async Task<GenerateLinkEntity> GetWithShortLink(string shortLink)
        {
            try {
                if (_applicationDbContext.GenerateLink.Any(s => s.ShortenedURL == shortLink))
                {
                 
                    var tempModel =_applicationDbContext.GenerateLink.FirstOrDefault(x => x.ShortenedURL == shortLink);
                    tempModel.Clicked = tempModel.Clicked+1;
                  
                    _applicationDbContext.Entry(tempModel).State = EntityState.Modified;

                    await _applicationDbContext.SaveChangesAsync();
                    return tempModel;
                }
                else {
                    return null;
                }
            }
            catch(Exception e)
            {
                ///استفاده از لاگر 
                return null;
            }
        }

        public bool Add(GenerateLinkEntity toAdd)
        {

            try
            {
                _applicationDbContext.GenerateLink.Add(toAdd);
                _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                ///استفاده از لاگر
                return false;
            }
        }

      
    }
}