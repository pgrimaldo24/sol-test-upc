namespace Sol.Pierr.Grimaldo.CrossCutting.Common.Constants
{
    public class Constants
    {
        public struct SystemStatusCode
        {
            public const int Required = 1;
            public const int Ok = 200;
            public const int TechnicalError = 400;
            public const int NotFound = 404;
            public const int ServerError = 500;
        }

        public struct DateTimeFormats
        {
            public const string DD_MM_YYYY = "dd/MM/yyyy";
            public const string YYYY_MM_DD = "yyyy-MM-dd";
            public const string DD_MM_YYYY_HH_MM_SS = "dd/MM/yyyy HH:mm:ss";
            public const string DD_MM_YYYY_HH_MM_SS_STR = "yyyy-MM-dd hh:mm:ss";
            public const string DD_MM_YYYY_HH_MM_TT_12 = "dd/MM/yyyy hh:mm tt";
            public const string DD_MM_YYYY_HH_MM_SS_TT_12 = "dd/MM/yyyy hh:mm:ss tt";
            public const string DD_MM_YYYY_HH_MM_24 = "dd/MM/yyyy HH:mm";
            public const string DD_MM_YYYY_HH_MM_SS_FFF = "yyyyMMddHHmmssFFF";
            public const string DD_MM_YYY_HH_MM_SS = "ddMMyyyHHmmss"; 
        }
    }
}
