using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Task.Contracts.Abstracts;
using Task.Contracts.Modes;
using Task.Services.Interfaces;
using Task.Services.Interfaces.Generic;
using Task1.Models.ViewModels;
using Task1.Models.ViewModels.Sigle;

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

        //TODO: ??
        [HttpPost]
        public string NewGame()
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

            if (_gameService.GetByKey(game.Key) != null)
                return "Error! Same game-key is already exists.";

            _gameService.Create(game);

            return "Succeeded!";
        }

        //TODO: update game. Exception throws when .Satate = modifies
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
                return "Succeeded.";
            }

            return "Error! Game not found.";
        }

        [HttpGet]
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
        public string Remove(int? id, string key)
        {
            if (id.HasValue)
                _gameService.Delete(id.Value);
            else if (!key.IsNullOrWhiteSpace())
                _gameService.DeleteByKey(key);
            else
                return "Error! Bad parametrs.";
            return "Succeeded.";
        }

        [HttpGet]
        public string GameInfo(string key)
        {
            var game = _gameService.GetByKey(key);

            if (key.IsNullOrWhiteSpace() || game == null)
                return "Error! Bad game-key";

            var gameVm = Mapper.Map<Game, GameViewModel>(game);

            var json = new JavaScriptSerializer();
            var ret = json.Serialize(gameVm);

            return ret;
        }

        [HttpPost]
        public string RemoveGame(string key, string id)
        {
            if (!key.IsNullOrWhiteSpace())
            {
                if (_gameService.GetByKey(key) != null)
                {
                    _gameService.DeleteByKey(key);
                    return "Succeeded.";
                }
                else
                {
                    return "Error! Bad key.";
                }
            }
            else if (!id.IsNullOrWhiteSpace())
            {
                int intId;
                bool res = int.TryParse(id, out intId);
                if (res)
                {
                    _gameService.Delete(intId);
                    return "Succeeded.";
                }
                else
                    return "Error! Bad id.";
            }
            else
            {
                return "Error! No data.";
            }
        }

        [HttpPost]
        public string SetComment(CommentViewModel commentVm, bool isReply = false)
        {
            var comment = Mapper.Map<CommentViewModel, Comment>(commentVm);

            Comment parrent = null;

            if (!isReply)
            {
                comment.Parrent = null;
                commentVm.ParrentId = -1;
            }
            else
            {
                parrent = _commentService.GetById(commentVm.ParrentId);
            }

            var game = _gameService.GetById(commentVm.GameId);

            if ((parrent == null && isReply) || game == null)
                return "Error! Bad arguments.";

            if (isReply && parrent.Game.Id != commentVm.GameId)
                return "Error! Bad game/parrent ID.";

            _commentService.CreateForComment(comment, commentVm.GameId, commentVm.ParrentId);

            return "Succeded.";
        }

        [HttpGet]
        public FileResult DownloadGame(string gameKey)
        {
            var game = _gameService.GetByKey(gameKey);

            //if (game == null)
            //    asd();
            //return new HttpResponseMessage(HttpStatusCode.NotFound);

            //var result = new HttpResponseMessage(HttpStatusCode.OK);
            //var stream = new FileStream(@"C:\Users\Artem_Hanzha\fastFiles\SomeBinaryTestFile.txt", FileMode.Open, FileAccess.Read); //TODO: make path more complex
            //result.Content = new StreamContent(stream);
            //result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            //return result;
            if (game != null)
            {
                string filepath = @"C:\Users\Artem_Hanzha\fastFiles\SomeBinaryTestFile.txt";
                return File(filepath, System.Net.Mime.MediaTypeNames.Application.Octet, Path.GetFileName(filepath));
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public string GetComments(string gamekey)
        {
            var game = _gameService.GetByKey(gamekey);
            if (gamekey.IsNullOrWhiteSpace() || game == null)
                return "Error! Invalid game-key.";

            var comments = _commentService.GetByGameKey(gamekey);

            var comVm = Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentViewModel>>(comments);

            return new JavaScriptSerializer().Serialize(comVm);
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

        private bool IsNullOrWhiteSpace(params string[] strings)
        {
            bool isError = false;
            foreach (var str in strings)
            {
                isError |= str.IsNullOrWhiteSpace();
            }

            return isError;
        }


    }
}