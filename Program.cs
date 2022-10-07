using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramTestBot
{
    class Program
    {
       

      
        static void Main(string[] args)
        {
           var Bot = new TelegramBotClient("5780791151:AAFvC6ek8PXT0LWT41kQ5UrlM7mUN2mbzBA"); ;
           Bot.StartReceiving(updateHandler, errorHandler);

            Console.ReadLine();

        }

        async static Task errorHandler(ITelegramBotClient botClient, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }

       async static Task updateHandler(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
           

            var message = update.Message;


            if (message.Text != null)
            {

                Console.WriteLine("mensaje ");
                if (message.Text.ToLower().Contains("/saludame"))
                {
                    await botClient.SendTextMessageAsync(
                         message.Chat.Id, $"Hola");
                    return;
                }
                else if (message.Text.ToLower().Contains("foto"))
                {
                    await botClient.SendTextMessageAsync(
                         message.Chat.Id,
                          "https://github.com/TelegramBots/book/raw/master/src/docs/photo-ara.jpg",
                          
                disableNotification: true,
                replyToMessageId: update.Message.MessageId,
                replyMarkup: new InlineKeyboardMarkup(
                InlineKeyboardButton.WithUrl(
                "Obtenida de",
                 "https://github.com/TelegramBots/book/raw/master/src/docs/photo-ara.jpg")));
                    return;
                }
                else 
                if (message.Text.ToLower().Contains("voz"))
                {
                    await botClient.SendVoiceAsync(
                         message.Chat.Id,
                        "https://github.com/TelegramBots/book/raw/master/src/docs/audio-guitar.mp3");
                    return;
                }
                else
                if (message.Text.ToLower().Contains("video"))
                {
                    await botClient.SendVoiceAsync(
                         message.Chat.Id,
                        "https://raw.githubusercontent.com/TelegramBots/book/master/src/docs/video-countdown.mp4");
                    return;
                }
                if (message.Text.ToLower().Contains("album"))
                {
                    await botClient.SendMediaGroupAsync(
                        message.Chat.Id,
                        media: new IAlbumInputMedia[]
                         {
        new InputMediaPhoto("https://cdn.pixabay.com/photo/2017/06/20/19/22/fuchs-2424369_640.jpg"),
        new InputMediaPhoto("https://cdn.pixabay.com/photo/2017/04/11/21/34/giraffe-2222908_640.jpg"),
                         }
                         );
                    return;
                }
                if (message.Text.ToLower().Contains("sticker"))
                {
                    await botClient.SendStickerAsync(
                         message.Chat.Id, "https://github.com/TelegramBots/book/raw/master/src/docs/sticker-fred.webp");
                    return;
                }else
                if (message.Text.ToLower().Contains("documentos"))
                {
                    await botClient.SendDocumentAsync(
                         message.Chat.Id,
                          "https://github.com/TelegramBots/book/raw/master/src/docs/photo-ara.jpg",
                           caption: "<b>Ara bird</b>. <i>Source</i>: <a href=\"https://pixabay.com\">Pixabay</a>");
                         return;
                }else
                     if (message.Text.ToLower().Contains("loc"))
                {
                    await botClient.SendLocationAsync(
                  message.Chat.Id,
                latitude: 33.747252f,
                 longitude: -112.633853f);
                    return;
                }
                else

                    await botClient.SendTextMessageAsync(
                                     message.Chat.Id, "Hola ELIGUE UNA OPCION /saludame ");
                return;
            }
            else
            if (message.Photo != null)
            {

                await botClient.SendTextMessageAsync(
                     message.Chat.Id, "Hola que bien luces");
                return;
            }

        }
    }
 }
