// FileHandler.cs is a part of Autosys project in BDSA-2015. Created: 15, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace StudyConfigurationUI.Model
{
    /// <summary>
    /// responsible for handling resource files
    /// </summary>
    public class FileHandler
    {
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