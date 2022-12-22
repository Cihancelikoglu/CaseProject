using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseProject.Core.Entities.Concrete
{
    [Table("OperationClaims")]
    public class OperationClaim
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
