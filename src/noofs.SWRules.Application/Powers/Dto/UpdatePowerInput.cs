using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noofs.SWRules.Powers.Dto
{
    public class UpdatePowerInput : CreatePowerInput, IEntityDto
    {
        public int Id { get; set; }
    }
}
