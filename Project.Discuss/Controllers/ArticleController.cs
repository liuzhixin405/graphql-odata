using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Project.Discuss.Domain;
using Project.Discuss.Models;

namespace Project.Discuss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ODataController
    {
        private readonly DiscussDbContext _dbContext;
        public ArticleController(DiscussDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// https://localhost:7077/api/article?$filter=articleid%20eq%2071614545
        /// </summary>
        /// <returns></returns>
        [EnableQuery]
        public ActionResult<IEnumerable<BbsArticle>> List()
        {
            return Ok(_dbContext.BbsArticles.Include(a => a.User).Include(a => a.BbsArticleContent).Include(a => a.BbsArticleCoins).ToList());
        }

        [EnableQuery]
        [HttpGet("GetArticle")]
        public ActionResult<BbsArticle> GetArticle([FromRoute] long articleId)
        {
            var item = _dbContext.BbsArticles.SingleOrDefault(d => d.ArticleId.Equals(articleId));

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
    }
}
