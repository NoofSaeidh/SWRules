using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using noofs.SWRules.Powers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace noofs.SWRules.Powers.Dto
{
    [AutoMapTo(typeof(Power))]
    public class CreatePowerInput
    {
        [Display(Name = "Название", Order = 100)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Книга")]
        [Required]
        public string Book { get; set; }

        [Display(Name = "Пункты Силы")]
        public string Points { get; set; }

        [Display(Name = "Длительность")]
        public string Duration { get; set; }

        [Display(Name = "Дистанция")]
        public string Distance { get; set; }

        [Display(Name = "Ранг")]
        public string Rank { get; set; }

        [Display(Name = "Представления")]
        public string Trappings { get; set; }

        [Display(Name = "Текст", Order = -100)]
        [Required]
        public string Text { get; set; }
    }
}
