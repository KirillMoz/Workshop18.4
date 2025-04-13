using YoutubeCommandExample;

//const string UrlVideo = "https://www.youtube.com/shorts/X3u9EQ2snqo";
//const string outputFilePath = "\\bin\\Debug\\net8.0";


Console.WriteLine("Введите ссылку на видео: ");

string UrlVideo = Console.ReadLine();
Command invoker = new Command();

// создадим команду
DescriptionVideo commandDescriptionVideo = new DescriptionVideo(UrlVideo);
await invoker.ExecuteCommand(commandDescriptionVideo);

Console.WriteLine("Куда сохранить файл: ");
string OutputFilePath = Console.ReadLine();

DownloaderVideo downloadVideoCommand = new DownloaderVideo(UrlVideo, OutputFilePath);
await invoker.ExecuteCommand(downloadVideoCommand);