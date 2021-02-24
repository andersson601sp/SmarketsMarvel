using AutoMapper;
using Smarkets.Marvel.Application.ViewModels;
using Smarkets.Marvel.Domain.Entities;

namespace Smarkets.Marvel.Application.AutoMapper
{
	public class DomainToViewModelProfile : Profile
	{
		public DomainToViewModelProfile()
		{
			CreateMap<Character, CharacterViewModel>()
				.ForMember(dest => dest.ThumbnailUrl, opt => opt.MapFrom(src => src.Thumbnail != null ? $"{src.Thumbnail.Path}/portrait_incredible.{src.Thumbnail.Extension}" : ""))
				.ForMember(dest => dest.Stories, opt => opt.MapFrom(src => src.Stories.Items));

			CreateMap<SearchHistory, SearchHistoryViewModel>();
		}
	}
}