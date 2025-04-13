using AngleSharp.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;

namespace YoutubeCommandExample
{
    public class DescriptionVideo : ICommand
    {
        private string urlVideoYoutibe;
        private YoutubeClient youtubeClient;
        private Video videoInfo;

        public DescriptionVideo(string UrlVideoYoutibe)
        {
            this.urlVideoYoutibe = UrlVideoYoutibe;
            youtubeClient = new YoutubeClient();
        }

        public async Task Execute()
        {
            try 
            {
                videoInfo = await youtubeClient.Videos.GetAsync(urlVideoYoutibe);
                Console.WriteLine("-----------------------------------\n");
                Console.WriteLine($"Название видео: {videoInfo.Title}\n");
                Console.WriteLine("-----------------------------------\n");
                Console.WriteLine($"Описание видео: {videoInfo.Description}\n");
            }
            catch
            {
                throw new NotImplementedException("URL is not Valid or youtubeClient has errors!!!");
            }
            finally
            {
                Console.WriteLine($"Command was been received. URL: {urlVideoYoutibe}");
            }
        }
    }
}
