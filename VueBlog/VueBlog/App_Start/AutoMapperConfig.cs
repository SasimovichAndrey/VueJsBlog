using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VueBlog.Database.Entities;
using VueBlog.Models;

namespace VueBlog
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(RegisterMappings);
        }

        private static void RegisterMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<BlogArticle, ArticleViewModel>().ReverseMap();
            cfg.CreateMap<ArticleComment, ArticleCommentViewModel>().ReverseMap();
        }
    }
}