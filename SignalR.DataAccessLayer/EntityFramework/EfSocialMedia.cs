using System;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfSocialMedia : GenericRepository<SocialMedia>, ISocialMediaDal
    {
        public EfSocialMedia(SignalRContext context) : base(context)
        {
        }
    }
}

