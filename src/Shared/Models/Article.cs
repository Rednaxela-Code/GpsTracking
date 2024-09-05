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
        [Required]
        public string AuthorDescription { get; set; }
        [Required]
        public string AuthorEmail { get; set; }

        public Article()
        {
            
        }

        public Article(string name, string author, DateTime datePublished, string subject, string content, string authorDescription, string authorEmail)
        {
            Name = name;
            Author = author;
            DatePublished = datePublished;
            Subject = subject;
            Content = content;
            AuthorDescription = authorDescription;
            AuthorEmail = authorEmail;
        }

        public override string ToString()
        {
            return $"Id : {Id}, Name: {Name}, Author: {Author}, DatePublished: {DatePublished}, Subject: {Subject}, Content: {Content}, Author Description: {AuthorDescription}, Author Email: {AuthorEmail}";
        }
    }
}
