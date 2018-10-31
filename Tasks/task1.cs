using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
namespace Tasks
{

    // task one 
    /* API */
    public class CommentsDTO
    {
        public int postId;
        public int id;
        public string name;
        public string email;
        public string body;

    }
    public class PostsDTO
    {
        public int userId;
        public int id;
        public string title;
        public string body;
        public List<CommentsDTO> comments = new List<CommentsDTO>() { };

    }
    public class Fetch
    {

        public string Posts_API = "https://jsonplaceholder.typicode.com/posts";
        public string comments_API = "https://jsonplaceholder.typicode.com/comments";
        public List<PostsDTO> all_posts;
        public List<CommentsDTO> all_comments;
        public List<string> JsonObjects;
        public Fetch()
        {
            this.comments_API = comments_API;
            this.Posts_API = Posts_API;
            json2lists();
            appendComments2Posts();
        }
        private void json2lists()
        {
            WebRequest PostsAPI_Request = WebRequest.Create(Posts_API);
            WebRequest CommentsAPI_Request = WebRequest.Create(comments_API);

            // Get the response.
            HttpWebResponse PostsAPIRequest = (HttpWebResponse)PostsAPI_Request.GetResponse();
            HttpWebResponse CommentsAPIRequest = (HttpWebResponse)CommentsAPI_Request.GetResponse();
            // Display the status.
            // Console.WriteLine(PostsResponse.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream posts_stream = PostsAPIRequest.GetResponseStream();
            Stream comments_stream = CommentsAPIRequest.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader posts_reader = new StreamReader(posts_stream);
            StreamReader comments_reader = new StreamReader(comments_stream);

            // Read the content.
            string postsJsonString = posts_reader.ReadToEnd();
            string commentsJsonString = comments_reader.ReadToEnd();

            // Cleanup the streams and the response.
            posts_reader.Close();
            comments_reader.Close();
            // streams
            posts_stream.Close();
            comments_stream.Close();
            // responses.
            PostsAPIRequest.Close();
            CommentsAPIRequest.Close();
            var comments = JsonConvert.DeserializeObject<List<CommentsDTO>>(commentsJsonString);
            var posts = JsonConvert.DeserializeObject<List<PostsDTO>>(postsJsonString);
            this.all_comments = comments;
            this.all_posts = posts;

        }
        private void appendComments2Posts()
        {
            var comments = this.all_comments;
            foreach (var post in all_posts)
            {
                foreach (var comment in all_comments)
                {
                    if (comment.postId == post.id)
                    {

                        post.comments.Add(comment);
                    }
                }
            }
        }

        public void getPostsByID(int userId)
        {
            int j = 1;
            foreach (var post in all_posts)
            {

                if (post.userId == userId)
                {
                    
                    Console.WriteLine("Post No." + j );
                    j += 1;
                    Console.WriteLine("POST: \n " + post.body);
                    for (int i = 0; i < post.comments.Count; i++)
                    {
                        Console.WriteLine("COMMENT NO.: \n " + i + "" + post.comments[i].body);
                    }
                }
            }
        }
    }

}