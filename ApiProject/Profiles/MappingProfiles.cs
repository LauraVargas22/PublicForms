using AutoMapper;
using Application.DTOs;
using Domain.Entities;

namespace ApiProject.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CategoriesCatalog, CategoriesCatalogDto>().ReverseMap();
            CreateMap<CategoryOptions, CategoriesCatalogDto>().ReverseMap();
            CreateMap<Chapters, ChaptersDto>().ReverseMap();
            CreateMap<OptionQuestions, OptionQuestionsDto>().ReverseMap();
            CreateMap<OptionsResponse, OptionsResponseDto>().ReverseMap();
            CreateMap<Questions, QuestionsDto>().ReverseMap();
            CreateMap<SubQuestions, SubQuestionsDto>().ReverseMap();
            CreateMap<SumaryOptions, SumaryOptionsDto>().ReverseMap();
            CreateMap<Surveys, SurveysDto>().ReverseMap();
        }
    }
}