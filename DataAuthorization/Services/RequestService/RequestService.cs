using System.Collections.Generic;
using DataAuthorization.DataBase;
using DataAuthorization.DataBase.Entities;

namespace DataAuthorization.Services.UserService
{
    public class RequestService : IRequestService
    {
        private readonly AppDbContext _dbContext;

        public RequestService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public int AddRequest(Request request)
        {
           _dbContext.Requests.Add(request);
           var changes = _dbContext.SaveChanges();
           return changes;
        }

        public IEnumerable<Request> GetAllRequest()
        {
            return _dbContext.Requests;
        }
    }
}
