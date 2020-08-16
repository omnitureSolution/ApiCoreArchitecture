using AutoMapper;
using AutoMapper.QueryableExtensions;
using Omniture.Core.Interfaces.Common;
using Omniture.Core.Interfaces.Services.Masters;
using Omniture.Db.Abstractions.Enums;
using Omniture.Db.Entity.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MastersService
{
    public class Masters : IMasters
    {
        private OmnitureContext _omnitureContext;
        private IMapper _mapper;
        public Masters(OmnitureContext omnitureContext, IMapper mapper)
        {
            _omnitureContext = omnitureContext;
            _mapper = mapper;
        }
     
        public Task<List<ListTable>> GetPersonTypes()
        {
            return null;
        }



        public Task<List<ListTable>> GetCountries()
        {
            throw new NotImplementedException();
        }
    }
}
