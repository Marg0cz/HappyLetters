using AutoMapper;

using HappyLetters.Dto.LetterRiddles;
using HappyLetters.Entities;
using HappyLetters.Infrastructure;
using HappyLetters.Repositories;

namespace HappyLetters.Services
{
    public class LetterRiddlesService : ILetterRiddlesService
    {
        private readonly ILetterRiddlesRepository _letterRiddlesRepository;
        private readonly IMapper _mapper;

        public LetterRiddlesService(ILetterRiddlesRepository letterRiddlesRepository, IMapper mapper)
        {
            _letterRiddlesRepository = letterRiddlesRepository;
            _mapper = mapper;
        }

        public async Task<Guid> AddRiddleAsync(LetterRiddleForCreationDto letterRiddle)
        {
            var newRiddleGuid = _letterRiddlesRepository.AddLetterRiddle(_mapper.Map<LetterRiddle>(letterRiddle));
            await _letterRiddlesRepository.SaveChangesAsync();
            return newRiddleGuid;
        }

        public async Task<LetterRiddleDto> GetRiddleAsync(Guid guid)
        {
            var letterRiddle = await _letterRiddlesRepository.GetLetterRiddleAsync(guid);
            return _mapper.Map<LetterRiddleDto>(letterRiddle);
        }

        public async Task<(IEnumerable<LetterRiddleDto>, PaginationMetadata)> GetRiddlesAsync(string? content, string? searchQuery, int pageNumber, int pageSize)
        {
            var letterRiddles = await _letterRiddlesRepository.GetLetterRiddlesAsync(content, searchQuery, pageNumber, pageSize);
            return _mapper.Map<(IEnumerable<LetterRiddleDto>, PaginationMetadata)>(letterRiddles);
        }

        public async Task<LetterRiddleDto> GetRandomRiddleAsync()
        {
            var riddle = await _letterRiddlesRepository.GetRandomRiddleAsync();
            return _mapper.Map<LetterRiddleDto>(riddle);
        }

        public void RemoveRiddle(LetterRiddleDto letterRiddle)
        {
            _letterRiddlesRepository.RemoveLetterRiddle(_mapper.Map<LetterRiddle>(letterRiddle));
        }
    }
}
