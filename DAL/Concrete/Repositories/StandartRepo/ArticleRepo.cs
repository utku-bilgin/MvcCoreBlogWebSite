using Core.IBaseRepositories;
using DAL.Abstract;
using DAL.Base;
using DAL.Concrete.Context;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.Repositories.StandartRepo
{
    public class ArticleRepo : BaseStandartContextRepo<Article, StandartContext>, IArticleRepo
    {
    }
}
