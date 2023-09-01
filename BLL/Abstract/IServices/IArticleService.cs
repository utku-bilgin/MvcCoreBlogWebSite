using Models.DTOs.Articles;

namespace BLL.Abstract.IServices
{
    public interface IArticleService
    {
        Task<List<ArticleDTo>> GetAllArticleWithCategoryNonDeletedAsync();

        Task<ArticleDTo> GetArticleWithCategoryNonDeletedAsync(Guid articleId);

        Task CreateArticleAsync(ArticleAddDTo articleAddDTo);

        Task<string> UpdateArticleAsync(ArticleUpdateDTo articleUpdateDTo);

        Task<string> SafeDeleteArticleAsync(Guid articleId);
    }
}
