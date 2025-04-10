using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.BLL.Services.AttachementServices
{
    public interface IAttachementServices
    {
        public string? Uplode(IFormFile file , string FolderName);

        bool Delete (string FolderName);    
    }
}
