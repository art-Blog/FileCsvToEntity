using FileHelpers;

namespace FileCsvToEntity.Model
{
    /// <summary>
    /// 線上OB人員
    /// </summary>
    [DelimitedRecord(" ")]
    public class OutBoundUserCsv
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Status { get; set; }

        public string Auxreason { get; set; }

        public string StatTimeStampDatePart { get; set; }
        public string StatTimeStampTimePart { get; set; }

        public string StatTimeStamp => StatTimeStampDatePart + " " + StatTimeStampTimePart;

        public string FirstLoginDatePart { get; set; }
        public string FirstLoginTimePart { get; set; }

        public string FirstLoginDate => FirstLoginDatePart + " " + FirstLoginTimePart;

        public string CTIPlace { get; set; }

        public string CurrentDatePart { get; set; }
        public string CurrentTimePart { get; set; }
        public string CurrentDate => CurrentDatePart + " " + CurrentTimePart;

        public string ParentDeptName { get; set; }

        public int TotalAgents { get; set; }
        public int TotalOnCalls { get; set; }
        public int TotalAvailable { get; set; }
        public int TotalAuxWork { get; set; }

        public string DeptName { get; set; }

        public string TalkTime { get; set; }
    }
}