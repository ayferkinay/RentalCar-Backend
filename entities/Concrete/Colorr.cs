using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Colorr  : IEntity
    {
        [Key]
        public int ColorId { get; set; }
        public string ColorName { get; set; }
    }
}
