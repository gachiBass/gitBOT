//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;

//namespace WindowsFormsApp1
//{
//    class TeamStrengths
//    {
      
//        public List<List<string>> TeamNames;

//        int ToInt(string TextValue)
//        {
//            int Value = Convert.ToInt32(TextValue);
//            return Value;
//        }

//        string[,] GetTable(string FileName, bool ShowTable)
//        {
//            List<string> Matches = new List<string>();
//            List<string> TeamsList = new List<string>();
//            List<string> TeamNamesList = new List<string>(); //названия команд
//            StreamReader stream = new StreamReader(new FileStream(FileName, FileMode.Open));
//            string row;
//            while ((row = stream.ReadLine()) != null)
//            {
//                Matches.Add(row);
//            }
//            stream.Close(); //считали матчи в лист

//            string[] Values;
//            for (int i = 1; i < Matches.Count; i++)
//            {
//                string Text = Matches[i];
//                Values = Text.Split(new char[] { ',' });
//                TeamsList.Add(Values[2]);
//            }

//            foreach (string team in TeamsList.Distinct())
//            {
//                TeamNamesList.Add(team); //лист с наименованиями команд
//            }

//            string[,] Teams = new string[TeamNamesList.Count, 7];
//            for (int i = 0; i < TeamNamesList.Count; i++)
//            {
//                Teams[i, 0] = TeamNamesList[i]; //название команды
//                Teams[i, 1] = "0"; //забито дома
//                Teams[i, 2] = "0"; //пропущено дома
//                Teams[i, 3] = "0"; //забито в гостях
//                Teams[i, 4] = "0"; //пропущено в гостях   
//                Teams[i, 5] = "0"; //разница
//                Teams[i, 6] = "0"; //очки              
//            }

//            int HomeTeamIndex, AwayTeamIndex;
//            int HomeScored, AwayScored, HomeConceded, AwayConceded;
//            for (int i = 1; i < Matches.Count; i++)
//            {
//                string Text = Matches[i];
//                Values = Text.Split(new char[] { ',' });
//                HomeTeamIndex = Array.IndexOf(TeamNamesList.ToArray(), Values[2]);
//                AwayTeamIndex = Array.IndexOf(TeamNamesList.ToArray(), Values[3]);

//                HomeScored = ToInt(Teams[HomeTeamIndex, 1]);
//                AwayScored = ToInt(Teams[AwayTeamIndex, 3]);
//                HomeConceded = ToInt(Teams[HomeTeamIndex, 2]);
//                AwayConceded = ToInt(Teams[AwayTeamIndex, 4]);

//                HomeScored += ToInt(Values[4]);
//                HomeConceded += ToInt(Values[5]);
//                AwayScored += ToInt(Values[5]);
//                AwayConceded += ToInt(Values[4]);

//                Teams[HomeTeamIndex, 1] = HomeScored.ToString();
//                Teams[HomeTeamIndex, 2] = HomeConceded.ToString();
//                Teams[AwayTeamIndex, 3] = AwayScored.ToString();
//                Teams[AwayTeamIndex, 4] = AwayConceded.ToString();

//                switch (Values[6])
//                {
//                    case "H":
//                        {
//                            int points = ToInt(Teams[HomeTeamIndex, 6]);
//                            points += 3;
//                            Teams[HomeTeamIndex, 6] = points.ToString();
//                            break;
//                        }
//                    case "D":
//                        {
//                            int points = ToInt(Teams[HomeTeamIndex, 6]);
//                            points += 1;
//                            Teams[HomeTeamIndex, 6] = points.ToString();
//                            points = ToInt(Teams[AwayTeamIndex, 6]);
//                            points += 1;
//                            Teams[AwayTeamIndex, 6] = points.ToString();
//                            break;
//                        }
//                    case "A":
//                        {
//                            int points = ToInt(Teams[AwayTeamIndex, 6]);
//                            points += 3;
//                            Teams[AwayTeamIndex, 6] = points.ToString();
//                            break;
//                        }
//                }

//            }

