using HappyLetters.Dto.LetterRiddles;
using HappyLetters.Infrastructure;

namespace HappyLetters.Services
{
    public interface ILetterRiddlesService
    {
        Task<(IEnumerable<LetterRiddleDto>, PaginationMetadata)> GetRiddlesAsync(string? content, string? searchQuery, int pageNumber, int pageSize);
        Task<LetterRiddleDto> GetRiddleAsync(Guid guid);
        void RemoveRiddle(LetterRiddleDto letterRiddle);
        Task<LetterRiddleDto> GetRandomRiddleAsync();
        Task<Guid> AddRiddleAsync(LetterRiddleForCreationDto letterRiddle);
    }
}
