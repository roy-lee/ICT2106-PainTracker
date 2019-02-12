using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PainTracker.Models;

namespace PainTracker.Data.FollowUp
{
    // Mapper class that handles actual mapping/ translating of objects, and CRUD operations
    public class FollowUpDBMapper
    {
        // Mapper to support object mapping 
        private readonly IMapper _mapper;

        // DB Context to access DB
        internal TourContext db = new TourContext(new DbContextOptions<TourContext>());

        public FollowUpDBMapper(IMapper instMapper)
        {
            _mapper = instMapper;
        }

        // Select *
        public IEnumerable<Models.FollowUpModels.FollowUp> SelectAll()
        {
            IEnumerable<FollowUpDTO> resultEnumerable = db.FollowUpDTO.Include(fudto => fudto.QuestionId).Select(x => x).AsEnumerable();
            List<Models.FollowUpModels.FollowUp> returnEnumerable = new List<Models.FollowUpModels.FollowUp>();
            foreach (FollowUpDTO fudto in resultEnumerable)
            {
                System.Diagnostics.Debug.WriteLine("FollowUpDBMapper.SelectAll() - fudto.QuestionId.count = " + fudto.QuestionId.Count);
                returnEnumerable.Add(_mapper.Map<FollowUpDTO,Models.FollowUpModels.FollowUp>(fudto));
            }
            return returnEnumerable;
        }

        // Select by ID
        public Models.FollowUpModels.FollowUp SelectById(int id)
        {
            FollowUpDTO fudto = db.FollowUpDTO.Include(item => item.QuestionId).Single(x => x.FollowUpId == id);
            System.Diagnostics.Debug.WriteLine("FollowUpDBMapper.SelectById() - fudto.QuestionId.count = " + fudto.QuestionId.Count);
            return _mapper.Map<FollowUpDTO, Models.FollowUpModels.FollowUp>(fudto);
        }

        // Insert 
        public void Insert(Models.FollowUpModels.FollowUp fuvm)
        {
            FollowUpDTO insertFollowUps = new FollowUpDTO();
            insertFollowUps = _mapper.Map<FollowUpDTO>(fuvm);
            db.FollowUpDTO.Add(insertFollowUps);
        }

        // Persist changes to DB
        public void Save()
        {
            db.SaveChanges();
        }


    }
}
