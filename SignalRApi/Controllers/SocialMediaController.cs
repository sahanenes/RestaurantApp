using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService _socialMediasService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediasService, IMapper mapper)
        {
            _socialMediasService = socialMediasService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var value = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediasService.TGetLIstAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            _socialMediasService.TAdd(new SocialMedia()
            {
                Icon = createSocialMediaDto.Icon,
                Title = createSocialMediaDto.Title,
                Url = createSocialMediaDto.Url
            });
            return Ok("SocialMedia was added successfuly");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediasService.TGetById(id);
            _socialMediasService.TDelete(value);
            return Ok("SocialMedia was deleted successfuly");
        }
        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {

            var value = _socialMediasService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            _socialMediasService.TUpdate(new SocialMedia
            {
               Icon = updateSocialMediaDto.Icon,
               SocialMediaID = updateSocialMediaDto.SocialMediaID,
               Title = updateSocialMediaDto.Title,
               Url = updateSocialMediaDto.Url
            });
            return Ok("SocialMedia was updated successfuly");
        }
    }
}

