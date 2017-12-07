using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApp1
{
    class TeamStrengths
    {
        string GetExcelFileName(string League, string Season)
        {
            string EPLExcelName, SERIA_AExcelName, BundesligaExcelName, LaLigaExcelName, Ligue1ExcelName;
            EPLExcelName = SERIA_AExcelName = BundesligaExcelName = LaLigaExcelName = Ligue1ExcelName = "";
            switch (Season)
            {
                case "2007/2008":
                    {
                        EPLExcelName = @"..\..\csv\EPL0708.csv";
                        SERIA_AExcelName = @"..\..\csv\SERIA_A0708.csv";
                        /*  BundesligaExcelName= @"..\..\csv\.csv";
                      LaLigaExcelName= @"..\..\csv\.csv";
                      Ligue1ExcelName= @"..\..\csv\.csv";*/
                        break;
                    }
                case "2008/2009":
                    {
                        EPLExcelName = @"..\..\csv\EPL0809.csv";
                        SERIA_AExcelName = @"..\..\csv\SERIA_A0809.csv";
                        /*  BundesligaExcelName= @"..\..\csv\.csv";
                      LaLigaExcelName= @"..\..\csv\.csv";
                      Ligue1ExcelName= @"..\..\csv\.csv";*/
                        break;
                    }
                case "2009/2010":
                    {
                        EPLExcelName = @"..\..\csv\EPL0910.csv";
                        SERIA_AExcelName = @"..\..\csv\SERIA_A0910.csv";
                        /*  BundesligaExcelName= @"..\..\csv\.csv";
                      LaLigaExcelName= @"..\..\csv\.csv";
                      Ligue1ExcelName= @"..\..\csv\.csv";*/
                        break;
                    }
                case "2010/2011":
                    {
                        EPLExcelName = @"..\..\csv\EPL1011.csv";
                        SERIA_AExcelName = @"..\..\csv\SERIA_A1011.csv";
                        /*  BundesligaExcelName= @"..\..\csv\.csv";
                      LaLigaExcelName= @"..\..\csv\.csv";
                      Ligue1ExcelName= @"..\..\csv\.csv";*/
                        break;
                    }
                case "2011/2012":
                    {
                        EPLExcelName = @"..\..\csv\EPL1112.csv";
                        SERIA_AExcelName = @"..\..\csv\SERIA_A1112.csv";
                        /*  BundesligaExcelName= @"..\..\csv\.csv";
                      LaLigaExcelName= @"..\..\csv\.csv";
                      Ligue1ExcelName= @"..\..\csv\.csv";*/
                        break;
                    }
                case "2012/2013":
                    {
                        EPLExcelName = @"..\..\csv\EPL1213.csv";
                        SERIA_AExcelName = @"..\..\csv\SERIA_A1213.csv";
                        /*  BundesligaExcelName= @"..\..\csv\.csv";
                      LaLigaExcelName= @"..\..\csv\.csv";
                      Ligue1ExcelName= @"..\..\csv\.csv";*/
                        break;
                    }
                case "2013/2014":
                    {
                        EPLExcelName = @"..\..\csv\EPL1314.csv";
                        SERIA_AExcelName = @"..\..\csv\SERIA_A1314.csv";
                        /*  BundesligaExcelName= @"..\..\csv\.csv";
                      LaLigaExcelName= @"..\..\csv\.csv";
                      Ligue1ExcelName= @"..\..\csv\.csv";*/
                        break;
                    }
                case "2014/2015":
                    {
                        EPLExcelName = @"..\..\csv\EPL1415.csv";
                        SERIA_AExcelName = @"..\..\csv\SERIA_A1415.csv";
                        /*  BundesligaExcelName= @"..\..\csv\.csv";
                      LaLigaExcelName= @"..\..\csv\.csv";
                      Ligue1ExcelName= @"..\..\csv\.csv";*/
                        break;
                    }
                case "2015/2016":
                    {
                        EPLExcelName = @"..\..\csv\EPL1516.csv";
                        SERIA_AExcelName = @"..\..\csv\SERIA_A1516.csv";
                        /*  BundesligaExcelName= @"..\..\csv\.csv";
                      LaLigaExcelName= @"..\..\csv\.csv";
                      Ligue1ExcelName= @"..\..\csv\.csv";*/
                        break;
                    }
                case "2016/2017":
                    {
                        EPLExcelName = @"..\..\csv\EPL1617.csv";
                        SERIA_AExcelName = @"..\..\csv\SERIA_A1617.csv";
                        /*  BundesligaExcelName= @"..\..\csv\.csv";
                      LaLigaExcelName= @"..\..\csv\.csv";
                      Ligue1ExcelName= @"..\..\csv\.csv";*/
                        break;
                    }
            }
            switch (League)
            {
                case "EPL":
                    {
                        return EPLExcelName;
                    }

                case "Seria_A":
                    {
                        return SERIA_AExcelName;
                    }
                case "BundesLiga":
                    {
                        return BundesligaExcelName;
                    }
                case "LaLiga":
                    {
                        return LaLigaExcelName;
                    }
                case "Ligue1":
                    {
                        return Ligue1ExcelName;
                    }

            }
            return Season;
        }

        public List<List<string>> TeamNames;

        int ToInt(string TextValue)
        {
            int Value = Convert.ToInt32(TextValue);
            return Value;
        }

        public double AVGHomeGoals, AVGAwayGoals;
        string[,] GetTable(string FileName, bool ShowTable)
        {
            List<string> Matches = new List<string>();
            List<string> TeamsList = new List<string>();
            List<string> TeamNamesList = new List<string>(); //названия команд
            StreamReader stream = new StreamReader(new FileStream(FileName, FileMode.Open));
            string row;
            while ((row = stream.ReadLine()) != null)
            {
                Matches.Add(row);
            }
            stream.Close(); //считали матчи в лист

            string[] Values;
            for (int i = 1; i < Matches.Count; i++)
            {
                string Text = Matches[i];
                Values = Text.Split(new char[] { ',' });
                TeamsList.Add(Values[2]);
            }

            foreach (string team in TeamsList.Distinct())
            {
                TeamNamesList.Add(team); //лист с наименованиями команд
            }

            string[,] Teams = new string[TeamNamesList.Count, 7];
            for (int i = 0; i < TeamNamesList.Count; i++)
            {
                Teams[i, 0] = TeamNamesList[i]; //название команды
                Teams[i, 1] = "0"; //забито дома
                Teams[i, 2] = "0"; //пропущено дома
                Teams[i, 3] = "0"; //забито в гостях
                Teams[i, 4] = "0"; //пропущено в гостях   
                Teams[i, 5] = "0"; //разница
                Teams[i, 6] = "0"; //очки              
            }

            int HomeTeamIndex, AwayTeamIndex;
            int HomeScored, AwayScored, HomeConceded, AwayConceded;
            for (int i = 1; i < Matches.Count; i++)
            {
                string Text = Matches[i];
                Values = Text.Split(new char[] { ',' });
                HomeTeamIndex = Array.IndexOf(TeamNamesList.ToArray(), Values[2]);
                AwayTeamIndex = Array.IndexOf(TeamNamesList.ToArray(), Values[3]);

                HomeScored = ToInt(Teams[HomeTeamIndex, 1]);
                AwayScored = ToInt(Teams[AwayTeamIndex, 3]);
                HomeConceded = ToInt(Teams[HomeTeamIndex, 2]);
                AwayConceded = ToInt(Teams[AwayTeamIndex, 4]);

                HomeScored += ToInt(Values[4]);
                HomeConceded += ToInt(Values[5]);
                AwayScored += ToInt(Values[5]);
                AwayConceded += ToInt(Values[4]);

                Teams[HomeTeamIndex, 1] = HomeScored.ToString();
                Teams[HomeTeamIndex, 2] = HomeConceded.ToString();
                Teams[AwayTeamIndex, 3] = AwayScored.ToString();
                Teams[AwayTeamIndex, 4] = AwayConceded.ToString();

                switch (Values[6])
                {
                    case "H":
                        {
                            int points = ToInt(Teams[HomeTeamIndex, 6]);
                            points += 3;
                            Teams[HomeTeamIndex, 6] = points.ToString();
                            break;
                        }
                    case "D":
                        {
                            int points = ToInt(Teams[HomeTeamIndex, 6]);
                            points += 1;
                            Teams[HomeTeamIndex, 6] = points.ToString();
                            points = ToInt(Teams[AwayTeamIndex, 6]);
                            points += 1;
                            Teams[AwayTeamIndex, 6] = points.ToString();
                            break;
                        }
                    case "A":
                        {
                            int points = ToInt(Teams[AwayTeamIndex, 6]);
                            points += 3;
                            Teams[AwayTeamIndex, 6] = points.ToString();
                            break;
                        }
                }

            }

            for (int i = 0; i < TeamNamesList.Count; i++)
            {
                int Scored = ToInt(Teams[i, 1]) + ToInt(Teams[i, 3]);
                int Conceded = ToInt(Teams[i, 2]) + ToInt(Teams[i, 4]);
                int GoalDifference = Scored - Conceded;
                Teams[i, 5] = GoalDifference.ToString(); //разница мячей
            }

            SortByColumnDesc(Teams, 6); //cортировка по очкам

            for (int i = 0; i < TeamNamesList.Count - 1; i++) //меняем местами по разнице мячей,если количество очков одинаковое
            {
                if (ToInt(Teams[i, 6]) == ToInt(Teams[i + 1, 6]) && ToInt(Teams[i, 5]) < ToInt(Teams[i + 1, 5]))
                {
                    SwapRows(Teams, i, i + 1);
                }
            }
            return Teams;
        }

        static void SortByColumnDesc(string[,] massiv, int column)
        {
            for (int i = 0; i < massiv.GetLength(0); i++)
                for (int j = i + 1; j < massiv.GetLength(0); j++)
                    if (Convert.ToDouble(massiv[i, column]) < Convert.ToDouble(massiv[j, column]))
                        SwapRows(massiv, i, j);
        }
               

        static void SwapRows(string[,] massiv, int row1, int row2)
        {
            for (int i = 0; i < massiv.GetLength(1); i++)
            {
                var tmp = massiv[row1, i];
                massiv[row1, i] = massiv[row2, i];
                massiv[row2, i] = tmp;
            }
        }
        public int AllHomeGoals, AllAwayGoals;
        public string League, Season;
        public string PromotedTeam;

        public void GetNewStrengths(int Tour)
        {
         //   League = comboBox2.SelectedItem.ToString(); лигу определяем до сообщению пользователя
       //     string Season = comboBox1.Items[comboBox1.SelectedIndex + 1].ToString(); //сезон тоже по сообщению
            string ExcelName = GetExcelFileName(League, Season);
            List<string> Matches = new List<string>();
            StreamReader stream = new StreamReader(new FileStream(ExcelName, FileMode.Open));
            string row;
            while ((row = stream.ReadLine()) != null)
            {
                Matches.Add(row);
            }
            stream.Close();
            for (int i = 1; i < Tour * 10; i++)
            {
                string Text = Matches[i];
                string[] Values = Text.Split(new char[] { ',' });
                AllHomeGoals += ToInt(Values[4]);
                AllAwayGoals += ToInt(Values[5]);
            }
            double AVGHomeGames, AVGAwayGames;
            AVGHomeGames = AVGAwayGames = Tour * 1.0 / 2;
            AVGHomeGoals = AllHomeGoals / TeamCount / AVGHomeGames;
            AVGAwayGoals = AllAwayGoals / TeamCount / AVGAwayGames;

            for (int j = 0; j < TeamNames[0].Count; j++)
            {
                int HomeScored, AwayScored, HomeConceded, AwayConceded, HomeGames, AwayGames;
                HomeScored = AwayScored = HomeConceded = AwayConceded = HomeGames = AwayGames = 0;

                for (int i = 1; i < Tour * 10; i++)
                {
                    string Text = Matches[i];
                    string[] Values = Text.Split(new char[] { ',' });
                    if (TeamNames[0][j] == Values[2])
                    {
                        HomeScored += ToInt(Values[4]);
                        HomeConceded += ToInt(Values[5]);
                        HomeGames++;
                    }
                    if (TeamNames[0][j] == Values[3])
                    {
                        AwayScored += ToInt(Values[5]);
                        AwayConceded += ToInt(Values[4]);
                        AwayGames++;
                    }

                    TeamNames[1][j] = (HomeScored.ToString());
                    TeamNames[2][j] = (HomeConceded.ToString());
                    TeamNames[3][j] = (AwayScored.ToString());
                    TeamNames[4][j] = (AwayConceded.ToString());

                    double HomeAtt, HomeDef, AwayAtt, AwayDef;
                    HomeAtt = HomeDef = AwayAtt = AwayDef = 0;


                    HomeAtt = ToInt(TeamNames[1][j]) * 1.0 / HomeGames / AVGHomeGoals;
                    HomeDef = ToInt(TeamNames[2][j]) * 1.0 / AwayGames / AVGAwayGoals;
                    AwayAtt = ToInt(TeamNames[3][j]) * 1.0 / HomeGames / AVGAwayGoals;
                    AwayDef = ToInt(TeamNames[4][j]) * 1.0 / AwayGames / AVGHomeGoals;

                    TeamNames[5][j] = (HomeAtt.ToString());
                    TeamNames[6][j] = (HomeDef.ToString());
                    TeamNames[7][j] = (AwayAtt.ToString());
                    TeamNames[8][j] = (AwayDef.ToString());
                }
            }

        }

        string[] PromotedTeams(string league, string season)
        {
            string LowDivExcelName = "";
            string[] Promoted = new string[3];
            switch (League)
            {
                case "EPL":
                    {
                        LowDivExcelName = @"..\..\csv\SHIP.csv";
                        break;
                    }
                case "Seria_A":
                    {
                        LowDivExcelName = @"..\..\csv\Seria_B.csv";
                        break;
                    }
                case "Bundesliga":
                    {
                        //   LowDivExcelName = @"..\..\csv\.csv";
                        break;
                    }
                case "La_Liga":
                    {
                        // LowDivExcelName = @"..\..\csv\.csv";
                        break;
                    }
                case "Ligue1":
                    {
                        // LowDivExcelName = @"..\..\csv\.csv";
                        break;
                    }
            }
            List<string> Seasons = new List<string>();
            StreamReader stream = new StreamReader(new FileStream(LowDivExcelName, FileMode.Open));
            string row;
            while ((row = stream.ReadLine()) != null)
            {
                Seasons.Add(row);
            }
            stream.Close(); //считали матчи в лист

            string[] Values;
            for (int i = 0; i < Seasons.Count; i++)
            {
                string Text = Seasons[i];
                Values = Text.Split(new char[] { ',' });
                if (Values[0] == season)
                {
                    Promoted[0] = Values[1];
                    Promoted[1] = Values[2];
                    Promoted[2] = Values[3];
                }
            }
            return Promoted;
        }

        int GetTeamCount(string League)
        {
            List<string> LeaguesWithCount = new List<string>();
            string[] LeagueArrayName = new string[5];
            string[] LeagueArrayCount = new string[5];
            string FileName = @"..\..\csv\TeamCount.csv";
            StreamReader stream = new StreamReader(new FileStream(FileName, FileMode.Open));
            string row;
            while ((row = stream.ReadLine()) != null)
            {
                LeaguesWithCount.Add(row);
            }
            stream.Close();

            string[] Values;
            for (int i = 0; i < LeaguesWithCount.Count; i++)
            {
                string Text = LeaguesWithCount[i];
                Values = Text.Split(new char[] { ',' });
                LeagueArrayName[i] = Values[0];
                LeagueArrayCount[i] = Values[1];
            }
            int LeagueIndex = Array.IndexOf(LeagueArrayName, League);
            int TeamCount = ToInt(LeagueArrayCount[LeagueIndex]);
            return TeamCount;
        }
        int TeamCount;
        public double HomeAdvantage;

        public void button1_Click_1(object sender, EventArgs e)
        {
          //  League = comboBox2.SelectedItem.ToString(); //НА ВХОД БУДУТ ПО-ДРУГОМУ ПРИХОДИТЬ
          //  Season = comboBox1.SelectedItem.ToString();
          //  TeamsTable.Rows.Clear();
        //    StrengthTable.Rows.Clear();
            string ExcelName = GetExcelFileName(League, Season); //узнали из какой чсвшки брать инфу
            TeamCount = GetTeamCount(League);

            int AllHomeGames, AllAwayGames;
            AllHomeGames = AllAwayGames = TeamCount - 1;

            List<string> Matches = new List<string>();

            StreamReader stream = new StreamReader(new FileStream(ExcelName, FileMode.Open));
            string row;
            while ((row = stream.ReadLine()) != null)
            {
                Matches.Add(row);
            }
            stream.Close();

            AllAwayGoals = AllHomeGoals = 0;
            for (int i = 1; i < Matches.Count; i++)
            {
                string Text = Matches[i];
                string[] Values = Text.Split(new char[] { ',' });
                AllHomeGoals += ToInt(Values[4]); //всего забито дома
                AllAwayGoals += ToInt(Values[5]); //всего забито в гостях                                  
            }
            HomeAdvantage = AllHomeGoals * 1.0 / AllAwayGoals;
            TeamNames = new List<List<string>>(); //вся таблица команд с параметрами
            for (int i = 0; i < 9; i++)
            {
                TeamNames.Add(new List<string>());
            }

            string[,] HighDivTable = GetTable(ExcelName, true);

            for (int i = 0; i < HighDivTable.GetLength(0); i++)
            {
                TeamNames[0].Add(HighDivTable[i, 0]);
            }

            AVGHomeGoals = AllHomeGoals * 1.0 / TeamCount / AllHomeGames;
            AVGAwayGoals = AllAwayGoals * 1.0 / TeamCount / AllAwayGames;

            //textBox1.Text = AllHomeGoals.ToString(); //ВЫВОДА НЕТ 
            //textBox2.Text = AllAwayGoals.ToString();
            //textBox3.Text = AVGHomeGoals.ToString();
            //textBox4.Text = AVGAwayGoals.ToString();


            for (int j = 0; j < TeamCount; j++) //сколько всего забито дома и в гостях
            {
                int HomeScored, AwayScored, HomeConceded, AwayConceded;
                HomeScored = AwayScored = HomeConceded = AwayConceded = 0;
                int TeamIndex = Array.IndexOf(TeamNames[0].ToArray(), TeamNames[0][j]);
                HomeScored = ToInt(HighDivTable[TeamIndex, 1]);
                HomeConceded = ToInt(HighDivTable[TeamIndex, 2]);
                AwayScored = ToInt(HighDivTable[TeamIndex, 3]);
                AwayConceded = ToInt(HighDivTable[TeamIndex, 4]);

                TeamNames[1].Add(HomeScored.ToString());
                TeamNames[2].Add(HomeConceded.ToString());
                TeamNames[3].Add(AwayScored.ToString());
                TeamNames[4].Add(AwayConceded.ToString());

                double HomeAtt, HomeDef, AwayAtt, AwayDef;
                HomeAtt = HomeDef = AwayAtt = AwayDef = 0;
                HomeAtt = ToInt(TeamNames[1][j]) * 1.0 / (TeamCount - 1) / AVGHomeGoals;
                HomeDef = ToInt(TeamNames[2][j]) * 1.0 / (TeamCount - 1) / AVGAwayGoals;
                AwayAtt = ToInt(TeamNames[3][j]) * 1.0 / (TeamCount - 1) / AVGAwayGoals;
                AwayDef = ToInt(TeamNames[4][j]) * 1.0 / (TeamCount - 1) / AVGHomeGoals;

                TeamNames[5].Add(HomeAtt.ToString());
                TeamNames[6].Add(HomeDef.ToString());
                TeamNames[7].Add(AwayAtt.ToString());
                TeamNames[8].Add(AwayDef.ToString());
            }


            //получение команды вышедшей из плейофф // занести эти команды в чсв и вытягивать их оттуда
            //if (IsFormOpened<Matches>())
            //{
            //    string[] Promoted = PromotedTeams(League, Season);
            //    TeamNames[0][17] = Promoted[0];
            //    TeamNames[0][18] = Promoted[1];
            //    TeamNames[0][19] = Promoted[2];
            //}

            //ВЫВОДА НЕТ
            //for (int j = 0; j < TeamCount; j++)
            //{
            //    TeamsTable.Rows.Add();
            //    StrengthTable.Rows.Add();
            //    TeamsTable[0, j].Value = TeamNames[0][j];
            //    StrengthTable[0, j].Value = TeamNames[0][j];
            //    TeamsTable[1, j].Value = TeamNames[1][j];
            //    TeamsTable[2, j].Value = TeamNames[2][j];
            //    TeamsTable[3, j].Value = TeamNames[3][j];
            //    TeamsTable[4, j].Value = TeamNames[4][j];
            //    StrengthTable[1, j].Value = TeamNames[5][j];
            //    StrengthTable[2, j].Value = TeamNames[6][j];
            //    StrengthTable[3, j].Value = TeamNames[7][j];
            //    StrengthTable[4, j].Value = TeamNames[8][j];
            //}
        }


    }


}
