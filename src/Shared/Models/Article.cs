using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class Article : DataEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public DateTime DatePublished { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Content { get; set; }

        public Article()
        {
            
        }

        public Article(string name, string author, DateTime datePublished, string subject, string content)
        {
            Name = name;
            Author = author;
            DatePublished = datePublished;
            Subject = subject;
            Content = content;

        }

        public override string ToString()
        {
            return $"Id : {Id}, Name: {Name}, Author: {Author}, DatePublished: {DatePublished.ToString()}, Subject: {Subject}, Content: {Content}";
        }
    }
}
