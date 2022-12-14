using AutoMapper;
using HappyLetters.Dto.LetterRiddles;
using HappyLetters.Entities;
using HappyLetters.Infrastructure;

namespace HappyLetters.Profiles
{
    public class LetterRiddleProfile : Profile
    {
        public LetterRiddleProfile()
        {
            CreateMap<LetterRiddle, LetterRiddleDto>().ReverseMap();
            CreateMap<LetterRiddleForCreationDto, LetterRiddle>();
            CreateMap<(IEnumerable<LetterRiddle>, PaginationMetadata), (IEnumerable<LetterRiddleDto>, PaginationMetadata)>().ReverseMap();
        }
    }
}
