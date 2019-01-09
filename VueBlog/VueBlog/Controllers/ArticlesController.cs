using System.Collections.Generic;
using System.Web.Http;
using VueBlog.Database;
using VueBlog.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using VueBlog.Database.Entities;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Linq;
using System;

namespace VueBlog.Controllers
{
    [RoutePrefix("api/articles")]
    public class ArticlesController : ApiController
    {
        private readonly BlogDbContext _dbContext;

        public ArticlesController(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<ArticleViewModel>> Get()
        {
            var articles = await _dbContext
                .Articles
                .Include(a => a.Comments)
                .ToListAsync();

            var models = Mapper.Map<IEnumerable<ArticleViewModel>>(articles);

            return models;
        }

        [HttpGet]
        public async Task<ArticleViewModel> Get(int id)
        {
            var article = await _dbContext
                .Articles
                .Include(a => a.Comments)
                .SingleAsync(a => a.Id == id);

            var model = Mapper.Map<ArticleViewModel>(article);

            return model;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<BlogArticle> Post(ArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newArticle = Mapper.Map<BlogArticle>(model);

                _dbContext.Articles.Add(newArticle);

                await _dbContext.SaveChangesAsync();

                return newArticle;
            }
            else
            {
                throw new System.Exception("Bad request");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("comments")]
        public async Task<ArticleCommentViewModel> Post(ArticleCommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var domainEntity = Mapper.Map<ArticleComment>(model);

                _dbContext.ArticleComments.Add(domainEntity);

                await _dbContext.SaveChangesAsync();

                model = Mapper.Map<ArticleCommentViewModel>(domainEntity);

                return model;
            }
            else
            {
                throw new System.Exception("Bad request");
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var articleToDelete = _dbContext.Articles.SingleOrDefault(a => a.Id == id);

            if(articleToDelete != null)
            {
                _dbContext.Articles.Remove(articleToDelete);
                var rowsAffected = await _dbContext.SaveChangesAsync();

                return Ok();
            }
            else
            {
                return Conflict();
            }
        }
    }
}
