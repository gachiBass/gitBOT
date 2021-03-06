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
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {


        Wit client;
        Telegram.Bot.TelegramBotClient Bot;
        string[,] matchResult;

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
                // await Bot.SetWebhookAsync("");
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
                                if (message.Text == "/info")
                                { await Bot.SendTextMessageAsync(message.Chat.Id, "Бот прогнозирования матчей\nКоманда разработчиков:\nНеприенков Владимир\nОрлова Алиса\nСакаев Рустам\nСтерликов Данил\nВерсия 1.0\nг.Тюмень, 2017 год"); }
                                else if (message.Text == "/start")
                                { await Bot.SendTextMessageAsync(message.Chat.Id, "Привет!"); }
                                else if (message.Text == "/help")
                                {
                                    //var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                    //{
                                    //    Keyboard = new[]
                                    //    {
                                    //            new[]
                                    //            {
                                    //                new Telegram.Bot.Types.KeyboardButton("Red!"),
                                    //                new Telegram.Bot.Types.KeyboardButton("Blue!")
                                    //            },
                                    // },
                                    //    ResizeKeyboard = true,
                                    //};
                                    //await Bot.SendTextMessageAsync(message.Chat.Id, "Нео, что ты выберешь?", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, keyboard);
                                    await Bot.SendTextMessageAsync(message.Chat.Id,"Приветствую!\n"+
"Наш бот предназначен для прогнозирования матчей 5 ведущих чемпионатов Европы (Англия, Франция, Германия, Испания, Италия). Чтобы получить прогноз на матч, просто введите наименования двух команд, играющих в одном и том же чемпионате и бот выведет прогнозируемый счет и вероятности различных исходов матча."+
"Если команды уже играли между собой в рамках текущего сезона, причем дважды, тогда бот выведет результаты обоих сыгранных матчей. Если же введенные команды играли между собой в течение текущего сезона лишь однажды, тогда бот выведет результат сыгранного матча и прогноз на следующий.\n"+
"Наш бот, помимо прогнозирования матчей, может выводить результаты уже прошедших матчей. Для того, чтобы получить результат уже такого матча, необходимо ввести 2 команды, играющие в одном и том же чемпионате и сезон, в котором нужно искать этот матч. К примеру, если вы введете “2005”,тогда поиск будет осуществляться по сезону “2005/2006”.\n"+
"Расшифровка результатов прогноза:\n"+
"“1” - победа домашней команды\n"+
"“1х” - домашняя команда не проиграет\n"+
"“х” - ничья\n"+
"“х2” - гостевая команда не проиграет\n"+
"“2” - победа гостевой команды\n"+
"Удачного пользования!");
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
                                        //address = @"http://api.football-data.org/v1/teams/57";
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
                                    WitAi(message.Chat.Id, response);
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

        async void WitAi(long id, MessageResponse resp)
        {
            List<string> commands = new List<string>();
            List<string> times = new List<string>();
            string season = "";
            string leag = "";
            DateTime dateBegin = new DateTime(2017, 1, 1, 0, 0, 0);
            DateTime dateEnd = new DateTime(2018, 12, 31, 23, 59, 59);
            string Ans = "";
           

            double MaxSovpad = 0;
            //if (resp.Entities.ContainsKey("season") && resp.Entities.ContainsKey("Past") && (resp.Entities.ContainsKey("EPL") || resp.Entities.ContainsKey("Bindes") || resp.Entities.ContainsKey("LaLiga") || resp.Entities.ContainsKey("SERIA_A") || resp.Entities.ContainsKey("Ligue1")))
            //{ }
            foreach (var res in resp.Entities)
            {
                //if (res.Key == "time")
                //{
                //    var sovpadTime = res.Value.Children()["value"];
                //    var time = sovpadTime.Values().ToList();
                //    foreach (var e in time)
                //    {
                //        times.Add(e.ToString());
                //    }
                //    continue;
                //}
                if (res.Key == "season")
                {
                    var seasons = res.Value.Children()["value"];
                    var seas = seasons.Values().ToList();
                    foreach (var e in seas)
                    {
                        season = e.ToString();
                    }
                    dateBegin = new DateTime(Convert.ToInt32("20" + season.Substring(0, 2)), 1, 1, 0, 0, 0);
                    dateEnd = new DateTime(Convert.ToInt32("20" + season.Substring(2, 2)), 12, 31, 23, 59, 59);
                }
                else if (res.Key == "halfseason")
                {
                    var seasons = res.Value.Children()["value"];
                    var seas = seasons.Values().ToList();
                    foreach (var e in seas)
                    {
                        if (Convert.ToString(Convert.ToInt32(e) + 1).Length == 2)
                        { season = e.ToString() + Convert.ToString(Convert.ToInt32(e) + 1);}
                        else
                        { season = e.ToString() + "0"+Convert.ToString(Convert.ToInt32(e) + 1); }
                    }
                    dateBegin = new DateTime(Convert.ToInt32("20" + season.Substring(0, 2)), 1, 1, 0, 0, 0);
                    dateEnd = new DateTime(Convert.ToInt32("20" + season.Substring(2, 2)), 12, 31, 23, 59, 59);
                }

                if (res.Key == "Past")
                {
               
                }
                else if (res.Key == "Future")
                { }
                if (season == "")
                {
                    dateBegin = new DateTime(2017, 1, 1, 0, 0, 0);
                    dateEnd = new DateTime(2018, 12, 31, 23, 59, 59);
                    season = "1718";
                }
                if (res.Key == "EPL" || res.Key == "Bundes" || res.Key == "LaLiga" || res.Key == "SERIA_A" || res.Key == "Ligue1")
                {                  
                    var sovpadCom = res.Value.Children()["value"];
                    var com = sovpadCom.Values().ToList();
                    foreach (var e in com)
                    {
                        commands.Add(e.ToString());
                    }
                    if (commands.Count != 2)
                    {
                        await Bot.SendTextMessageAsync(id, "В матче должно быть 2 команды, не?");
                    }
                    else if (commands.Count == 2)
                    {
                        string filepath="";
                        FinalResults FR = new FinalResults();
                        switch (res.Key)
                        {
                            case "EPL":
                                {
                                    leag = "EPL";
                                    filepath = FR.GetStrengthFile(leag);                                  
                                    //matchResult = "Результат:";
                                    //string pathtofile = @"..\..\csv2\EPL" + season.ToString() + ".csv";
                                    //string path = System.IO.File.Open(@"..\..\csv2\EPL" + season.ToString() + ".csv", FileMode.Open).Name;
                                    //Matches( path, dateBegin, dateEnd, commands, id);

                                    //FinalResults obj = new FinalResults();
                                    //string excelName = obj.GetExcelFileName(res.Key.ToString(), season);
                                    //matchResult = obj.GetMatchResultWithDates(excelName, commands[0], commands[1], dateBegin, dateEnd);
                                    break;
                                }
                            case "Bundes":
                                {
                                    leag = "Bundes";
                                    filepath = FR.GetStrengthFile(leag);
                                    //FinalResults obj = new FinalResults();
                                    //string excelName = obj.GetExcelFileName(res.Key.ToString(), season);
                                    //matchResult = obj.GetMatchResultWithDates(excelName, commands[0], commands[1], dateBegin, dateEnd);
                                    break;
                                }
                            case "LaLiga":
                                {
                                    leag = "LaLiga";
                                    filepath = FR.GetStrengthFile(leag);
                                    //FinalResults obj = new FinalResults();
                                    //string excelName = obj.GetExcelFileName(res.Key.ToString(), season);
                                    //matchResult = obj.GetMatchResultWithDates(excelName, commands[0], commands[1], dateBegin, dateEnd);
                                    break;
                                }
                            case "SERIA_A":
                                {
                                    leag = "SERIA_A";
                                    filepath = FR.GetStrengthFile(leag);
                                    //FinalResults obj = new FinalResults();
                                    //string excelName = obj.GetExcelFileName(res.Key.ToString(), season);
                                    //matchResult = obj.GetMatchResultWithDates(excelName, commands[0], commands[1], dateBegin, dateEnd);
                                    break;
                                }
                            case "Ligue1":
                                {
                                    leag = "Ligue1";
                                    filepath = FR.GetStrengthFile(leag);
                                    //FinalResults obj = new FinalResults();
                                    //string excelName = obj.GetExcelFileName(res.Key.ToString(), season);
                                    //matchResult = obj.GetMatchResultWithDates(excelName, commands[0], commands[1], dateBegin, dateEnd);
                                    break;
                                }
                                //await Bot.SendTextMessageAsync(id, "Результат");//МЕТОД ДЛЯ РАСЧЕТА

                        }
                        string[] result = FR.Forecast(commands[0], commands[1], filepath, leag);
                        Ans = "Прогноз\nДом: " + result[0] + "\n" + "Гости: " + result[1] + "\n" + "Победа домашней: " + String.Format("{0:f4}", Convert.ToDouble(result[2])) + "\n" + "Ничья: " + String.Format("{0:f4}", Convert.ToDouble(result[3])) + "\n" + "Победа гостевой: " + String.Format("{0:f4}", Convert.ToDouble(result[4])) + "\n" + "Счет:" + result[5] + "-" + result[6] + "\n" + "Исход:" + result[7];
                    }
                }
            }

            //Выдаем результат
            FinalResults obj = new FinalResults();
            string excelName = obj.GetExcelFileName(leag, season);
            matchResult = obj.GetMatchResultWithDates(excelName, commands[0], commands[1], dateBegin, dateEnd);
            if (matchResult[0, 0] == null && matchResult[0, 1] == null)
            {
                await Bot.SendTextMessageAsync(id, Ans);
            }
            else if (matchResult[0, 0] != null && matchResult[0, 1] != null)
            {
                await Bot.SendTextMessageAsync(id, FormattedResult(matchResult));
            }
            else if (matchResult[0, 0] == null || matchResult[0, 1] == null)
            {
                await Bot.SendTextMessageAsync(id, FormattedResult(matchResult));
                await Bot.SendTextMessageAsync(id, Ans);
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
            String address = @"http://api.football-data.org/v1/competitions/" + league.ToString() + "/fixtures";
            client.Headers.Add("X-Auth-Token", "54e1ad4daa9b45f6aca8da0aaf7fb801");
            result = client.DownloadString(address);
            JObject jres = JObject.Parse(result);
            var listJres = jres.SelectToken("fixtures").ToList();
            foreach (var list in listJres)
            {
                string str = "E0,";
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
                else
                {
                    ret.Add(str);
                }

            }
            return ret;
        }
        public void CSVcreate()
        {
            //445-epl 450-ligue1 452-bundes 456-seria a 455-LaLiga
            int[] ligues = new int[] { 445, 450, 452, 455, 456 };
            for (int i = 0; i < 1; i++)
            {
                List<string> str = new List<string>();
                str = JsonToMass(ligues[4]);

                openFileDialog1.ShowDialog();
                string path = openFileDialog1.FileName;
                Excel.Application excel = new Excel.Application();
                Excel.Workbook wb = excel.Workbooks.Open(path);

                excel.Cells[1, 1].value = "Div,Date,HomeTeam,AwayTeam,FTHG,FTAG,FTR";
                for (int index = 2; index < str.Count; index++)
                {
                    excel.Cells[index, 1].value = str[index - 2];
                }
                excel.Visible = true;
                excel.ActiveWorkbook.Save();
                excel.ActiveWorkbook.Close(true);
                excel.Quit();
                Process[] list = Process.GetProcessesByName("EXCEL");
                foreach (Process proc in list)
                {
                    proc.Kill();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CSVcreate();
        }

        public string Matches(string path, DateTime d1, DateTime d2, List<string> commands, long id)
        {
            //// matchResult = "Результат:\n";
            // StreamReader stream = new StreamReader(new FileStream(@"..\..\csv\EPL0708.csv",FileMode.Open));
            // try
            // {
            //     //stream = new StreamReader(new FileStream(path, FileMode.Open));
            //     //string[] Result = new string[4];
            //     //Result[1] = HomeTeam;
            //     //Result[2] = AwayTeam;
            //     //List<string> Matches = new List<string>();
            //     //List<string> TeamsList = new List<string>();
            //     //List<string> TeamNamesList = new List<string>();

            //     //string row;
            //     //while ((row = stream.ReadLine()) != null)
            //     //{
            //     //    Matches.Add(row);
            //     //}
            //     //stream.Close();
            //     //string[] Values;
            //     //for (int i = 1; i < Matches.Count; i++)
            //     //{
            //     //    string Text = Matches[i];
            //     //    Values = Text.Split(new char[] { ',' });
            //     //    if (Values[2] == commands[0] && Values[3] == commands[1])
            //     //    {
            //     //        matchResult += Values[1] + Values[2] + ":" + Values[3] + Values[4] + ":" + Values[5];
            //     //    }
            //     //    if (Values[2] == commands[1] && Values[3] == commands[0])
            //     //    {
            //     //        matchResult += Values[1] + Values[2] + ":" + Values[3] + Values[4] + ":" + Values[5];
            //     //    }
            //     //}
            //     //return matchResult;

            //     Excel.Application excel = new Excel.Application();

            //     Excel.Workbook wb = excel.Workbooks.Open(path);
            //     int row1 = RowFindExcel(excel, commands[0].ToString(), commands[1].ToString());
            //     int row2 = RowFindExcel(excel, commands[1].ToString(), commands[0].ToString());

            //     string FsMatch = excel.Range[row1, 1].ToString();
            //     string ScMatch = excel.Range[row2, 1].ToString();
            //     excel.Visible = true;
            //     return matchResult;
            // }
            // catch(Exception e)
            // {
            //     Process[] list = Process.GetProcessesByName("EXCEL");
            //     foreach (Process proc in list)
            //     {
            //         proc.Kill();
            //     }
            //     //Process.GetCurrentProcess().Kill();
            //     matchResult = e.ToString();

            //     //stream.Close();
            //     return matchResult;
            //}
            return "s";
        }
        //return matchResult;
        public int RowFindExcel(Excel.Application excel, string firstteam, string secondteam)
        {
            Excel.Range CurrentFind = null;
            Excel.Range range = excel.get_Range("A1", "A500");
            CurrentFind = range.Find(firstteam + "," + secondteam, Type.Missing, Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart, Excel.XlSearchOrder.xlByRows,
                                     Excel.XlSearchDirection.xlNext, false, Type.Missing, Type.Missing);
            return CurrentFind.Row;
        }
        public List<string> Table(int league)
        {
            List<string> ret = new List<string>();
            String result;
            WebClient client = new WebClient();
            String address = @"http://api.football-data.org/v1/competitions/" + league.ToString() + "/leagueTable";
            client.Headers.Add("X-Auth-Token", "54e1ad4daa9b45f6aca8da0aaf7fb801");
            result = client.DownloadString(address);
            JObject jres = JObject.Parse(result);
            var listJres = jres.SelectToken("standing").ToList();
            foreach (var list in listJres)
            {
                string str = "";
                str += list.SelectToken("teamName").ToString() + ",";
                str += list.SelectToken("home")["goals"].ToString() + ",";
                str += list.SelectToken("home")["goalsAgainst"].ToString() + ",";
                str += list.SelectToken("away")["goals"].ToString() + ",";
                str += list.SelectToken("away")["goalsAgainst"].ToString() + ",";
                str += (int)list.SelectToken("home")["wins"] + (int)list.SelectToken("home")["draws"] + (int)list.SelectToken("home")["losses"] + ",";
                str+= (int)list.SelectToken("away")["wins"] + (int)list.SelectToken("away")["draws"] + (int)list.SelectToken("away")["losses"] + ",,,,,";
                str += list.SelectToken("goalDifference").ToString() + ",";
                str += list.SelectToken("points").ToString();
                ret.Add(str);
            }
            return ret;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //445-epl 450-ligue1 452-bundes 456-seria a 455-LaLiga
            int[] ligues = new int[] { 445, 450, 452, 455, 456 };
            for (int i = 0; i < 1; i++)
            {
                List<string> str = new List<string>();
                str = Table(ligues[2]);

                openFileDialog1.ShowDialog();
                string path = openFileDialog1.FileName;
                Excel.Application excel = new Excel.Application();
                Excel.Workbook wb = excel.Workbooks.Open(path);

                excel.Cells[1, 1].value = "Team,HomeScored,HomeConceded,AwayScored,AwayConceded,HomeMatches,AwayMatches,HomeAttack,HomeDefence,AwayAttack,AwayDefence,GoalDiff,Points";
                for (int index = 0; index < str.Count; index++)
                {
                    excel.Cells[index+2, 1].value = str[index];
                }
                excel.Visible = true;
                excel.ActiveWorkbook.Save();
                excel.ActiveWorkbook.Close(true);
                excel.Quit();
                Process[] list = Process.GetProcessesByName("EXCEL");
                foreach (Process proc in list)
                {
                    proc.Kill();
                }
            }
        }
        public string FormattedResult(string[,] result)
        {
            string ResultToOut = "";
            if (result[0, 0] != null)
            {
                ResultToOut = "Сыгранный матч\nДата: " + result[0, 0] + "\n" + "Дом: " + result[1, 0] + "\n" + "Гости: " + result[2, 0] + "\n" + "Счет: " + result[3, 0] + "\n\n";
            }
            if (result[0, 1] != null)
            { 
                ResultToOut += "Сыгранный матч\nДата: " + result[0, 1] + "\n" + "Дом: " + result[1, 1] + "\n" + "Гости: " + result[2, 1] + "\n" + "Счет: " + result[3, 1] + "\n\n";
            }
            return ResultToOut;
        }
    }
}

//    var time = res.Value.Children()["value"];
//    var dates = time.Values().ToList();
//    foreach (var e in dates)
//    {
//        var f = 0;
//        switch (e.ToString())
//        {
//            case "вчера":
//                {
//                    dateBegin = DateTime.Today.AddDays(-1);
//                    dateEnd = DateTime.Today.AddSeconds(-1);
//                    //  dateBegin.AddHours
//                    break;
//                }
//            case "В прошлом месяце":
//                {
//                    var yr = DateTime.Today.Year;
//                    var mth = DateTime.Today.Month;
//                    dateBegin = new DateTime(yr, mth, 1, 0, 0, 0).AddMonths(-1);
//                    dateEnd = new DateTime(yr, mth, 1, 23, 59, 59).AddDays(-1);
//                    break;
//                }
//            case "В прошлом году":
//                {
//                    var yr = DateTime.Today.Year;
//                    dateBegin = new DateTime(yr, 1, 1, 0, 0, 0).AddYears(-1);
//                    dateEnd = new DateTime(yr, 12, 31, 23, 59, 59).AddYears(-1);
//                    break;
//                }
//            case "на прошлой неделе":
//                {
//                    var day = DateTime.Today.DayOfWeek.ToString();
//                    switch (day)
//                    {
//                        case "Monday":
//                            {
//                                dateBegin = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0).AddDays(-7);
//                                dateEnd = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59).AddDays(-1);
//                                break;
//                            }
//                        case "Tuesday":
//                            {
//                                dateBegin = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0).AddDays(-8);
//                                dateEnd = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59).AddDays(-2);
//                                break;
//                            }
//                        case "Wednsday":
//                            {
//                                dateBegin = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0).AddDays(-9);
//                                dateEnd = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59).AddDays(-3);
//                                break;
//                            }
//                        case "Thursday":
//                            {
//                                dateBegin = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0).AddDays(-10);
//                                dateEnd = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59).AddDays(-4);
//                                break;
//                            }
//                        case "Friday":
//                            {
//                                dateBegin = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0).AddDays(-11);
//                                dateEnd = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59).AddDays(-5);
//                                break;
//                            }
//                        case "Saturday":
//                            {
//                                dateBegin = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0).AddDays(-12);
//                                dateEnd = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59).AddDays(-6);
//                                break;
//                            }
//                        case "Sunday":
//                            {
//                                dateBegin = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0).AddDays(-13);
//                                dateEnd = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59).AddDays(-7);
//                                break;
//                            }
//                    }
//                    break;
//                }
//}
//}