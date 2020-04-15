using System;

namespace TeamProject.Domain.Entities
{
    public class Log
    {
        public int LogId { get; set; }
        public string Application { get; set; }
        public DateTime Time { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string Service { get; set; }
        public string Exception { get; set; }

        public string Callsite { get; set; }
    }
}