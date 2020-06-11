using SampleWebApi.Models;

namespace SampleWebApi.Services
{
    public interface IGenerateLink
    {
        GenerateLinkDto MapToDto(GenerateLinkEntity houseEntity);
        GenerateLinkEntity MapToEntity(GenerateLinkDto houseDto);
    }
}