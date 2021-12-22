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
    public class CommentService
    {
        public static List<CommentModel> GetCommentsByNewsId(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<CommentModel>>(DataAccessFactory.CommentDataAccess().Get().Where(n => n.FK_News_Id == id).Select(n => n).ToList());
            return data;
        }
    }
}
