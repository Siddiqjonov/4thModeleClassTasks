using Instagram.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Bll.DTOs;

public class PostUpdateDto
{
    public long PostId { get; set; }
    public string PostType { get; set; }
    public long AccauntId { get; set; }
}
