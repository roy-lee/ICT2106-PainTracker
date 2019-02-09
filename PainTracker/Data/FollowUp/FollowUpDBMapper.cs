using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PainTracker.Models;

namespace PainTracker.Data.FollowUp
{
    public class FollowUpDBMapper
    {
        private readonly IMapper _mapper;
        internal TourContext db = new TourContext(new DbContextOptions<TourContext>());

        public FollowUpDBMapper(IMapper instMapper)
        {
            _mapper = instMapper;
        }

        public void Insert(Models.FollowUpModels.FollowUp fuvm)
        {
            FollowUpDTO insertFollowUps = new FollowUpDTO();
            insertFollowUps = _mapper.Map<FollowUpDTO>(fuvm);
            db.FollowUpDTO.Add(insertFollowUps);
        }

        public void Save()
        {
            db.SaveChanges();
        }


    }
}
