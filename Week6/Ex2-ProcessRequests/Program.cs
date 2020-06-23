using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProcessRequests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ex2 -  REST Api - read all posts and All comments Async");

            try
            {
                //read all posts Async
                var taskPosts = GetAllPostsAsync();
                var allPosts = JsonSerializer.Deserialize<List<Post>>(taskPosts.Result);


                List<Task<string>> commentsTasks = new List<Task<string>>();
                //read all posts Coments
                foreach (Post post in allPosts)
                {
                    commentsTasks.Add(GetAllCommentsAsync(post.Id));
                }

                //wait all comments to arrive
                Task.WaitAll(commentsTasks.ToArray());


                //display all comments
                var allComments = JsonSerializer.Deserialize<List<Comment>>(commentsTasks.Result);
                foreach (Comment comment in allComments)
                {
                    Console.WriteLine($"Post Details{0}", comment.PostId);
                    Console.WriteLine("Comments :" + comment.Body+"\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DataSource Fetch Error:" + ex.Message);
            }

        }

        
        private static async Task<string> GetAllPostsAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private static async Task<string> GetAllCommentsAsync(int postId)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/comments?postId=" + postId);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
