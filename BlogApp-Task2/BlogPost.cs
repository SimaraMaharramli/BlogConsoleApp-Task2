using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp_Task2
{
    public class BlogPost
    {
        public int Id { get; }
        public string Title { get; }
        public string Content { get; }
        public List<string> Tags { get; }

        public BlogPost(int id, string title, string content, List<string> tags)
        {
            Id = id;
            Title = title;
            Content = content;
            Tags = tags;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Content: {Content}");
            Console.WriteLine($"Tags: {string.Join(", ", Tags)}");
        }


        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static BlogPost FromJson(string json)
        {
            return JsonConvert.DeserializeObject<BlogPost>(json);
        }
    }
}
