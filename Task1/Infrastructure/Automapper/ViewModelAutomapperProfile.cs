using System.Collections.Generic;
using AutoMapper;
using Task.Contracts.Modes;
using Task1.ViewModel.Sigle;

namespace Task1.Infrastructure.Automapper
{
    public class ViewModelAutomapperProfile : Profile
    {
        public ViewModelAutomapperProfile()
        {
            #region Game -> gameVM

            CreateMap<Game, GameViewModel>()
                .ForMember(g => g.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(g => g.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(g => g.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(g => g.Key, opt => opt.MapFrom(s => s.Key))
                .ForMember(g => g.Comments, opt => opt.MapFrom(
                     s => Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentViewModel>>(s.Comments)))
                .ForMember(g => g.Genres, opt => opt.MapFrom(
                     s => Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreViewModel>>(s.Genres)))
                .ForMember(g => g.Platforms, opt => opt.MapFrom(
                     s => Mapper.Map<IEnumerable<PlatformType>, IEnumerable<PlatformTypeViewModel>>(s.Platforms)));

            #endregion

            #region SubGenre -> genreVM

            CreateMap<Genre, GenreViewModel>()
                .ForMember(g => g.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(g => g.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(g => g.SubGenres, opt => opt.MapFrom(
                    s => Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreViewModel>>(s.SubGenres)));

            #endregion

            #region PlatformType -> platformTypeVM

            CreateMap<PlatformType, PlatformTypeViewModel>()
                .ForMember(p => p.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(p => p.Name, opt => opt.MapFrom(s => s.Type));

            #endregion

            #region Comment -> CommentVM

            CreateMap<Comment, CommentViewModel>()
                .ForMember(c => c.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(c => c.Title, opt => opt.MapFrom(s => s.Name))
                .ForMember(c => c.Text, opt => opt.MapFrom(s => s.Body))
                .ForMember(c => c.UserName, opt => opt.MapFrom(s => s.AuthorName))
                .ForMember(c => c.Parrent, opt => opt.MapFrom(
                    s => Mapper.Map<Comment, CommentViewModel>(s.Parrent)));

            #endregion

            #region GameVM -> Game

            CreateMap<GameViewModel, Game>()
                .ForMember(g => g.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(g => g.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(g => g.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(g => g.Key, opt => opt.MapFrom(s => s.Key))
                .ForMember(g => g.Genres, opt => opt.Ignore())
                .ForMember(g => g.Platforms, opt => opt.Ignore())
                .ForMember(g => g.Comments, opt => opt.Ignore());

            #endregion
        }
    }
}