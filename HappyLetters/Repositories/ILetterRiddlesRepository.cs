using HappyLetters.Entities;
using HappyLetters.Infrastructure;

namespace HappyLetters.Repositories
{
    public interface ILetterRiddlesRepository
    {
        Task<(IEnumerable<LetterRiddle>, PaginationMetadata)> GetLetterRiddlesAsync(string? content, string? searchQuery, int pageNumber, int pageSize);
        Task<LetterRiddle> GetRandomRiddleAsync();
        Task<LetterRiddle> GetLetterRiddleAsync(Guid guid);
        void RemoveLetterRiddle(LetterRiddle letterRiddle);
        Guid AddLetterRiddle(LetterRiddle letterRiddle);
        Task<bool> SaveChangesAsync();
    }
}
