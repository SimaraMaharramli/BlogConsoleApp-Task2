using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp_Task2
{
    public class BlogManager
    {
        private List<BlogPost> blogPosts;

        public BlogManager()
        {
            blogPosts = new List<BlogPost>();
        }

        public void CreateBlogPost(string title, string content, List<string> tags)
        {
            int id = blogPosts.Count + 1; 
            BlogPost newPost = new BlogPost(id, title, content, tags);
            blogPosts.Add(newPost);
            Console.WriteLine("Blog post created successfully!");
        }

        public void ListAllBlogPosts()
        {
            foreach (var post in blogPosts)
            {
                Console.WriteLine($"ID: {post.Id} - Title: {post.Title}");
            }
        }

        public void DisplayBlogPostDetails(int id)
        {
            var post = blogPosts.FirstOrDefault(p => p.Id == id);
            if (post != null)
            {
                post.PrintDetails();
            }
            else
            {
                Console.WriteLine("Blog post not found!");
            }
        }

        public List<BlogPost> SearchBlogPosts(string keyword)
        {
            return blogPosts.Where(post => post.Title.Contains(keyword) || post.Content.Contains(keyword) || post.Tags.Contains(keyword)).ToList();
        }

        public void SaveToFile(string directoryPath)
        {
            string filePath = Path.Combine(directoryPath, "JsonfileForBlogApp.txt");
            var serializedData = JsonConvert.SerializeObject(blogPosts);
            File.WriteAllText(filePath, serializedData);
            Console.WriteLine("Data saved to file successfully!");
        }

        public void LoadFromFile(string directoryPath)
        {
            string filePath = Path.Combine(directoryPath, "JsonfileForBlogApp.txt");
            if (File.Exists(filePath))
            {
                var serializedData = File.ReadAllText(filePath);
                blogPosts = JsonConvert.DeserializeObject<List<BlogPost>>(serializedData);
                Console.WriteLine("Data loaded from file successfully!");
            }
            else
            {
                Console.WriteLine("File not found!");
            }
        }
    }
}
