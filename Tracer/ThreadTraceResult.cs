﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Tracer
{
    [JsonObject]
    [Serializable]
    [XmlRoot("thread")]
    public class ThreadTraceResult
    {
        [JsonProperty("id")]
        [XmlAttribute("id")]
        public uint Id { get; set; }
        [JsonProperty("time")]
        [XmlAttribute("time")]
        public string WorkTimeStr
        {
            get
            {
                return Math.Round(WorkTime) + "ms";
            }
            set
            {
                WorkTimeStr = value;
            }
        }
        [JsonIgnore]
        [XmlIgnore]
        public double WorkTime { get; set; }
        [JsonProperty("methods")]
        [XmlArray("methods")]
        public List<MethodTraceResult> Methods { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public Stack<MethodTraceResult> LastStackMethods { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public int MethodsCount { get; private set; }

        public ThreadTraceResult(uint id)
            : this()
        {
            Id = id;
        }

        private ThreadTraceResult()
        {
            LastStackMethods = new Stack<MethodTraceResult>();
            Methods = new List<MethodTraceResult>();
            Id = 0;
            WorkTime = 0;
        }

        public double CalculateFullTime()
        {
            this.MethodsCount = 0;
            WorkTime = SummAllMethodsTimes(Methods);

            return WorkTime;
        }

        private double SummAllMethodsTimes(List<MethodTraceResult> methods)
        {
            double summ = 0;
            foreach (MethodTraceResult method in methods)
            {
                this.MethodsCount++;
                summ += Math.Round(method.GetWorkTime() + SummAllMethodsTimes(method.Methods));
            }

            this.WorkTime = summ;
            return summ;
        }
    }
}
