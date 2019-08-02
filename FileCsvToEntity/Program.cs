using System;
using System.IO;
using FileCsvToEntity.Model;
using FileHelpers;

namespace FileCsvToEntity
{
    internal class Program
    {
        private static string dataPath = "./Data/Input.txt";

        private static void Main(string[] args)
        {
            Test01();
            Test02();
        }

        private static void Test02()
        {
            Func<string, OutBoundUserCsv> myHandler = ConvertStrToDto;
            ReadCsvFile(myHandler);
            Console.ReadKey();
        }

        private static void ReadCsvFile(Func<string, OutBoundUserCsv> myHandler)
        {
            using (var reader = new StreamReader(dataPath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var usr = myHandler.Invoke(line);
                    Console.WriteLine($"UserId:[{usr.UserId}] Name:[{usr.UserName}] ");
                }
            }
        }

        private static OutBoundUserCsv ConvertStrToDto(string source)
        {
            // 將原始字串切割為陣列後逐一填入entity
            var d = source.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            return new OutBoundUserCsv()
            {
                UserId = d[0],
                UserName = d[1],
                Status = d[2],
                Auxreason = d[3],
                StatTimeStampDatePart = d[4],
                StatTimeStampTimePart = d[5],
                FirstLoginDatePart = d[6],
                FirstLoginTimePart = d[7],
                CTIPlace = d[8],
                CurrentDatePart = d[9],
                CurrentTimePart = d[10],
                ParentDeptName = d[11],
                TotalAgents = int.Parse(d[12]),
                TotalOnCalls = int.Parse(d[13]),
                TotalAvailable = int.Parse(d[14]),
                TotalAuxWork = int.Parse(d[15]),
                DeptName = d[16],
                TalkTime = d[17]
            };
        }

        private static void Test01()
        {
            // 1. 來源檔案須設定為建置行為一律複製
            // 2. 利用空格切割資料，來源的日期格用兩個屬性接
            // 3. 來源檔案行末需要trim()掉空白字元
            // 4. mapping屬性順序依照model的prop順序
            var engine = new FileHelperEngine<OutBoundUserCsv>();
            var records = engine.ReadFile(dataPath);
            foreach (var usr in records)
            {
                Console.WriteLine($"UserId:[{usr.UserId}] Name:[{usr.UserName}] ");
            }
            Console.ReadKey();
        }
    }
}