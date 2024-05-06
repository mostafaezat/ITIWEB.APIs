using AutoMapper;
using Core.Entities;
using ITIWEB.APIs.DTOs;
using Microsoft.IdentityModel.Tokens;
//using Microsoft.Extensions.Configuration;

namespace ITIWEB.APIs.Helpers
{
    public class pictureUrlResolver:IValueResolver<Product , ProductDto, string>
    {
        private readonly IConfiguration _configure;

        public pictureUrlResolver(IConfiguration Configure)
        {
            _configure = Configure;
        }

        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureURL))
            {
                return $"{_configure["ApiBaseUrl"]}{source.PictureURL}";
            }
            return null;
        }
    }
}
