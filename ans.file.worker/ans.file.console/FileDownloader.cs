using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ans.file.console
{
    internal class FileDownloader
    {
        private HttpClient httpClient;
        private ConcurrentDictionary<string, byte[]> fileCache;

        public FileDownloader()
        {
            httpClient = new HttpClient();
            fileCache = new ConcurrentDictionary<string, byte[]>();
        }

        public async Task<byte[]?> DownloadFileAsync(string url)
        {
            if (fileCache.TryGetValue(url, out byte[]? cachedFile))
            {
                return cachedFile;
            }

            try
            {
                byte[] fileBytes = await httpClient.GetByteArrayAsync(url);
                fileCache.TryAdd(url, fileBytes);
                return fileBytes;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Error al descargar el archivo: " + ex.Message);
                return null;
            }
        }
    }
}
