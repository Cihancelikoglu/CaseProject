using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseProject.Core.Entities.Concrete
{
    [Table("UserOperationClaims")]
    public class UserOperationClaim
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
