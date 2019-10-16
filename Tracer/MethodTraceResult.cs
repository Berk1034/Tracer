using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Tracer
{
    [JsonObject]
    [Serializable]
    [XmlRoot("method")]
    public class MethodTraceResult
    {
        [JsonIgnore]
        [XmlIgnore]
        private Stopwatch _stopwatch;
        [JsonProperty("name")]
        [XmlAttribute("name")]
        public string MethodName { get; set; }
        [JsonProperty("time")]
        [XmlAttribute("time")]
        public string WorkTimeStr
        {
            get
            {
                return Math.Round((double)WorkTime) + "ms";
            }
            set
            {
                WorkTimeStr = value;
            }
        }
        [JsonIgnore]
        [XmlIgnore]
        public long WorkTime { get; set; }
        [JsonProperty("class")]
        [XmlAttribute("class")]
        public string ClassName { get; set; }
        [JsonProperty("methods")]
        [XmlArray("methods")]
        public List<MethodTraceResult> Methods { get; }

        public MethodTraceResult(string methodName, string className)
            : this()
        {
            MethodName = methodName;
            ClassName = className;
        }

        private MethodTraceResult()
        {
            Methods = new List<MethodTraceResult>();
            _stopwatch = new Stopwatch();
        }

        public void StartTrace()
        {
            _stopwatch.Start();
        }

        public long GetWorkTime()
        {
            return _stopwatch.ElapsedMilliseconds;
        }

        public void StopTrace()
        {
            _stopwatch.Stop();
            WorkTime = _stopwatch.ElapsedMilliseconds;
        }

        public void AddChildMethod(MethodTraceResult child)
        {
            if (child != null)
                this.Methods.Add(child);
            else
                return;

        }
    }
}
