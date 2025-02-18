using Instagram.Dal;
using Instagram.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Repository.Services;

public class PostRepository : IPostRepository
{
    private readonly MainContext MainContext;

    public PostRepository(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task<long> AddPostAsync(Post post)
    {
        await MainContext.Posts.AddAsync(post);
        await MainContext.SaveChangesAsync();
        return post.PostId;
    }

    public async Task DeletePostAsync(long id)
    {
        var commentFromDb = await GetPostByIdAsync(id);
        MainContext.Posts.Remove(commentFromDb);
        await MainContext.SaveChangesAsync();
    }

    public async Task<List<Post>> GetAllPostsAsync(bool includeComment = false)
    {
        // Queryable. Ienumarable
        // Queryable
        var postsQuary = MainContext.Posts.AsQueryable();
        if (includeComment)
            postsQuary = postsQuary.Include(post => post.Comments);
        // Ienumarable
        var posts = await postsQuary.ToListAsync();
        return posts;
    }

    public async Task<Post> GetPostByIdAsync(long id)
    {
        //var post = await MainContext.Posts.FirstOrDefaultAsync(p => p.PostId == id);
        //if (post == null) throw new NullReferenceException();
        var postFromDb = await MainContext.Posts.FindAsync(id);
        if (postFromDb == null) throw new NullReferenceException();
        return postFromDb;
    }

    public async Task UpdatePostAsync(Post post)
    {
        var postFromDb = await GetPostByIdAsync(post.PostId);
        postFromDb.PostType = post.PostType;
        postFromDb.CreatedTime = post.CreatedTime;
        await MainContext.SaveChangesAsync();
    }
}
