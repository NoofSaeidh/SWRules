using Abp.Auditing;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noofs.SWRules.Powers
{
    [Audited]
    public class Power : FullAuditedEntity
    {
        public string Name { get; set; }
        public string Book { get; set; }
        public string Points { get; set; }
        public string Duration { get; set; }
        public string Distance { get; set; }
        public string Rank { get; set; }
        public string Trappings { get; set; }
        public string Text { get; set; }
    }
}