//            for (int i = 0; i < TeamNamesList.Count; i++)
//            {
//                int Scored = ToInt(Teams[i, 1]) + ToInt(Teams[i, 3]);
//                int Conceded = ToInt(Teams[i, 2]) + ToInt(Teams[i, 4]);
//                int GoalDifference = Scored - Conceded;
//                Teams[i, 5] = GoalDifference.ToString(); //разница мячей
//            }

//            SortByColumnDesc(Teams, 6); //cортировка по очкам

//            for (int i = 0; i < TeamNamesList.Count - 1; i++) //меняем местами по разнице мячей,если количество очков одинаковое
//            {
//                if (ToInt(Teams[i, 6]) == ToInt(Teams[i + 1, 6]) && ToInt(Teams[i, 5]) < ToInt(Teams[i + 1, 5]))
//                {
//                    SwapRows(Teams, i, i + 1);
//                }
//            }
//            return Teams;
//        }

//        static void SortByColumnDesc(string[,] massiv, int column)
//        {
//            for (int i = 0; i < massiv.GetLength(0); i++)
//                for (int j = i + 1; j < massiv.GetLength(0); j++)
//                    if (Convert.ToDouble(massiv[i, column]) < Convert.ToDouble(massiv[j, column]))
//                        SwapRows(massiv, i, j);
//        }            
      
//        static void SwapRows(string[,] massiv, int row1, int row2)
//        {
//            for (int i = 0; i < massiv.GetLength(1); i++)
//            {
//                var tmp = massiv[row1, i];
//                massiv[row1, i] = massiv[row2, i];
//                massiv[row2, i] = tmp;
//            }
//        }
        

//        public void GetNewStrengths(int Tour)
//        {
//         //   League = 
//       //     string Season 
//            string ExcelName = GetExcelFileName(League, Season);
//            List<string> Matches = new List<string>();
//            StreamReader stream = new StreamReader(new FileStream(ExcelName, FileMode.Open));
//            string row;
//            while ((row = stream.ReadLine()) != null)
//            {
//                Matches.Add(row);
//            }
//            stream.Close();
//            for (int i = 1; i < Tour * 10; i++)
//            {
//                string Text = Matches[i];
//                string[] Values = Text.Split(new char[] { ',' });
//                AllHomeGoals += ToInt(Values[4]);
//                AllAwayGoals += ToInt(Values[5]);
//            }
//            double AVGHomeGames, AVGAwayGames;
//            AVGHomeGames = AVGAwayGames = Tour * 1.0 / 2;
//            AVGHomeGoals = AllHomeGoals / TeamCount / AVGHomeGames;
//            AVGAwayGoals = AllAwayGoals / TeamCount / AVGAwayGames;

//            for (int j = 0; j < TeamNames[0].Count; j++)
//            {
//                int HomeScored, AwayScored, HomeConceded, AwayConceded, HomeGames, AwayGames;
//                HomeScored = AwayScored = HomeConceded = AwayConceded = HomeGames = AwayGames = 0;

//                for (int i = 1; i < Tour * 10; i++)
//                {
//                    string Text = Matches[i];
//                    string[] Values = Text.Split(new char[] { ',' });
//                    if (TeamNames[0][j] == Values[2])
//                    {
//                        HomeScored += ToInt(Values[4]);
//                        HomeConceded += ToInt(Values[5]);
//                        HomeGames++;
//                    }
//                    if (TeamNames[0][j] == Values[3])
//                    {
//                        AwayScored += ToInt(Values[5]);
//                        AwayConceded += ToInt(Values[4]);
//                        AwayGames++;
//                    }

//                    TeamNames[1][j] = (HomeScored.ToString());
//                    TeamNames[2][j] = (HomeConceded.ToString());
//                    TeamNames[3][j] = (AwayScored.ToString());
//                    TeamNames[4][j] = (AwayConceded.ToString());

//                    double HomeAtt, HomeDef, AwayAtt, AwayDef;
//                    HomeAtt = HomeDef = AwayAtt = AwayDef = 0;


