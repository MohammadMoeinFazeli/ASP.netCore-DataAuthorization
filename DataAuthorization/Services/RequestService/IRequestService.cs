using System.Collections.Generic;
using DataAuthorization.DataBase.Entities;

namespace DataAuthorization.Services.UserService
{
    public interface IRequestService
    {
        int AddRequest(Request request);
        IEnumerable<Request> GetAllRequest();
    }
}
