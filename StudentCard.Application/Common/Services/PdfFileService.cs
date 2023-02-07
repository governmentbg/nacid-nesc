using HandlebarsDotNet;
using PuppeteerSharp;
using StudentCard.Application.Common.Interfaces;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace StudentCard.Application.Common.Services
{
    public class PdfFileService : IPdfFileService
    {
        public async Task<byte[]> GeneratePdfFile<T>(T payload, byte[] content, bool closeStream = true)
        {
            var outputStream = new MemoryStream();
            string template = Encoding.UTF8.GetString(content, 0, content.Length);
            var templateFunc = Handlebars.Compile(template);

            var fileContent = templateFunc.Invoke(payload);
            await this.Convert(fileContent, outputStream, "\\StudentCard-chromium");

            if (closeStream)
            {
                outputStream.Close();
                outputStream.Dispose();
            }

            return outputStream.ToArray();
        }

        private async Task<byte[]> Convert(string content, Stream outputStream, string browserFetcherPath)
        {
            var browserFetcher = new BrowserFetcher(new BrowserFetcherOptions
            {
                Path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + browserFetcherPath
            });

            await browserFetcher.DownloadAsync(BrowserFetcher.DefaultRevision);

            using (var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,
                ExecutablePath = browserFetcher.RevisionInfo(BrowserFetcher.DefaultRevision).ExecutablePath
            }))
            {
                var page = await browser.NewPageAsync();
                await page.SetContentAsync(content);

                var pdfStream = await page.PdfDataAsync(new PdfOptions()
                {
                    Format = new PuppeteerSharp.Media.PaperFormat(3m, 1.9583m),
                    
                });
                await outputStream.WriteAsync(pdfStream);
                return pdfStream;
            }
        }
    }
}
