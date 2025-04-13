using AngleSharp.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YoutubeCommandExample
{
    public class DownloaderVideo : ICommand
    {
        private string urlVideo;
        private string puthVideoFile;
        private YoutubeClient youtubeClient;

        public DownloaderVideo(string UrlVideo, string PuthVideoFile) 
        {
            this.urlVideo = UrlVideo;
            this.puthVideoFile = PuthVideoFile;
            youtubeClient = new YoutubeClient();
        }
        public async Task Execute()
        {
            try
            {
                var streamManifest = await youtubeClient.Videos.Streams.GetManifestAsync(urlVideo);

                var streamInfo = streamManifest.GetVideoOnlyStreams()
                    .Where(s => s.Container == Container.Mp4)
                    .GetWithHighestVideoQuality();

                // Загрузка видео
                if (streamInfo != null)
                {
                    await youtubeClient.Videos.Streams.DownloadAsync(streamInfo, puthVideoFile);
                    Console.WriteLine($"Видео успешно загружено в: {puthVideoFile}");
                }
                else
                {
                    Console.WriteLine("Не удалось найти подходящий стрим для загрузки.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке видео: {ex.Message}");
            }
        }

    }
}
