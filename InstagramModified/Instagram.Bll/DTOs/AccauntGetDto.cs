using Instagram.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Bll.DTOs;

public class AccauntGetDto
{
    public long AccauntId { get; set; }
    public string UserName { get; set; }
    public string Bio { get; set; }
    public List<Post> Posts { get; set; }
    public List<Comment> Comments { get; set; }
}
