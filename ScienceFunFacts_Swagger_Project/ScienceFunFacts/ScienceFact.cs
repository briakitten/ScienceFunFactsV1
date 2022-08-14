using System;
using System.Collections.Generic;

namespace ScienceFunFactsV1.ScienceFacts
{
    public class ScienceFact
    {
        public ScienceFact(string title, string fact, string[] sources)
        {
            this.Title = title;
            this.Fact = fact;
            this.Sources = sources;
        }

        public string Title { get; set; }

        public string Fact { get; set; }

        public IEnumerable<string> Sources { get; set; }
    }
}