using AutoMapper;
using ECommerceApi.Dto.Dtos.AddressDtos;
using ECommerceApi.Dto.Dtos.CategoryDtos;
using ECommerceApi.Dto.Dtos.ProductDtos;
using ECommerceApi.Dto.Dtos.StoreDtos;
using ECommerceApi.Dto.Dtos.UserDtos;
using ECommerceApi.Entity.Entities;

namespace ECommerceApi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {

            CreateMap<ResultProductDto, Product>().ReverseMap();
                //.ForMember(dto => dto.Store, opt => opt.MapFrom(src => src.Store));
            CreateMap<UpdateProductDto, Product>().ReverseMap();
            CreateMap<CreateProductDto, Product>().ReverseMap();


            CreateMap<ResultCategoryForProductDto, Category>().ReverseMap();
            CreateMap<ResultCategoryDto, Category>().ReverseMap();
                //.ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.Id.ToString())); // ObjectId'yi string'e otomatik dönüştürme
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>().ReverseMap();


            CreateMap<CreateStoreDto, Store>().ReverseMap();
            CreateMap<ResultStoreDto, Store>().ReverseMap();
            CreateMap<ResultStoreForProductDto, Store>().ReverseMap();


            CreateMap<CreateAddressDto, Address>().ReverseMap();
            CreateMap<ResultAddressDto, Address>().ReverseMap();

            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<ResultUserDto, User>().ReverseMap();

        }
    }
}