//                    HomeAtt = ToInt(TeamNames[1][j]) * 1.0 / HomeGames / AVGHomeGoals;
//                    HomeDef = ToInt(TeamNames[2][j]) * 1.0 / AwayGames / AVGAwayGoals;
//                    AwayAtt = ToInt(TeamNames[3][j]) * 1.0 / HomeGames / AVGAwayGoals;
//                    AwayDef = ToInt(TeamNames[4][j]) * 1.0 / AwayGames / AVGHomeGoals;

//                    TeamNames[5][j] = (HomeAtt.ToString());
//                    TeamNames[6][j] = (HomeDef.ToString());
//                    TeamNames[7][j] = (AwayAtt.ToString());
//                    TeamNames[8][j] = (AwayDef.ToString());
//                }
//            }

//        }
         

//        public void button1_Click_1(object sender, EventArgs e)
//        {


//            TeamNames = new List<List<string>>(); //вся таблица команд с параметрами
//            for (int i = 0; i < 9; i++)
//            {
//                TeamNames.Add(new List<string>());
//            }

//            string[,] HighDivTable = GetTable(ExcelName, true);

//            for (int i = 0; i < HighDivTable.GetLength(0); i++)
//            {
//                TeamNames[0].Add(HighDivTable[i, 0]);
//            }

//            AVGHomeGoals = AllHomeGoals * 1.0 / TeamCount / AllHomeGames;
//            AVGAwayGoals = AllAwayGoals * 1.0 / TeamCount / AllAwayGames;

//            textBox1.Text = AllHomeGoals.ToString(); //ВЫВОДА НЕТ 
//            textBox2.Text = AllAwayGoals.ToString();
//            textBox3.Text = AVGHomeGoals.ToString();
//            textBox4.Text = AVGAwayGoals.ToString();


//            for (int j = 0; j < TeamCount; j++) //сколько всего забито дома и в гостях
//            {
//                int HomeScored, AwayScored, HomeConceded, AwayConceded;
//                HomeScored = AwayScored = HomeConceded = AwayConceded = 0;
//                int TeamIndex = Array.IndexOf(TeamNames[0].ToArray(), TeamNames[0][j]);
//                HomeScored = ToInt(HighDivTable[TeamIndex, 1]);
//                HomeConceded = ToInt(HighDivTable[TeamIndex, 2]);
//                AwayScored = ToInt(HighDivTable[TeamIndex, 3]);
//                AwayConceded = ToInt(HighDivTable[TeamIndex, 4]);

//                TeamNames[1].Add(HomeScored.ToString());
//                TeamNames[2].Add(HomeConceded.ToString());
//                TeamNames[3].Add(AwayScored.ToString());
//                TeamNames[4].Add(AwayConceded.ToString());

//                double HomeAtt, HomeDef, AwayAtt, AwayDef;
//                HomeAtt = HomeDef = AwayAtt = AwayDef = 0;
//                HomeAtt = ToInt(TeamNames[1][j]) * 1.0 / (TeamCount - 1) / AVGHomeGoals;
//                HomeDef = ToInt(TeamNames[2][j]) * 1.0 / (TeamCount - 1) / AVGAwayGoals;
//                AwayAtt = ToInt(TeamNames[3][j]) * 1.0 / (TeamCount - 1) / AVGAwayGoals;
//                AwayDef = ToInt(TeamNames[4][j]) * 1.0 / (TeamCount - 1) / AVGHomeGoals;

//                TeamNames[5].Add(HomeAtt.ToString());
//                TeamNames[6].Add(HomeDef.ToString());
//                TeamNames[7].Add(AwayAtt.ToString());
//                TeamNames[8].Add(AwayDef.ToString());
//            }


           // получение команды вышедшей из нижнего дивизиона
            if (IsFormOpened<Matches>())
            {
                string[] Promoted = PromotedTeams(League, Season);
                TeamNames[0][17] = Promoted[0];
                TeamNames[0][18] = Promoted[1];
                TeamNames[0][19] = Promoted[2]; 3
            }

//        }


//    }


//}
