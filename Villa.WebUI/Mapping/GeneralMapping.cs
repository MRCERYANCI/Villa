using AutoMapper;
using Villa.DtoLayer.Dtos.BannerDtos;
using Villa.DtoLayer.Dtos.ContactDtos;
using Villa.DtoLayer.Dtos.CounterDtos;
using Villa.DtoLayer.Dtos.DealsDtos;
using Villa.DtoLayer.Dtos.FeatureDtos;
using Villa.DtoLayer.Dtos.MessageDtos;
using Villa.DtoLayer.Dtos.ProductDtos;
using Villa.DtoLayer.Dtos.QuestDtos;
using Villa.DtoLayer.Dtos.SocialMediaDtos;
using Villa.DtoLayer.Dtos.VideoDtos;
using Villa.EntityLayer.Entities;

namespace Villa.WebUI.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<ResultBannerDto, Banner>().ReverseMap();
            CreateMap<UpdateBannerDto, Banner>().ReverseMap();
            CreateMap<CreateBannerDto, Banner>().ReverseMap();

            CreateMap<ResultContactDto, Contact>().ReverseMap();
            CreateMap<UpdateContactDto, Contact>().ReverseMap();
            CreateMap<CreateContactDto, Contact>().ReverseMap();

            CreateMap<ResultCounterDto, Counter>().ReverseMap();
            CreateMap<UpdateCounterDto, Counter>().ReverseMap();
            CreateMap<CreateCounterDto, Counter>().ReverseMap();

            CreateMap<ResultDealsDto, Deal>().ReverseMap();
            CreateMap<UpdateDealsDto, Deal>().ReverseMap();
            CreateMap<CreateDealsDto, Deal>().ReverseMap();

            CreateMap<ResultFeatureDto, Feature>().ReverseMap();
            CreateMap<UpdateFeatureDto, Feature>().ReverseMap();
            CreateMap<CreateFeatureDto, Feature>().ReverseMap();

            CreateMap<ResultMessageDto, Message>().ReverseMap();
            CreateMap<UpdateMessageDto, Message>().ReverseMap();
            CreateMap<CreateMessageDto, Message>().ReverseMap();

            CreateMap<ResultProductDto, Product>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();
            CreateMap<CreateProductDto, Product>().ReverseMap();

            CreateMap<ResultQuestDto, Quest>().ReverseMap();
            CreateMap<UpdateQuestDto, Quest>().ReverseMap();
            CreateMap<CreateQuestDto, Quest>().ReverseMap();

            CreateMap<ResultVideoDto, Video>().ReverseMap();
            CreateMap<UpdateVideoDto, Video>().ReverseMap();
            CreateMap<CreateVideoDto, Video>().ReverseMap();

            CreateMap<ResultSocialMediaDto, SocialMedia>().ReverseMap();
            CreateMap<UpdateSocialMediaDto, SocialMedia>().ReverseMap();
            CreateMap<CreateSocialMediaDto, SocialMedia>().ReverseMap();
        }
    }
}
