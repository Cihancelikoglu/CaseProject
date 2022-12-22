using CaseProject.Core.Entities.Concrete;
using CaseProject.Entity.Entities;

namespace CaseProject.Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        Task<AccessToken> CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
