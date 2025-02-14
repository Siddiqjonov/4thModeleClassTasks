using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insta.Bll.Dtos;

public class CommentGetDto
{
    public long CommentId { get; set; }
    public string Body { get; set; }
    public DateTime CreatedTime { get; set; }
    public long AccauntId { get; set; }
    public long PostId { get; set; }
    public long? ParentCommentId { get; set; }
    public List<CommentGetDto> Replies { get; set; }
}
