using HappyLetters.DbContexts;
using HappyLetters.Entities;
using HappyLetters.Infrastructure;

using Microsoft.EntityFrameworkCore;

namespace HappyLetters.Repositories
{
    public class LetterRiddlesRepository : ILetterRiddlesRepository
    {
        private readonly RiddlesContext _context;

        public LetterRiddlesRepository(RiddlesContext context)
        {
            _context = context;
        }

        public async Task<LetterRiddle> GetRandomRiddleAsync()
        {
            var collection = _context.LetterRiddles as IQueryable<LetterRiddle>;
            return await collection
                .OrderBy((r) => EF.Functions.Random())
                .FirstOrDefaultAsync();
        }

        public async Task<LetterRiddle> GetLetterRiddleAsync(Guid guid)
        {
            return await _context.LetterRiddles
                .FirstOrDefaultAsync(x => x.Guid == guid);
        }

        public async Task<(IEnumerable<LetterRiddle>, PaginationMetadata)> GetLetterRiddlesAsync(string? content, string? searchQuery, int pageNumber, int pageSize)
        {
            var collection = _context.LetterRiddles as IQueryable<LetterRiddle>;

            if (!string.IsNullOrWhiteSpace(content))
            {
                content = content.Trim();
                collection = collection.Where(r => r.Content == content);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(x => x.Content.Contains(searchQuery) ||
                                                   x.Solution.Contains(searchQuery));
            }

            var totalItemCount = await collection.CountAsync();

            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

            var collectionToReturn = await collection.OrderBy(x => x.Content)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (collectionToReturn, paginationMetadata);
        }

        public void RemoveLetterRiddle(LetterRiddle letterRiddle)
        {
            _context.LetterRiddles.Remove(letterRiddle);
        }

        public Guid AddLetterRiddle(LetterRiddle letterRiddle)
        {
            var riddle = _context.LetterRiddles.Add(letterRiddle);
            return riddle.Entity.Guid;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
