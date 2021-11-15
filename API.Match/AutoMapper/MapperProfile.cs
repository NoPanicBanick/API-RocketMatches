using API.Match.v1.Models;
using AutoMapper;
using DataAccess.Match.v1.DataEntities;
using System;

namespace API.Match.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region V1 Mappings
            // Class1 Mappings
            CreateMap<MatchTableEntity, MatchModel>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => Guid.Parse(src.RowKey)))
                .ForMember(dest => dest.Playlist, opt => opt.MapFrom(src => src.PartitionKey));

            CreateMap<MatchAddModel, MatchTableEntity>()
                .ForMember(dest => dest.RowKey, opt => opt.Ignore())
                .ForMember(dest => dest.PartitionKey, opt => opt.MapFrom(src => src.Playlist))
                .ForMember(dest => dest.LastModifiedOnUTCDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOnUTCDate, opt => opt.Ignore());

            CreateMap<MatchUpdateModel, MatchTableEntity>()
                .ForMember(dest => dest.RowKey, opt => opt.MapFrom(src => src.ID.ToString()))
                .ForMember(dest => dest.PartitionKey, opt => opt.MapFrom(src => src.Playlist))
                .ForMember(dest => dest.CreatedOnUTCDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedOnUTCDate, opt => opt.Ignore());
            #endregion
        }
    }
}
