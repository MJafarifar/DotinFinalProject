using SampleWebApi.Models;

namespace SampleWebApi.Services
{
    public class GenerateLink : IGenerateLink
    {
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