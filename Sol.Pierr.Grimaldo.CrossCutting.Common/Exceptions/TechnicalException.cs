

using System;
using System.Runtime.Serialization;
using static Sol.Pierr.Grimaldo.CrossCutting.Common.Constants.Constants;

namespace Sol.Pierr.Grimaldo.CrossCutting.Common.Exceptions
{
    [Serializable()]
    public class TechnicalException : Exception, ISerializable
    {
        public string TransactionId { get; }
        public int ErrorCode { get; }
        public dynamic Data { get; set; }

        public TechnicalException(string message) : base(message)
        {
            this.ErrorCode = SystemStatusCode.TechnicalError;
            this.TransactionId = DateTime.Now.ToString(Constants.Constants.DateTimeFormats.DD_MM_YYYY_HH_MM_SS_FFF);
        }
    }
}
