// FileHandler.cs is a part of Autosys project in BDSA-2015. Created: 16, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System.IO;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

#endregion

namespace StudyConfigurationUI.Model
{
    /// <summary>
    ///     responsible for handling resource files
    /// </summary>
    public class FileHandler
    {
        /// <summary>
        ///     Read file into as string and converts it into JSON
        /// </summary>
        /// <param name="file">Path to file</param>
        /// <returns> file as a string</returns>
        public async Task<string> Parse(StorageFile file)
        {
            return await Task.Run(() =>
            {
                var fileStream = file.OpenStreamForReadAsync();
                var sb = new StringBuilder();
                using (var reader = new StreamReader(fileStream.Result))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        sb.AppendLine(line);
                    }
                }
                return sb.ToString();
            });
        }
    }
}