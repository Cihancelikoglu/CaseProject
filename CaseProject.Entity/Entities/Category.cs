using Dapper.Contrib.Extensions;
using System;

namespace CaseProject.Entity.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool Status { get; set; }
    }
}
