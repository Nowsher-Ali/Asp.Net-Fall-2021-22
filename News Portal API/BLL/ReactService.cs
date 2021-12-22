using AutoMapper;
using BEL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReactService
    {
        public static List<ReactModel> GetReactsByNewsId(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<React, ReactModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<ReactModel>>(DataAccessFactory.ReactDataAccess().Get().Where(n => n.FK_News_Id == id).Select(n=>n).ToList());
            return data;
        }
    }
}
