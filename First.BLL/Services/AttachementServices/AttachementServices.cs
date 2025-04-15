using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.BLL.Services.AttachementServices
{
    public class AttachementServices : IAttachementServices
    {
        List<string> allowedExtensions = [".png" , ".jpg" , "jpeg"];
        const int maxSize = 2_097_152;
        public string? Uplode(IFormFile file, string FolderName)
        {
            //01 Check Extionsion 
            var extension = Path.GetExtension(file.FileName);
            if (!allowedExtensions.Contains(extension)) return null;
            //02 Chick size
            if (file.Length == 0 || file.Length>maxSize) return null;
            //03 Get Location Folder Pase
            var FolderPath = Path.Combine( Directory.GetCurrentDirectory() , "wwwroot\\Filse", FolderName);
            //04 Mack attachment name unique --GUID
            var fileName = $"{Guid.NewGuid()}_{file.Name}";
            //05 GET File Path
            var filePath = Path.Combine( FolderPath, fileName );
            //06 Create File  StreamToCoupy File
            using FileStream fs = new FileStream(filePath, FileMode.Create);
            //07 Use Stream to Copy File 
            file.CopyTo(fs);
            //08 Return  File Name To Store In DataBase
            return fileName;
        }



        public bool Delete(string filePath)
        {
            if(!File.Exists(filePath)) return false;
            else
            {
                File.Delete(filePath);
                return true;
            }
        }

    }
}
