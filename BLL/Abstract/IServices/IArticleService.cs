using Models.DTOs.Articles;

namespace BLL.Abstract.IServices
{
    public interface IArticleService
    {
        Task<List<ArticleDTo>> GetAllArticleAsync();
    }
}
