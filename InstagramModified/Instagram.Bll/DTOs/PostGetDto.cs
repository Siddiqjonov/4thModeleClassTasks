using Instagram.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Bll.DTOs;

public class PostGetDto
{
    public long PostId { get; set; }
    public DateTime CreatedTime { get; set; }
    public string PostType { get; set; }
    public long AccauntId { get; set; }
    public List<CommentGetDto> Comments { get; set; }
}
