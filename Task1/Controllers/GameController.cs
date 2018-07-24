using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Task.Contracts.Modes;
using Task.Services.Interfaces;
using Task1.ViewModel;
using Task1.ViewModel.Sigle;

namespace Task1.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IGenreService _genreService;
        private readonly IPlatformTypeService _platformService;

        public GameController(
            IGameService gameService, 
            IGenreService genreService, 
            IPlatformTypeService platformService)
        {
            _gameService = gameService;
            _genreService = genreService;
            _platformService = platformService;
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
        public string NewGame()
        {
            ICollection<Genre> genres = null;
            ICollection<PlatformType> platforms = null;

            if (Request["genres"] != null)
            {
                genres = new List<Genre>();
                foreach (var genreString in Request["genres"].Split(','))
                {
                    var genre = _genreService.GetByName(genreString);
                    if(genre != null)
                        genres.Add(genre);
                    //TODO: what to do if genre is null?
                }
            }

            if (Request["platforms"] != null)
            {
                platforms = new List<PlatformType>();

                foreach (var platformString in Request["platforms"].Split(','))
                {
                    var platform = _platformService.GetByName(platformString);
                    if(platform != null)
                        platforms.Add(platform);
                }
            }

            var game = new Game()
            {
                Name = Request["name"],
                Description = Request["description"],
                Key = Request["key"].IsNullOrWhiteSpace() ? Request["name"].Trim().ToLower().Replace(' ', '-') : Request["key"],
                Genres = genres,
                Platforms = platforms
            };

            return "Sucseeded!";
        }
    }
}