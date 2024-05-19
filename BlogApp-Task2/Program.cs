using BlogApp_Task2;

BlogManager blogManager = new BlogManager();

while (true)
{
    Console.WriteLine("\n1. Create Blog Post");
    Console.WriteLine("2. List All Blog Posts");
    Console.WriteLine("3. Display Blog Post Details");
    Console.WriteLine("4. Search Blog Posts");
    Console.WriteLine("5. Save To File");
    Console.WriteLine("6.  Load From File");
    Console.WriteLine("7. Exit");
    Console.Write("Choose an option: ");

    int choice;
    if (int.TryParse(Console.ReadLine(), out choice))
    {
        switch (choice)
        {
            case 1:
                Console.Write("Enter title: ");
                string title = Console.ReadLine();
                Console.Write("Enter content: ");
                string content = Console.ReadLine();
                Console.Write("Enter tags (comma separated): ");
                List<string> tags = Console.ReadLine().Split(',').Select(tag => tag.Trim()).ToList();
                blogManager.CreateBlogPost(title, content, tags);
                break;
            case 2:
                blogManager.ListAllBlogPosts();
                break;
            case 3:
                Console.Write("Enter post ID: ");
                if (int.TryParse(Console.ReadLine(), out int postId))
                {
                    blogManager.DisplayBlogPostDetails(postId);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                break;
            case 4:
                Console.Write("Enter search keyword: ");
                string keyword = Console.ReadLine();
                var searchResults = blogManager.SearchBlogPosts(keyword);
                if (searchResults.Any())
                {
                    Console.WriteLine("\nSearch Results:");
                    foreach (var post in searchResults)
                    {
                        Console.WriteLine($"ID: {post.Id} - Title: {post.Title}");
                    }
                }
                else
                {
                    Console.WriteLine("No matching posts found!");
                }
                break;
            case 5: // Save to file
                blogManager.SaveToFile(@"C:\Users\farid\OneDrive\Desktop\BlogApp-Task2");
                break;
            case 6: // Load from file
                blogManager.LoadFromFile(@"C:\Users\farid\OneDrive\Desktop\BlogApp-Task2");
                break;
            case 7: // Exit
                Console.WriteLine("Exiting...");
                return;
            default:
                Console.WriteLine("Invalid choice! Please enter a number between 1 and 8.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid choice! Please enter a number.");
    }
}