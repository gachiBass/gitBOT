using com.valgut.libs.bots.Wit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WitAi;
using WitAi.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {


        Wit client;
        Telegram.Bot.TelegramBotClient Bot;


        public Form1()
        {
            InitializeComponent();
            this.backgroundWorker1 = new BackgroundWorker();
            this.backgroundWorker1.DoWork += this.bw_DoWork;
            textBox1.Text = "490680514:AAFdle0Rk4pZOe29H9ptSUewVfizh6hkvzg"; /*TELEGRAM TOKEN*/
            var actions = new WitActions();
            actions["send"] = Send;
            client = new Wit(accessToken: "LJYKR53FHFUMQFDW74HRW4BYKPJ7OCIH", actions: actions); /*WIT.AI CLIENT*/        
        }
        private static WitContext Send(ConverseRequest request, ConverseResponse response)
        {
            return request.Context;
        }

        async void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var key = e.Argument as String;
            try
            {
                Bot = new Telegram.Bot.TelegramBotClient(key);
                await Bot.SetWebhookAsync("");
                int offset = 0;
                while (true)
                {
                    var updates = await Bot.GetUpdatesAsync(offset);
                    foreach (var update in updates)
                    {
                        var w = update.Type;
                        if (w == Telegram.Bot.Types.Enums.UpdateType.MessageUpdate)
                        {
                            var message = update.Message;
                            if (message != null && message.Type == Telegram.Bot.Types.Enums.MessageType.TextMessage)
                            {
                                if (message.Text == "/say")
                                { await Bot.SendTextMessageAsync(message.Chat.Id, "тест"); }
                                else if (message.Text == "/start")
                                { await Bot.SendTextMessageAsync(message.Chat.Id, "Привет!"); }
                                else if (message.Text == "/but")
                                {
                                    var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                    {
                                        Keyboard = new[]
                                        {
                                                new[]
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Red!"),
                                                    new Telegram.Bot.Types.KeyboardButton("Blue!")
                                                },
                                     },
                                        ResizeKeyboard = true,
                                    };
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Нео, что ты выберешь?", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, keyboard);
                                }
                                else if (message.Text == "Red!")
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Ты в матрице!", replyToMessageId: message.MessageId);
                                }
                                else if (message.Text == "Blue!")
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Ты даун!", replyToMessageId: message.MessageId);
                                }
                                else if (message.Text == "/but2")
                                {
                                    var keyboard = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(new[]
                                    {
                                    new[]
                                    {
                                        new Telegram.Bot.Types.InlineKeyboardButtons.InlineKeyboardCallbackButton("God","god"),
                                        new Telegram.Bot.Types.InlineKeyboardButtons.InlineKeyboardCallbackButton("Shit","shit"),
                                    },
                                 });
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Кого хочешь увидеть?", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, keyboard);
                                }
                                else if (message.Text == "/foot")
                                {
                                    try
                                    {
                                        String result;
                                        WebClient client = new WebClient();
                                        String address = @"http://api.football-data.org/v1/competitions/445/fixtures";
                                        client.Headers.Add("X-Auth-Token", "54e1ad4daa9b45f6aca8da0aaf7fb801");
                                        result = client.DownloadString(address);                      
                                        JObject jres = JObject.Parse(result);
                                        await Bot.SendTextMessageAsync(message.Chat.Id, jres.ToString());
                                    }
                                    catch (Exception e1)
                                    {
                                        await Bot.SendTextMessageAsync(message.Chat.Id, e1.ToString());
                                    }
                                }
                                else
                                {
                                    var response = client.Message(message.Text);/*message*/
                                    WitAi(message.Chat.Id,response);
                                }
                            }
                        }
                        else if (w == Telegram.Bot.Types.Enums.UpdateType.CallbackQueryUpdate)
                        {
                            var callback = update.CallbackQuery;
                            await Bot.AnswerCallbackQueryAsync(callback.Id, "You hav choosen " + callback.Data, true);
                            var picrel = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\" + callback.Data + ".png");
                            using (var stream = System.IO.File.Open(picrel, System.IO.FileMode.Open))
                            {
                                Telegram.Bot.Types.FileToSend fts = new Telegram.Bot.Types.FileToSend();
                                fts.Content = stream;
                                fts.Filename = picrel.Split('\\').Last();
                                await Bot.SendPhotoAsync(callback.Message.Chat.Id, fts);
                            }
                        }
                        offset = update.Id + 1;
                    }
                }
            }
            catch (Telegram.Bot.Exceptions.ApiRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.backgroundWorker1.IsBusy != true)
            {
                var text = textBox1.Text;
                if (text != null && this.backgroundWorker1.IsBusy != true)
                {
                    this.backgroundWorker1.RunWorkerAsync(text);
                }
            }
        }

       async void WitAi(long id,MessageResponse resp)
        {
            List<string> commands=new List<string>();
            List<string> times = new List<string>();
            double MaxSovpad=0;
            foreach (var res in resp.Entities)
            {
                if (res.Key == "time")
                {
                    var sovpadTime = res.Value.Children()["value"];
                    var time = sovpadTime.Values().ToList();
                    foreach (var e in time)
                    {
                        times.Add(e.ToString());  
                    }
                    continue;
                }
                    if (res.Key == "command")
                {
                    var sovpadCom = res.Value.Children()["value"];
                    var com = sovpadCom.Values().ToList();
                    foreach (var e in com)
                    {
                        commands.Add(e.ToString());
                    }
                    if (commands.Count != 2)
                    {
                        await Bot.SendTextMessageAsync(id, "В матче должно быть 2 команы, не?");
                    }
                    else if (commands.Count == 2)
                    {
                        await Bot.SendTextMessageAsync(id, "Результат");//МЕТОД ДЛЯ РАСЧЕТА
                    }
                }
            }              
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void CSVcreate(string[] str)
        {
            string path = openFileDialog1.ShowDialog().ToString();  
            var file = System.IO.File.Open(path,FileMode.OpenOrCreate);

            Excel.Application excel = new Excel.Application();
            Excel._Workbook wb = null;
            wb = excel.Workbooks[1];

            for (int index = 2; index < str.Length; index++)
            {
                excel.Cells[index, 1].value = str[index-2];
            }
        }
    }
}
