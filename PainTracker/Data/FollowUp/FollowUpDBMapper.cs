using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

        public IEnumerable<Models.FollowUpModels.FollowUp> SelectAll()
        {
            IEnumerable<FollowUpDTO> resultEnumerable = db.FollowUpDTO.Select(x => x).AsEnumerable();
            List<Models.FollowUpModels.FollowUp> returnEnumerable = new List<Models.FollowUpModels.FollowUp>();
            foreach (FollowUpDTO fudto in resultEnumerable)
            {
                returnEnumerable.Add(_mapper.Map<FollowUpDTO,Models.FollowUpModels.FollowUp>(fudto));
                System.Diagnostics.Debug.WriteLine("returnEnumerable size = " + returnEnumerable.Count());
            }
            return returnEnumerable;
        }

        public Models.FollowUpModels.FollowUp SelectById(int id)
        {
            return _mapper.Map<FollowUpDTO, Models.FollowUpModels.FollowUp>(db.FollowUpDTO.Find(id));
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
