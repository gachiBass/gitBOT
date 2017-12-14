﻿using com.valgut.libs.bots.Wit;
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
        public List<string> JsonToMass(int league)
        {
            List<string> ret = new List<string>();                     
                String result;
                WebClient client = new WebClient();
                String address = @"http://api.football-data.org/v1/competitions/"+league.ToString()+"/fixtures";
                client.Headers.Add("X-Auth-Token", "54e1ad4daa9b45f6aca8da0aaf7fb801");
                result = client.DownloadString(address);
                JObject jres = JObject.Parse(result);
                var listJres = jres.SelectToken("fixtures").ToList();
                foreach (var list in listJres)
                {
                    string str = " ,";
                    DateTime d = Convert.ToDateTime(list.SelectToken("date").ToString());
                    var dd = d.Date.ToString("dd/MM/yy").Replace(".", "/");
                    str += dd.ToString() + ",";
                    str += list.SelectToken("homeTeamName").ToString() + ",";
                    str += list.SelectToken("awayTeamName").ToString() + ",";
                    str += list.SelectToken("result")["goalsHomeTeam"].ToString() + ",";
                    str += list.SelectToken("result")["goalsAwayTeam"].ToString() + ",";
                    int res1 = 0;
                    int res2 = 0;
                    if (list.SelectToken("result")["goalsHomeTeam"].ToString() != "" && list.SelectToken("result")["goalsAwayTeam"].ToString() != "")
                    {
                        res1 = Convert.ToInt32(list.SelectToken("result")["goalsHomeTeam"].ToString());
                        res2 = Convert.ToInt32(list.SelectToken("result")["goalsAwayTeam"].ToString());
                        string res = (res1 == res2) ? "D" : (res1 > res2) ? "H" : "A";
                        str += res;

                        ret.Add(str);
                    }
                
                }
            return ret;
        }
        public void CSVcreate()
        {

            int[] ligues = new int[] { 445, 450, 452, 455, 456 };
            for (int i = 0; i < 1; i++)
            {
                List<string> str = new List<string>();
                str = JsonToMass(ligues[0]);

                openFileDialog1.ShowDialog(); 
                string path = openFileDialog1.FileName;  
                //var file = System.IO.File.Open(path,FileMode.OpenOrCreate);
                //Div,Date,HomeTeam,AwayTeam,FTHG,FTAG,FTR,HTHG,HTAG,HTR,HS,AS,HST,AST,HF,AF,HC,AC,HY,AY,HR,AR,B365H,B365D,B365A,BWH,BWD,BWA,GBH,GBD,GBA,IWH,IWD,IWA,LBH,LBD,LBA,SBH,SBD,SBA,WHH,WHD,WHA,SJH,SJD,SJA,VCH,VCD,VCA,BSH,BSD,BSA,Bb1X2,BbMxH,BbAvH,BbMxD,BbAvD,BbMxA,BbAvA,BbOU,BbMx>2.5,BbAv>2.5,BbMx<2.5,BbAv<2.5,BbAH,BbAHh,BbMxAHH,BbAvAHH,BbMxAHA,BbAvAHA
                Excel.Application excel = new Excel.Application();
                Excel.Workbook wb = excel.Workbooks.Open(path);
                
                //wb = excel.Workbooks.Add();
                
                for (int index = 2; index < str.Count; index++)
                {
                    excel.Cells[index, 1].value = str[index-2];
                }
                excel.Visible = true;
                excel.ActiveWorkbook.Save();
                excel.ActiveWorkbook.Close(true);
                excel.Quit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CSVcreate();
        }
    }
}
