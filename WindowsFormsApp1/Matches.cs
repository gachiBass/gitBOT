using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApp1
{
    class Matches
    {
        private int Factorial(int x)
        {
            int result = 1;
            for (int i = 2; i <= x; ++i)
                result *= i;
            return result;
        }
        void Forecast()
        {
            //double AllHomeGoals = strengths.AllHomeGoals; //йавайцйв
            //double AllAwayGoals = strengths.AllAwayGoals;

            double HomeAdvantageValue = 1;
            double AVGHomeGoals, AVGAwayGoals;

            //AVGHomeGoals = strengths.AVGHomeGoals; //йцуйцу
            //AVGAwayGoals = strengths.AVGAwayGoals;
            //HomeAdvantageValue = strengths.HomeAdvantage;
            double HomeGoals, AwayGoals;
            HomeGoals = AwayGoals = 0;
            int HomeTeamIndex, AwayTeamIndex;

            //for (int i = 0; i < dataGridView4.RowCount; i++) //таблица будет виртуальной
            //{
            //    HomeTeamIndex = Array.IndexOf(TeamNames[0].ToArray(), dataGridView4[0, i].Value);
            //    AwayTeamIndex = Array.IndexOf(TeamNames[0].ToArray(), dataGridView4[1, i].Value);
            //    if (i > 50)
            //    {
            //        if ((i + 1) % 10 == 0)
            //        {
            //            strengths.GetNewStrengths((i + 1) / 10);
            //        }
            //    }

            //    HomeGoals = HomeAdvantageValue * ToDouble(TeamNames[5][HomeTeamIndex]) * ToDouble(TeamNames[8][AwayTeamIndex]) * AVGHomeGoals;
            //    AwayGoals = ToDouble(TeamNames[7][AwayTeamIndex]) * ToDouble(TeamNames[6][HomeTeamIndex]) * AVGAwayGoals;

            //    double[] HomeGoalsPercentage = new double[10];
            //    double[] AwayGoalsPercentage = new double[10];

            //    for (int j = 0; j < 10; j++)
            //    {
            //        HomeGoalsPercentage[j] = Math.Pow(HomeGoals, j) / (Math.Pow(Math.E, HomeGoals) * Factorial(j));
            //        AwayGoalsPercentage[j] = Math.Pow(AwayGoals, j) / (Math.Pow(Math.E, AwayGoals) * Factorial(j));
            //    }
            //    double[,] ResultMatrix = new double[10, 10];
            //    double homewin, draw, awaywin;
            //    homewin = draw = awaywin = 0;

            //    for (int x = 0; x < 10; x++)
            //        for (int y = 0; y < 10; y++)
            //        {
            //            ResultMatrix[x, y] = AwayGoalsPercentage[y] * HomeGoalsPercentage[x];
            //            if (x == y) draw += ResultMatrix[x, y];
            //            if (x > y) homewin += ResultMatrix[x, y];
            //            if (x < y) awaywin += ResultMatrix[x, y];
            //        }
            //    dataGridView4[8, i].Value = Math.Round(homewin, 5);
            //    dataGridView4[9, i].Value = Math.Round(draw, 5);
            //    dataGridView4[10, i].Value = Math.Round(awaywin, 5);
            //    string winner;
            //    if (homewin > 0.333)
            //    {
            //        if (draw > 0.333)
            //            winner = "1x";
            //        else
            //        {
            //            if (awaywin > 0.333)
            //                winner = "x";
            //            else
            //                winner = "1";
            //        }
            //    }
            //    else
            //    {
            //        if (draw > 0.333)
            //        {
            //            if (awaywin > 0.333)
            //                winner = "x2";
            //            else winner = "x";
            //        }
            //        else winner = "2";
            //    }

            //    int homegoals, awaygoals;
            //    homegoals = 0;
            //    awaygoals = 0;
            //    switch (winner)
            //    {
            //        case "1":
            //            {
            //                double max = 0;
            //                for (int x = 0; x < ResultMatrix.GetLength(0); x++)
            //                    for (int y = 0; y < ResultMatrix.GetLength(1); y++)
            //                    {
            //                        if (x > y)
            //                            if (ResultMatrix[x, y] > max)
            //                            {
            //                                max = ResultMatrix[x, y];
            //                                homegoals = x;
            //                                awaygoals = y;
            //                            }
            //                    }
            //                if (dataGridView4[5, i].Value.ToString() == "H")
            //                {
            //                    dataGridView4[6, i].Value = true;
            //                }
            //                break;
            //            }
            //        case "1x":
            //            {
            //                double max = 0;

            //                for (int x = 0; x < ResultMatrix.GetLength(0); x++)
            //                    for (int y = 0; y < ResultMatrix.GetLength(1); y++)
            //                    {
            //                        if (x >= y)
            //                            if (ResultMatrix[x, y] > max)
            //                            {
            //                                max = ResultMatrix[x, y];
            //                                homegoals = x;
            //                                awaygoals = y;
            //                            }
            //                    }
            //                if (dataGridView4[5, i].Value.ToString() != "A")
            //                {
            //                    dataGridView4[6, i].Value = true;
            //                }
            //                break;
            //            }
            //        case "12":
            //            {
            //                double max = 0;

            //                for (int x = 0; x < ResultMatrix.GetLength(0); x++)
            //                    for (int y = 0; y < ResultMatrix.GetLength(1); y++)
            //                    {
            //                        if (x == y)
            //                            if (ResultMatrix[x, y] > max)
            //                            {
            //                                max = ResultMatrix[x, y];
            //                                homegoals = x;
            //                                awaygoals = y;
            //                            }
            //                    }
            //                if (dataGridView4[5, i].Value.ToString() != "D")
            //                {
            //                    dataGridView4[6, i].Value = true;
            //                }
            //                break;
            //            }
            //        case "x":
            //            {
            //                double max = 0;

            //                for (int x = 0; x < ResultMatrix.GetLength(0); x++)
            //                    for (int y = 0; y < ResultMatrix.GetLength(1); y++)
            //                    {
            //                        if (x == y)
            //                            if (ResultMatrix[x, y] > max)
            //                            {
            //                                max = ResultMatrix[x, y];
            //                                homegoals = x;
            //                                awaygoals = y;
            //                            }
            //                    }
            //                if (dataGridView4[5, i].Value.ToString() == "D")
            //                {
            //                    dataGridView4[6, i].Value = true;
            //                }
            //                break;
            //            }
            //        case "x2":
            //            {
            //                double max = 0;

            //                for (int x = 0; x < ResultMatrix.GetLength(0); x++)
            //                    for (int y = 0; y < ResultMatrix.GetLength(1); y++)
            //                    {
            //                        if (x <= y)
            //                            if (ResultMatrix[x, y] > max)
            //                            {
            //                                max = ResultMatrix[x, y];
            //                                homegoals = x;
            //                                awaygoals = y;
            //                            }
            //                    }
            //                if (dataGridView4[5, i].Value.ToString() != "H")
            //                {
            //                    dataGridView4[6, i].Value = true;
            //                }
            //                break;
            //            }
            //        case "2":
            //            {
            //                double max = 0;

            //                for (int x = 0; x < ResultMatrix.GetLength(0); x++)
            //                    for (int y = 0; y < ResultMatrix.GetLength(1); y++)
            //                    {
            //                        if (x < y)
            //                            if (ResultMatrix[x, y] > max)
            //                            {
            //                                max = ResultMatrix[x, y];
            //                                homegoals = x;
            //                                awaygoals = y;
            //                            }
            //                    }
            //                if (dataGridView4[5, i].Value.ToString() == "A")
            //                {
            //                    dataGridView4[6, i].Value = true;
            //                }
            //                break;
            //            }
            //    }
            //    dataGridView4[3, i].Value = winner;
            //    dataGridView4[2, i].Value = homegoals.ToString() + "-" + awaygoals.ToString();
            //    if (dataGridView4[2, i].Value.ToString() == dataGridView4[4, i].Value.ToString())
            //    {
            //        dataGridView4[7, i].Value = true;
            //    }
            //}
        }
        string GetExcelFileName(string season, string league)
        {

            string EPLExcelName, SERIA_AExcelName, BundesligaExcelName, LaLigaExcelName, Ligue1ExcelName;
            EPLExcelName = SERIA_AExcelName = BundesligaExcelName = LaLigaExcelName = Ligue1ExcelName = "";
            switch (season)
            {
                case "2006/2007":
                    {
                        EPLExcelName = @"..\..\csv\EPL0607.csv";
                        SERIA_AExcelName = @"..\..\csv\SERIA_A0607.csv";
                        /*  BundesligaExcelName= @"..\..\csv\.csv";
                          LaLigaExcelName= @"..\..\csv\.csv";
                          Ligue1ExcelName= @"..\..\csv\.csv";*/
                        break;
                    }
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
            return season;
        }

        public List<List<string>> TeamNames;
        //   public Strengths strengths;

        int ToInt(string TextValue)
        {
            int Value = Convert.ToInt32(TextValue);
            return Value;
        }

        double ToDouble(string TextValue)
        {
            double Value = Convert.ToDouble(TextValue);
            return Value;
        }

        string[,] GetNewTable(bool ForecastingTable)
        {
            List<string> Matches = new List<string>();
            string match = "";
            //for (int i = 0; i < dataGridView4.RowCount; i++)
            //{
            //    if (ForecastingTable)
            //    {
            //        match = dataGridView4[0, i].Value + "-" + dataGridView4[1, i].Value + "-" + dataGridView4[2, i].Value;
            //    }
            //    else
            //    {
            //        match = dataGridView4[0, i].Value + "-" + dataGridView4[1, i].Value + "-" + dataGridView4[4, i].Value + "-" + dataGridView4[5, i].Value;
            //    }
            //    Matches.Add(match);
            //}

            List<string> TeamsList = new List<string>();
            for (int i = 1; i < Matches.Count; i++)
            {
                string Text = Matches[i];
                string[] Values = Text.Split(new char[] { '-' });
                TeamsList.Add(Values[0]);
            }
            List<string> TeamNamesList = new List<string>();
            foreach (string team in TeamsList.Distinct())
            {
                TeamNamesList.Add(team);
            }
            string[,] Teams = new string[TeamNamesList.Count, 5];
            for (int i = 0; i < TeamNamesList.Count; i++)
            {
                Teams[i, 0] = TeamNamesList[i]; //название
                Teams[i, 1] = "0";//забито
                Teams[i, 2] = "0"; //пропущено
                Teams[i, 3] = "0"; //разница
                Teams[i, 4] = "0"; //очков
            }
            int HomeTeamIndex, AwayTeamIndex;
            int HomeScored, AwayScored, HomeConceded, AwayConceded;
            for (int i = 1; i < Matches.Count; i++)
            {
                string Text = Matches[i];
                string[] Values = Text.Split(new char[] { '-' });
                HomeTeamIndex = Array.IndexOf(TeamNamesList.ToArray(), Values[0]);
                AwayTeamIndex = Array.IndexOf(TeamNamesList.ToArray(), Values[1]);
                HomeScored = ToInt(Teams[HomeTeamIndex, 1]);
                AwayScored = ToInt(Teams[AwayTeamIndex, 1]);
                HomeConceded = ToInt(Teams[HomeTeamIndex, 2]);
                AwayConceded = ToInt(Teams[AwayTeamIndex, 2]);
                HomeScored += ToInt(Values[2]);
                HomeConceded += ToInt(Values[3]);
                AwayScored += ToInt(Values[3]);
                AwayConceded += ToInt(Values[2]);
                Teams[HomeTeamIndex, 1] = HomeScored.ToString();
                Teams[HomeTeamIndex, 2] = HomeConceded.ToString();
                Teams[AwayTeamIndex, 1] = AwayScored.ToString();
                Teams[AwayTeamIndex, 2] = AwayConceded.ToString();
                string result = "";
                if (!ForecastingTable)
                {
                    result = Values[4];
                }
                else
                {
                    if (HomeScored > AwayScored)
                    {
                        result = "H";
                    }
                    if (HomeScored == AwayScored)
                    {
                        result = "D";
                    }
                    if (HomeScored < AwayScored)
                    {
                        result = "A";
                    }
                }

                switch (result)
                {
                    case "H":
                        {
                            int points = ToInt(Teams[HomeTeamIndex, 4]);
                            points += 3;
                            Teams[HomeTeamIndex, 4] = points.ToString();
                            break;
                        }
                    case "D":
                        {
                            int points = ToInt(Teams[HomeTeamIndex, 4]);
                            points += 1;
                            Teams[HomeTeamIndex, 4] = points.ToString();
                            points = ToInt(Teams[AwayTeamIndex, 4]);
                            points += 1;
                            Teams[AwayTeamIndex, 4] = points.ToString();
                            break;
                        }
                    case "A":
                        {
                            int points = ToInt(Teams[AwayTeamIndex, 4]);
                            points += 3;
                            Teams[AwayTeamIndex, 4] = points.ToString();
                            break;
                        }
                }

            }

            for (int i = 0; i < TeamNamesList.Count; i++)
            {
                int scored = ToInt(Teams[i, 1]);
                int conceded = ToInt(Teams[i, 2]);
                int difference = scored - conceded;
                Teams[i, 3] = difference.ToString();
            }

            SortByColumnDesc(Teams, 4);
            for (int i = 0; i < TeamNamesList.Count - 1; i++)
            {
                if (ToInt(Teams[i, 4]) == ToInt(Teams[i + 1, 4]) && ToInt(Teams[i, 3]) < ToInt(Teams[i + 1, 3]))
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
        public string League, Season;

        private void button2_Click(object sender, EventArgs e)
        {
            //dataGridView4.Rows.Clear();
            //Season = comboBox3.SelectedItem.ToString();
            //League = comboBox4.SelectedItem.ToString();

            ////получаем силы команд
            //strengths = new Strengths();
            //strengths.comboBox1.SelectedIndex = comboBox3.SelectedIndex;
            //strengths.comboBox2.SelectedIndex = comboBox4.SelectedIndex;
            //strengths.Show();
            //strengths.Visible = false;
            //strengths.button1_Click_1(sender, e);
            //TeamNames = strengths.TeamNames;

            //считываем матчи из файла
            string ExcelName = GetExcelFileName(Season, League);
            List<string> Matches = new List<string>();
            StreamReader stream = new StreamReader(new FileStream(ExcelName, FileMode.Open));
            string row;
            while ((row = stream.ReadLine()) != null)
            {
                Matches.Add(row);
            }
            stream.Close();

            for (int i = 1; i < Matches.Count; i++)
            {
                //dataGridView4.Rows.Add();
                //string Text = Matches[i];
                //string[] Values = Text.Split(new char[] { ',' });
                //dataGridView4[0, i - 1].Value = Values[2]; //домашняя команда
                //dataGridView4[1, i - 1].Value = Values[3]; //гостевая команда
                //dataGridView4[4, i - 1].Value = Values[4] + "-" + Values[5]; //счет
                //dataGridView4[5, i - 1].Value = Values[6]; //результат               
            }

            Forecast();

            //strengths.Close();
            //strengths = null;



            //прогнозируемая турнирная таблица
            string[,] TableForecast = GetNewTable(true);
         //   Tables ForecastTable = new Tables();
            //ForecastTable.Text = "Прогнозируемая таблица";
            //for (int i = 0; i < TeamNames[0].Count; i++)
            //{
            //    ForecastTable.OverallTable.Rows.Add();
            //    ForecastTable.OverallTable[0, i].Value = (i + 1).ToString();
            //    ForecastTable.OverallTable[1, i].Value = TableForecast[i, 0];
            //    ForecastTable.OverallTable[2, i].Value = 19;
            //    ForecastTable.OverallTable[3, i].Value = TableForecast[i, 1];
            //    ForecastTable.OverallTable[4, i].Value = TableForecast[i, 2];
            //    ForecastTable.OverallTable[5, i].Value = TableForecast[i, 3];
            //    ForecastTable.OverallTable[6, i].Value = TableForecast[i, 4];
            //}
            //ForecastTable.Show();

            ////наблюдаемая турнирная таблица
            //string[,] TableReal = GetNewTable(false);
            //Tables RealTable = new Tables();
            //RealTable.Text = "Наблюдаемая таблица";
            //for (int i = 0; i < TeamNames[0].Count; i++)
            //{
            //    RealTable.OverallTable.Rows.Add();
            //    RealTable.OverallTable[0, i].Value = (i + 1).ToString();
            //    RealTable.OverallTable[1, i].Value = TableReal[i, 0];
            //    RealTable.OverallTable[2, i].Value = 19;
            //    RealTable.OverallTable[3, i].Value = TableReal[i, 1];
            //    RealTable.OverallTable[4, i].Value = TableReal[i, 2];
            //    RealTable.OverallTable[5, i].Value = TableReal[i, 3];
            //    RealTable.OverallTable[6, i].Value = TableReal[i, 4];
            //}
            //RealTable.Show();


        }
    }
}
