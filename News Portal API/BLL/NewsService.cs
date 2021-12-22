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
    public class NewsService
    {
        public static void Add(NewsModel nm)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsModel, News>());
            var mapper = new Mapper(config);
            DataAccessFactory.NewsDataAccess().Add(mapper.Map<News>(nm));
        }

        public static void Edit(NewsModel nm)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsModel, News>());
            var mapper = new Mapper(config);
            DataAccessFactory.NewsDataAccess().Edit(mapper.Map<News>(nm));
        }

        public static void Delete(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsModel, News>());
            var mapper = new Mapper(config);
            DataAccessFactory.NewsDataAccess().Delete(id);
        }

        public static List<NewsModel> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<NewsModel>>(DataAccessFactory.NewsDataAccess().Get());
            return data;
        }

        public static List<NewsModel> GetByCategory(string catg)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<NewsModel>>(DataAccessFactory.NewsDataAccess().Get().Where(n=>n.Category == catg).Select(n => n).ToList());
            return data;
        }

        public static List<NewsModel> GetByDate(DateTime dt)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<NewsModel>>(DataAccessFactory.NewsDataAccess().Get().Where(n => n.Date == dt).Select(n => n).ToList());
            return data;
        }

        public static List<NewsModel> GetByCatgDate(string catg, DateTime dt)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<NewsModel>>(DataAccessFactory.NewsDataAccess().Get().Where(n => (n.Date == dt) && (n.Category == catg)).Select(n => n).ToList());
            return data;
        }
    }
}
