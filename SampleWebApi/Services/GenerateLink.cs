using SampleWebApi.Models;

namespace SampleWebApi.Services
{
    public class GenerateLink : IGenerateLink
    {
        /// <summary>
        /// پیاده سازی اینترفیس اینتیتی به مدل
        /// </summary>
        /// <param name="generateLinkEntity"></param>
        /// <returns></returns>
        public GenerateLinkDto MapToDto(GenerateLinkEntity generateLinkEntity)
        {
            return new GenerateLinkDto()
            {
                Id = generateLinkEntity.Id,
                URL = generateLinkEntity.URL,
                ShortenedURL = generateLinkEntity.ShortenedURL,
                Clicked = generateLinkEntity.Clicked,
                Created = generateLinkEntity.Created,
                Token = generateLinkEntity.Token
            };
        }
        /// <summary>
        /// پیاده سازی تبدیل مدل به اینتیتی
        /// </summary>
        /// <param name="generateLinkDto"></param>
        /// <returns></returns>
        public GenerateLinkEntity MapToEntity(GenerateLinkDto generateLinkDto)
        {
            return new GenerateLinkEntity()
            {

                Id = generateLinkDto.Id,
                URL = generateLinkDto.URL,
                ShortenedURL = generateLinkDto.ShortenedURL,
                Clicked = generateLinkDto.Clicked,
                Created= generateLinkDto.Created,
                Token= generateLinkDto.Token
            };
        }
    }
}