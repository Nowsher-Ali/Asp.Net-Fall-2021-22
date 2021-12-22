using BEL;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Application.Controllers
{
    public class NewsController : ApiController
    {
        [Route("api/News/All")]
        [HttpGet]
        public List<NewsModel> GetAll()
        {
            return NewsService.GetAll();
        }

        [Route("api/News/Add")]
        [HttpPost]
        public void Add(NewsModel nm)
        {
            NewsService.Add(nm);
        }
        [Route("api/News/Edit")]
        [HttpPost]
        public void Edit(NewsModel nm)
        {
            NewsService.Edit(nm);
        }

        [Route("api/News/Delete")]
        [HttpPost]
        public void Delete(int id)
        {
            NewsService.Delete(id);
        }

        [Route("api/News/GetByCategory")]
        [HttpGet]
        public void GetByCategory(string catg)
        {
            NewsService.GetByCategory("General");
        }
    }
}
