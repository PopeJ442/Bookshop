using AutoMapper;
using PopePhransisBookStore.DTO;
using PopePhransisBookStore.Model;



namespace PopePhransisBookStore.MappingProfile
{
    public class MappingProfile1 : Profile
    {
        public MappingProfile1()
        {
            CreateMap<Book, BookDTO>().ReverseMap();

        }
    }
}
