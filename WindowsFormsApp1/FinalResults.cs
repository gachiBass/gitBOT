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

        string[] GetMatchResult(string ExcelName, string HomeTeam, string AwayTeam) //получение результата прошедшего матча
        {
            string[] Result = new string[4];
            Result[1] = HomeTeam;
            Result[2] = AwayTeam;
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
                    Result[0] = Values[1];
                    Result[3] = Values[4] + ":" + Values[5];
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

        void Do()
        {
            //из ВИТ получаем сезон, лигу, домашнюю команду,гостевую команду
            string Season, League, HomeTeam, AwayTeam;
            //через ВИТ определяем,что нужно пользователю - результаты прошлых матчей или прогноз
            bool Past=true;
            string ExcelName;
            if (Past)
            {
                ExcelName = GetExcelFileName(League, Season);
                string[] MatchResult = GetMatchResult(ExcelName, HomeTeam, AwayTeam);
            }
            else
            {

            }
        }
    }
}
