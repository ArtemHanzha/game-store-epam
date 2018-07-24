using System.Collections.Generic;
using Task.Contracts.Modes;
using Task.Services.Interfaces.Generic;

namespace Task.Services.Interfaces
{
    public interface ICommentService : IService<Comment>
    {
        IEnumerable<Comment> GetByGameKey(string gameKey);

        void CreateForComment(Comment item, int gameId, int parrentCommentId = -1);
    }
}