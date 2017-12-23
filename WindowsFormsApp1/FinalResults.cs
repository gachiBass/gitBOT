using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApp1
{
    class FinalResults
    {
        string GetExcelFileName(string League, string Season) //поиск чсв по лиге и сезону
        {
            string EPLExcelName, SERIA_AExcelName, BundesligaExcelName, LaLigaExcelName, Ligue1ExcelName;
            EPLExcelName = SERIA_AExcelName = BundesligaExcelName = LaLigaExcelName = Ligue1ExcelName = "";
            switch (Season)
            {
                case "2007/2008":
                    {
                        EPLExcelName = @"..\..\csv\EPL0708.csv";
                        SERIA_AExcelName = @"..\..\csv\SERIA_A0708.csv";
                        BundesligaExcelName = @"..\..\csv\Bundes0708.csv";
                        LaLigaExcelName = @"..\..\csv\LaLiga0708.csv";
                        Ligue1ExcelName = @"..\..\csv\Ligue10708.csv";
                        break;
                    }
                case "2008/2009":
                    {
                        EPLExcelName = @"..\..\csv\EPL0809.csv";
                        SERIA_AExcelName = @"..\..\csv\SERIA_A0809.csv";
                        BundesligaExcelName = @"..\..\csv\Bundes0809.csv";
                        LaLigaExcelName = @"..\..\csv\LaLiga0809.csv";
                        Ligue1ExcelName = @"..\..\csv\Ligue10809.csv";
                        break;
                    }
                case "2009/2010":
                    {
                        EPLExcelName = @"..\..\csv\EPL0910.csv";
                        SERIA_AExcelName = @"..\..\csv\SERIA_A0910.csv";
                        BundesligaExcelName = @"..\..\csv\Bundes0910.csv";
                        LaLigaExcelName = @"..\..\csv\LaLiga0910.csv";
                        Ligue1ExcelName = @"..\..\csv\Ligue10910csv";
                        break;
                    }
                case "2010/2011":
                    {
                        EPLExcelName = @"..\..\csv\EPL1011.csv";
                        SERIA_AExcelName = @"..\..\csv\SERIA_A1011.csv";
                        BundesligaExcelName = @"..\..\csv\Bundes1011.csv";
                        LaLigaExcelName = @"..\..\csv\LaLiga1011.csv";
                        Ligue1ExcelName = @"..\..\csv\Ligue11011.csv";
                        break;
                    }
                case "2011/2012":
                    {
                        EPLExcelName = @"..\..\csv\EPL1112.csv";
                        SERIA_AExcelName = @"..\..\csv\SERIA_A1112.csv";
                        BundesligaExcelName = @"..\..\csv\Bundes1112.csv";
                        LaLigaExcelName = @"..\..\csv\LaLiga1112.csv";
                        Ligue1ExcelName = @"..\..\csv\Ligue11112.csv";
                        break;
                    }
                case "2012/2013":
                    {
                        EPLExcelName = @"..\..\csv\EPL1213.csv";
                        SERIA_AExcelName = @"..\..\csv\SERIA_A1213.csv";
                        BundesligaExcelName = @"..\..\csv\Bundes1213.csv";
                        LaLigaExcelName = @"..\..\csv\LaLiga1213.csv";
                        Ligue1ExcelName = @"..\..\csv\Ligue11213.csv";
                        break;
                    }
                case "2013/2014":
                    {
                        EPLExcelName = @"..\..\csv\EPL1314.csv";
                        SERIA_AExcelName = @"..\..\csv\SERIA_A1314.csv";
                        BundesligaExcelName = @"..\..\csv\Bundes1314.csv";
                        LaLigaExcelName = @"..\..\csv\LaLiga1314.csv";
                        Ligue1ExcelName = @"..\..\csv\Ligue11314.csv";
                        break;
                    }
                case "2014/2015":
                    {
                        EPLExcelName = @"..\..\csv\EPL1415.csv";
                        SERIA_AExcelName = @"..\..\csv\SERIA_A1415.csv";
                        BundesligaExcelName = @"..\..\csv\Bundes1415.csv";
                        LaLigaExcelName = @"..\..\csv\LaLiga1415.csv";
                        Ligue1ExcelName = @"..\..\csv\Ligue11415.csv";
                        break;
                    }
                case "2015/2016":
                    {
                        EPLExcelName = @"..\..\csv\EPL1516.csv";
                        SERIA_AExcelName = @"..\..\csv\SERIA_A1516.csv";
                        BundesligaExcelName = @"..\..\csv\Bundes1516.csv";
                        LaLigaExcelName = @"..\..\csv\LaLiga1516.csv";
                        Ligue1ExcelName = @"..\..\csv\Ligue11516.csv";
                        break;
                    }
                case "2016/2017":
                    {
                        EPLExcelName = @"..\..\csv\EPL1617.csv";
                        SERIA_AExcelName = @"..\..\csv\SERIA_A1617.csv";
                        BundesligaExcelName = @"..\..\csv\Bundes1617.csv";
                        LaLigaExcelName = @"..\..\csv\LaLiga1617.csv";
                        Ligue1ExcelName = @"..\..\csv\Ligue11617.csv";
                        break;
                    }
                case "2017/2018":
                    {
                        EPLExcelName = @"..\..\csv\EPL1718.csv";
                        SERIA_AExcelName = @"..\..\csv\SERIA_A1718.csv";
                        BundesligaExcelName = @"..\..\csv\Bundes1718.csv";
                        LaLigaExcelName = @"..\..\csv\LaLiga1718.csv";
                        Ligue1ExcelName = @"..\..\csv\Ligue11718.csv";
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

        string[,] GetMatchResult(string ExcelName, string HomeTeam, string AwayTeam) //получение результата прошедшего матча
        {
            string[,] Result = new string[4, 2];
            Result[1, 0] = HomeTeam; Result[1, 1] = AwayTeam;
            Result[2, 0] = AwayTeam; Result[2, 1] = HomeTeam;
            List<string> Matches = new List<string>();
            List<string> TeamsList = new List<string>();
            List<string> TeamNamesList = new List<string>(); //названия команд
            StreamReader stream = new StreamReader(new FileStream(ExcelName, FileMode.Open));
            string row;
            while ((row = stream.ReadLine()) != null)
            {
                Matches.Add(row);
            }
            stream.Close();
            string[] Values;
            for (int i = 1; i < Matches.Count; i++)
            {
                string Text = Matches[i];
                Values = Text.Split(new char[] { ',' });
                if (Values[2] == HomeTeam && Values[3] == AwayTeam)
                {
                    Result[0, 0] = Values[1];
                    Result[3, 0] = Values[4] + ":" + Values[5];
                }
                if (Values[2] == AwayTeam && Values[3] == HomeTeam)
                {
                    Result[0, 1] = Values[1];
                    Result[3, 1] = Values[4] + ":" + Values[5];
                }
            }
            return Result;
        }

        int GetTeamCount(string League) //получение количества команд в лиге
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


        int ToInt(string TextValue)
        {
            int Value = Convert.ToInt32(TextValue);
            return Value;
        }


        string[] PromotedTeams(string league, string season) //раз в год
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
                        LowDivExcelName = @"..\..\csv\Bundes2.csv";
                        break;
                    }
                case "La_Liga":
                    {
                        LowDivExcelName = @"..\..\csv\Segunda.csv";
                        break;
                    }
                case "Ligue1":
                    {
                        LowDivExcelName = @"..\..\csv\Ligue2.csv";
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
        string GetStrengthFile(string league)
        {
            string StrengthFile = "";
            switch (league)
            {
                case "EPL":
                    {
                        StrengthFile = @"..\..\csv\EPL_Table.csv";
                        break;
                    }
                case "SERIA_A":
                    {
                        StrengthFile = @"..\..\csv\SERIA_A_Table.csv";
                        break;
                    }
                case "Bundes":
                    {
                        StrengthFile = @"..\..\csv\Bundes_Table.csv";
                        break;
                    }
                case "LaLiga":
                    {
                        StrengthFile = @"..\..\csv\LaLiga_Table.csv";
                        break;
                    }
                case "Ligue1":
                    {
                        StrengthFile = @"..\..\csv\Ligue1_Table.csv";
                        break;
                    }
            }
            return StrengthFile;
        }



        string[] Forecast(string HomeTeam, string AwayTeam, string StrengthFile, string League) //прогноз на матч
        {
            double HomeAtt, HomeDef, AwayAtt, AwayDef, AllHomeGoals,AllAwayGoals, HomeMatches, AwayMatches, AVGHomeGoals,AVGAwayGoals;
            int TeamCount = GetTeamCount(League);
            HomeAtt = HomeDef = AwayAtt = AwayDef = AllHomeGoals = AllAwayGoals = HomeMatches = AwayMatches = AVGHomeGoals = AVGAwayGoals = 0;
            List<string> Strengths = new List<string>();
            StreamReader stream = new StreamReader(new FileStream(StrengthFile, FileMode.Open));
            string row;
            while ((row = stream.ReadLine()) != null)
            {
                Strengths.Add(row);
            }
            stream.Close();

            string[] Values;
            for (int i = 0; i < Strengths.Count; i++)
            {
                string Text = Strengths[i];
                Values = Text.Split(new char[] { ',' });
                HomeMatches += ToInt(Values[5]);
                AwayMatches += ToInt(Values[6]);
                AllHomeGoals += ToInt(Values[1]);
                AllAwayGoals += ToInt(Values[2]);
                if (Values[0]==HomeTeam)
                {
                    HomeAtt = Convert.ToDouble(Values[7]);
                    HomeDef = Convert.ToDouble(Values[8]);
                }
                if (Values[0]==AwayTeam)
                {
                    AwayAtt = Convert.ToDouble(Values[9]);
                    AwayDef = Convert.ToDouble(Values[10]);
                }
            }
            HomeMatches /= TeamCount;
            AwayMatches /= TeamCount;       

            double HomeAdvantageValue = 1;
           

            AVGHomeGoals = AllHomeGoals/TeamCount/HomeMatches; //йцуйцу
            AVGAwayGoals =AllAwayGoals/TeamCount/AwayMatches ;
            ///////////////////////
            double HomeGoals, AwayGoals;
            HomeGoals = AwayGoals = 0;
            int HomeTeamIndex, AwayTeamIndex;

            for (int i = 0; i < dataGridView4.RowCount; i++) //таблица будет виртуальной
            {
                HomeTeamIndex = Array.IndexOf(TeamNames[0].ToArray(), dataGridView4[0, i].Value);
                AwayTeamIndex = Array.IndexOf(TeamNames[0].ToArray(), dataGridView4[1, i].Value);
                if (i > 50)
                {
                    if ((i + 1) % 10 == 0)
                    {
                        strengths.GetNewStrengths((i + 1) / 10);
                    }
                }

                HomeGoals = HomeAdvantageValue * ToDouble(TeamNames[5][HomeTeamIndex]) * ToDouble(TeamNames[8][AwayTeamIndex]) * AVGHomeGoals;
                AwayGoals = ToDouble(TeamNames[7][AwayTeamIndex]) * ToDouble(TeamNames[6][HomeTeamIndex]) * AVGAwayGoals;

                double[] HomeGoalsPercentage = new double[10];
                double[] AwayGoalsPercentage = new double[10];

                for (int j = 0; j < 10; j++)
                {
                    HomeGoalsPercentage[j] = Math.Pow(HomeGoals, j) / (Math.Pow(Math.E, HomeGoals) * Factorial(j));
                    AwayGoalsPercentage[j] = Math.Pow(AwayGoals, j) / (Math.Pow(Math.E, AwayGoals) * Factorial(j));
                }
                double[,] ResultMatrix = new double[10, 10];
                double homewin, draw, awaywin;
                homewin = draw = awaywin = 0;

                for (int x = 0; x < 10; x++)
                    for (int y = 0; y < 10; y++)
                    {
                        ResultMatrix[x, y] = AwayGoalsPercentage[y] * HomeGoalsPercentage[x];
                        if (x == y) draw += ResultMatrix[x, y];
                        if (x > y) homewin += ResultMatrix[x, y];
                        if (x < y) awaywin += ResultMatrix[x, y];
                    }
                dataGridView4[8, i].Value = Math.Round(homewin, 5);
                dataGridView4[9, i].Value = Math.Round(draw, 5);
                dataGridView4[10, i].Value = Math.Round(awaywin, 5);
                string winner;
                if (homewin > 0.333)
                {
                    if (draw > 0.333)
                        winner = "1x";
                    else
                    {
                        if (awaywin > 0.333)
                            winner = "x";
                        else
                            winner = "1";
                    }
                }
                else
                {
                    if (draw > 0.333)
                    {
                        if (awaywin > 0.333)
                            winner = "x2";
                        else winner = "x";
                    }
                    else winner = "2";
                }

                int homegoals, awaygoals;
                homegoals = 0;
                awaygoals = 0;
                switch (winner)
                {
                    case "1":
                        {
                            double max = 0;
                            for (int x = 0; x < ResultMatrix.GetLength(0); x++)
                                for (int y = 0; y < ResultMatrix.GetLength(1); y++)
                                {
                                    if (x > y)
                                        if (ResultMatrix[x, y] > max)
                                        {
                                            max = ResultMatrix[x, y];
                                            homegoals = x;
                                            awaygoals = y;
                                        }
                                }
                            if (dataGridView4[5, i].Value.ToString() == "H")
                            {
                                dataGridView4[6, i].Value = true;
                            }
                            break;
                        }
                    case "1x":
                        {
                            double max = 0;

                            for (int x = 0; x < ResultMatrix.GetLength(0); x++)
                                for (int y = 0; y < ResultMatrix.GetLength(1); y++)
                                {
                                    if (x >= y)
                                        if (ResultMatrix[x, y] > max)
                                        {
                                            max = ResultMatrix[x, y];
                                            homegoals = x;
                                            awaygoals = y;
                                        }
                                }
                            if (dataGridView4[5, i].Value.ToString() != "A")
                            {
                                dataGridView4[6, i].Value = true;
                            }
                            break;
                        }
                    case "12":
                        {
                            double max = 0;

                            for (int x = 0; x < ResultMatrix.GetLength(0); x++)
                                for (int y = 0; y < ResultMatrix.GetLength(1); y++)
                                {
                                    if (x == y)
                                        if (ResultMatrix[x, y] > max)
                                        {
                                            max = ResultMatrix[x, y];
                                            homegoals = x;
                                            awaygoals = y;
                                        }
                                }
                            if (dataGridView4[5, i].Value.ToString() != "D")
                            {
                                dataGridView4[6, i].Value = true;
                            }
                            break;
                        }
                    case "x":
                        {
                            double max = 0;

                            for (int x = 0; x < ResultMatrix.GetLength(0); x++)
                                for (int y = 0; y < ResultMatrix.GetLength(1); y++)
                                {
                                    if (x == y)
                                        if (ResultMatrix[x, y] > max)
                                        {
                                            max = ResultMatrix[x, y];
                                            homegoals = x;
                                            awaygoals = y;
                                        }
                                }
                            if (dataGridView4[5, i].Value.ToString() == "D")
                            {
                                dataGridView4[6, i].Value = true;
                            }
                            break;
                        }
                    case "x2":
                        {
                            double max = 0;

                            for (int x = 0; x < ResultMatrix.GetLength(0); x++)
                                for (int y = 0; y < ResultMatrix.GetLength(1); y++)
                                {
                                    if (x <= y)
                                        if (ResultMatrix[x, y] > max)
                                        {
                                            max = ResultMatrix[x, y];
                                            homegoals = x;
                                            awaygoals = y;
                                        }
                                }
                            if (dataGridView4[5, i].Value.ToString() != "H")
                            {
                                dataGridView4[6, i].Value = true;
                            }
                            break;
                        }
                    case "2":
                        {
                            double max = 0;

                            for (int x = 0; x < ResultMatrix.GetLength(0); x++)
                                for (int y = 0; y < ResultMatrix.GetLength(1); y++)
                                {
                                    if (x < y)
                                        if (ResultMatrix[x, y] > max)
                                        {
                                            max = ResultMatrix[x, y];
                                            homegoals = x;
                                            awaygoals = y;
                                        }
                                }
                            if (dataGridView4[5, i].Value.ToString() == "A")
                            {
                                dataGridView4[6, i].Value = true;
                            }
                            break;
                        }
                }
                dataGridView4[3, i].Value = winner;
                dataGridView4[2, i].Value = homegoals.ToString() + "-" + awaygoals.ToString();
                if (dataGridView4[2, i].Value.ToString() == dataGridView4[4, i].Value.ToString())
                {
                    dataGridView4[7, i].Value = true;
                }
            }
        }

        void Do()
        {
            //из ВИТ получаем сезон, лигу, домашнюю команду,гостевую команду
            string Season, League, HomeTeam, AwayTeam;
            //через ВИТ определяем,что нужно пользователю - результаты прошлых матчей или прогноз
            bool Past = true;
            string ExcelName = GetExcelFileName(League, Season);
            string[,] MatchResult;
            if (Past)
            {
                MatchResult = GetMatchResult(ExcelName, HomeTeam, AwayTeam); //здесь счет запрашиваемого матча
            }
            else
            {
                MatchResult = Forecast(HomeTeam, AwayTeam);
            }
        }
    }
}
