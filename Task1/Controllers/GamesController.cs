using System.Collections;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Task.Contracts.Abstracts;
using Task.Contracts.Modes;
using Task.Services.Interfaces;
using Task.Services.Interfaces.Generic;
using Task1.ViewModel;
using Task1.ViewModel.Sigle;

namespace Task1.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IGenreService _genreService;
        private readonly IPlatformTypeService _platformService;
        private readonly ICommentService _commentService;

        public GamesController(
            IGameService gameService, 
            IGenreService genreService, 
            IPlatformTypeService platformService, 
            ICommentService commentService)
        {
            _gameService = gameService;
            _genreService = genreService;
            _platformService = platformService;
            _commentService = commentService;
        }


        // GET
        public string List()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            var games = _gameService.Get();
            var gamesVm = Mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(games);

            var model = new GamesListviewModel()
            {
                Games = gamesVm
            };

            return serializer.Serialize(model);
        }

        [HttpPost]
        public string NewGame() //TODO: exception
        {
            IEnumerable<Genre> genres = null;
            IEnumerable<PlatformType> platforms = null;

            genres = GetListFromRequest("genres", _genreService);

            platforms = GetListFromRequest("platforms", _platformService);

            var game = new Game()
            {
                Name = Request["name"],
                Description = Request["description"],
                Key = Request["key"].IsNullOrWhiteSpace() ? Request["name"].Trim().ToLower().Replace(' ', '-') : Request["key"],
                Genres = genres as ICollection<Genre>,
                Platforms = platforms as ICollection<PlatformType>
            };

            _gameService.Create(game);

            return "Sucseeded!";
        }
        
        [HttpPost]
        public string UpdateGame(GameViewModel gameViewModel)
        {
            var game = _gameService.GetById(gameViewModel.Id);
            if (game != null)
            {
                game = Mapper.Map<GameViewModel, Game>(gameViewModel);

                game.Genres = GetListFromRequest("genres", _genreService) as ICollection<Genre>;
                game.Platforms = GetListFromRequest("platforms", _platformService) as ICollection<PlatformType>;
                game.Comments = GetListFromRequest("comments", _commentService) as ICollection<Comment>;

                _gameService.Update(game);
                return "Sucseeded.";
            }

            return "Error! Game not found.";
        }

        private IEnumerable<TRequest> GetListFromRequest<TRequest>(string listName, INameFilterService<TRequest> service) where TRequest : AbstractDbObject
        {
            ICollection<TRequest> collection = null;

            if (Request[listName] != null)
            {
                collection = new List<TRequest>();

                foreach (var platformString in Request[listName].Split(','))
                {
                    var platform = service.GetByName(platformString);
                    if (platform != null)
                        collection.Add(platform);
                }
            }

            return collection;
        }
    }
}