using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOUR_US.DAL;
using TOUR_US.DAL.Services;

namespace TOUR_US.BO.Service
{
    public class BaseBO
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;
        
        public BaseBO(IUnitOfWork unit,IMapper mapper)
        {
            _uow = unit;
            _mapper = mapper;
        }
    }
}
