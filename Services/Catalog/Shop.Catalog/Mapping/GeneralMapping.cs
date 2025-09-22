using AutoMapper;
using Shop.Catalog.Dtos.CategoryDtos;
using Shop.Catalog.Dtos.ContactDtos;
using Shop.Catalog.Dtos.FeatureServiceDtos;
using Shop.Catalog.Dtos.FeatureSliderDtos;
using Shop.Catalog.Dtos.ProductDetailDtos;
using Shop.Catalog.Dtos.ProductDtos;
using Shop.Catalog.Dtos.ProductImageDtos;
using Shop.Catalog.Dtos.SpecialOfferDtos;
using Shop.Catalog.Entities;

namespace Shop.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping() {

            CreateMap<Category,ResultCategoryDto>().ReverseMap();
            CreateMap<Category,CreateCategoryDto>().ReverseMap();
            CreateMap<Category,UpdateCategoryDto>().ReverseMap();
            CreateMap<Category,GetByIdCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();

            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();

            CreateMap<FeatureSlider, ResultFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, CreateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, UpdateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, GetByIdFeatureSliderDto>().ReverseMap();

            CreateMap<SpecialOffer, ResultSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, CreateSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, UpdateSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, GetByIdSpecialOfferDto>().ReverseMap();

            CreateMap<FeatureService, ResultFeatureServiceDto>().ReverseMap();
            CreateMap<FeatureService, CreateFeatureServiceDto>().ReverseMap();
            CreateMap<FeatureService, UpdateFeatureServiceDto>().ReverseMap();
            CreateMap<FeatureService, GetByIdFeatureServiceDto>().ReverseMap();

            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, GetByIdContactDto>().ReverseMap();

        }
    }
}
