using System;

namespace Lab2
{
    [Serializable]
    public class TgsClass
    {
        public TgsClass() { }
        public string ClientIdentity { get; set; }
        public string ServiceIdentity { get; set; }
        public DateTime IssuingTime { get; set; }
        public long Duration { get; set; }
        public string Key { get; set; }
    }

    public class TimeMark
    {
        public string C { get; set; }
        public DateTime T { get; set; }
    }
}
