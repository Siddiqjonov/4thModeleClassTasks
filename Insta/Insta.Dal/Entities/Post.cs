using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insta.Dal.Entities;

public class Post
{
    public long PostId { get; set; }
    public DateTime CreatedTime { get; set; }
    public string PostType { get; set; }

    public long AccauntId { get; set; }
    public Accaunt Accaunt { get; set; }

    public List<Comment> Comments { get; set; }
}
