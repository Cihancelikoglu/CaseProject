using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseProject.Core.Utilities.Helpers.FileHelper.Abstract
{
    public interface IFileHelper
    {
        Task<string> Upload(IFormFile file, string root);
        void Delete(string filePath);
        Task<string> Update(IFormFile file, string filePath, string root);

    }
}
