using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.backgroundWorker1 = new BackgroundWorker();
            this.backgroundWorker1.DoWork += this.bw_DoWork;
            textBox1.Text = "490680514:AAFdle0Rk4pZOe29H9ptSUewVfizh6hkvzg";
        }

        async void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var key = e.Argument as String;
            try
            {
                var Bot = new Telegram.Bot.TelegramBotClient(key);
                await Bot.SetWebhookAsync("");
                int offset = 0;
                while (true)
                {
                    var updates = await Bot.GetUpdatesAsync(offset);

                    foreach (var update in updates)
                    {
                        var message = update.Message;
                        if (message.Type == Telegram.Bot.Types.Enums.MessageType.TextMessage)
                        {
                            if (message.Text == "/say")
                            {await Bot.SendTextMessageAsync(message.Chat.Id, "тест");}
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
                            else
                            { await Bot.SendTextMessageAsync(message.Chat.Id, "Сорри, нет такой команды"); }
                        }
                        Console.WriteLine(update.Type);
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
                if (text!=null && this.backgroundWorker1.IsBusy != true)
                {
                    this.backgroundWorker1.RunWorkerAsync(text);
                }
            }
        }
    }
}
