using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;

namespace Application.Common.Mapping;

public class CategoryMapProfile : Profile
{
    public CategoryMapProfile()
    {
        CreateMap<CreateCategoryRequest, Category>();

        CreateMap<Category, SingleCategoryResponse>();

        CreateMap<GetAllCategoryRequest, GetAllCategoryResponse>();

        CreateMap<UpdateCategoryRequest, Category>();
    }
}