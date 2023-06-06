using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TibaSchool.BL.Helper
{
    public class FileUploader
    {
        public static string UploadFile(string folderName, IFormFile file)
        {
			try
			{
				string FolderPath = Directory.GetCurrentDirectory() + "/wwwroot/Files/" + folderName;
				string FileName = Path.GetFileName(file.FileName);
				string FinalPath = Path.Combine(FolderPath, FileName);

				using (var stream = new FileStream(FinalPath, FileMode.Create))
				{
					file.CopyTo(stream);
				} 

				return FileName;
			}
			catch (Exception ex)
			{

				return ex.Message;
			}
        }

    }
}
