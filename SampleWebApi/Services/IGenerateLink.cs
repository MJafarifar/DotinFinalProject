using SampleWebApi.Models;

namespace SampleWebApi.Services
{
  
    public interface IGenerateLink
    {

        #region تبدیل اینتیتی به  مدل مربوطه
        /// <summary>
        /// 
        /// </summary>
        /// <param name="GenerateLinkEntity"> اینتیتی مدل</param>
        /// <returns></returns>
        GenerateLinkDto MapToDto(GenerateLinkEntity GenerateLinkEntity);
        #endregion

        #region تبدیل مدل به اینتیتی
        /// <summary>
        /// 
        /// </summary>
        /// <param name="GenerateLinkDto">مدل </param>
        /// <returns></returns>
        GenerateLinkEntity MapToEntity(GenerateLinkDto GenerateLinkDto); 
        #endregion
    }
}