using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Bll.DTOs;

public class UpdateCommentDto : CommentCreateDto
{
    public long CommentId { get; set; }
}
