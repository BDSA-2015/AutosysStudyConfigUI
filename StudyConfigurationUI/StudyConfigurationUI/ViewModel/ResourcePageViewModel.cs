using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace StudyConfigurationUI.ViewModel
{
    internal class ResourcePageViewModel
    {

        /// <summary>
        /// Uploads a given file to database
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>Bool if sucessfull</returns>
        public async Task<bool> UploadFileToDatabase(string filePath)
        {
            if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
            {
                var file = await ReadTextAsync(filePath);
                //TODO UPLOAD FILE TO DATABASE
                return true;
            }
            return false;

        }


        /// <summary>
        /// Read file into as string. This was taken from 
        /// <code>https://msdn.microsoft.com/library/jj155757.aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-4 <code/>
        /// </summary>
        /// <param name="filePath">Path to file</param>
        /// <returns> file as a string</returns>
        private async Task<string> ReadTextAsync(string filePath)
        {
            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Open, FileAccess.Read, FileShare.Read,
                bufferSize: 4096, useAsync: true))
            {
                var sb = new StringBuilder();

                byte[] buffer = new byte[0x1000];
                int numRead;
                while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string text = Encoding.Unicode.GetString(buffer, 0, numRead);
                    sb.Append(text);
                }

                return sb.ToString();
            }

        }
    }
}
