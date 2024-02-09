using System;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonailDal;
        public TestimonialManager(ITestimonialDal testimonailDal)
        {
            _testimonailDal = testimonailDal;
        }

        public void TAdd(Testimonial entity)
        {
            _testimonailDal.Add(entity);
        }

        public void TDelete(Testimonial entity)
        {
            _testimonailDal.Delete(entity);
        }

        public Testimonial TGetById(int id)
        {
            return _testimonailDal.GetById(id);
        }

        public List<Testimonial> TGetLIstAll()
        {
            return _testimonailDal.GetLIstAll();
        }

        public void TUpdate(Testimonial entity)
        {
            _testimonailDal.Update(entity);
        }
    }
}

