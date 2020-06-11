using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using SampleWebApi.Models;
using SampleWebApi.Repositories;
using SampleWebApi.Services;

namespace SampleWebApi.Controllers
{
    [RoutePrefix("api/GenerateLink")]
    public class GenerateLinkController : ApiController
    {
        private readonly IGenerateLinkRepository _GenerateLinkRepository;
        private GenerateLinkDto biturl;
        const int MaxPageSize = 10;
        private readonly IGenerateLink _GenerateLinkMapper;

        public GenerateLinkController(IGenerateLinkRepository GenerateLinkRepository, IGenerateLink GenerateLinkMapper)
        {
            _GenerateLinkRepository = GenerateLinkRepository;
            _GenerateLinkMapper = GenerateLinkMapper;
        }



        #region ایجاد لینک  کوتاه
        [HttpPost]

        public IHttpActionResult CreateShortLink(string url)
        {

            try
            {
                Uri uriResult;
                bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                if (!result)
                {
                    return Json(new { success = false, Message = "آدرس وارد شده صحیح نمی باشد." });
                }
                var uri = new Uri(url);
                var host = uri.Host;
                string scheme = uri.Scheme;

                string token = GenerateToken();
                biturl = new GenerateLinkDto()
                {
                    Token = token,
                    URL = url,
                    ShortenedURL = scheme + "://" + host + "/" + token
                };

                GenerateLinkEntity GenerateEntity = _GenerateLinkMapper.MapToEntity(biturl);

                bool results = _GenerateLinkRepository.Add(GenerateEntity);


                return Json(new { success = true, Message = "لینک کوتاه با موفقیت تولید شد.", shortLink = scheme + "://" + host + "/" + token });
            }
            catch (Exception e) {
                return Json(new { success = false, Message = "مشکل از سمت سرور" });
            }
         
        }
        private string GenerateToken()
        {
            string urlsafe = string.Empty;
            Enumerable.Range(48, 75)
              .Where(i => i < 58 || i > 64 && i < 91 || i > 96)
              .OrderBy(o => new Random().Next())
              .ToList()
              .ForEach(i => urlsafe += Convert.ToChar(i)); // Store each char into urlsafe
            string Token = urlsafe.Substring(new Random().Next(0, urlsafe.Length), new Random().Next(2, 6));
            return Token;
        }
        #endregion

        #region دریافت لینک با استفاده از لینک کوتاه
        [HttpGet]
        public async Task<IHttpActionResult> GetWithShortLink(string shortLink)
        {
            try
            {
                GenerateLinkEntity GenerateLinkEntity = await _GenerateLinkRepository.GetWithShortLink(shortLink);

                if (GenerateLinkEntity == null)
                {
                    return Json(new { success = false, Message = "لینک مورد نظر موجود نیست" });
                }

                GenerateLinkDto model = _GenerateLinkMapper.MapToDto(GenerateLinkEntity);
                return Json(new { success = true, Url = model.URL });
            }
            catch (Exception e)
            {
                return Json(new { success = false, Message = "مشکل از سمت سرور" });
            }
        }
        #endregion








    }
}