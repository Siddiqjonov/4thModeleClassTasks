using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Dal.Entities;

public class Comment
{
    public long CommentId { get; set; }
    public string Body { get; set; }
    public DateTime CreatedTime { get; set; }


    public long AccauntId { get; set; }
    public Accaunt Accaunt { get; set; }

    public long PostId { get; set; }
    public Post Post { get; set; }

    public long? ParentCommentId { get; set; }
    public Comment ParentComment { get; set; }

    public List<Comment> Replies { get; set; }
}
