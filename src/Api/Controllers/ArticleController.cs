using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly ILogger<ArticleController> _logger;
        private readonly ApplicationDbContext _context;

        public ArticleController(ILogger<ArticleController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("single")]
        public async Task<ActionResult<Article>> PostSingleArticle(Article articleSingle)
        {
            if (articleSingle == null)
            {
                return BadRequest();
            }

            articleSingle.DatePublished = DateTime.Now;

            _context.Articles.Add(articleSingle);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("list")]
        public async Task<ActionResult> PostList([FromBody] List<Article> articles)
        {
            if (articles == null || !articles.Any())
            {
                return BadRequest();
            }

            foreach (var item in articles)
            {
                item.DatePublished = DateTime.Now;
            }

            _context.Articles.AddRange(articles);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("getAll")]
        public async Task<ActionResult> GetAll()
        {
            var articles = await _context.Articles.ToListAsync();
            return Ok(articles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticleById(int id)
        {
            var article = await _context.Articles.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        [HttpGet("ids")]
        public async Task<ActionResult<List<Article>>> GetArticlesById([FromQuery] List<int> idsList)
        {
            if (idsList == null || !idsList.Any())
            {
                return BadRequest("No IDs provided.");
            }

            var articles = await _context.Articles
                                          .Where(g => idsList.Contains(g.Id))
                                          .ToListAsync();

            if (!articles.Any())
            {
                return NotFound("No articles found for the provided IDs.");
            }

            return Ok(articles);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArticle(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("range")]
        public async Task<ActionResult> DeleteArticlesRange([FromBody] List<int> articleIds)
        {
            if (articleIds == null || !articleIds.Any())
            {
                return BadRequest();
            }

            var articles = await _context.Articles
                                         .Where(a => articleIds.Contains(a.Id))
                                         .ToListAsync();

            if (!articles.Any())
            {
                return NotFound("No articles found for the provided IDs.");
            }

            _context.Articles.RemoveRange(articles);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticle(int id, [FromBody] Article articleUpdate)
        {
            if (id != articleUpdate.Id)
            {
                return BadRequest("Article ID mismatch.");
            }

            var existingArticle = await _context.Articles.FindAsync(id);
            if (existingArticle == null)
            {
                return NotFound();
            }

            existingArticle.Name = articleUpdate.Name;
            existingArticle.Author = articleUpdate.Author;
            existingArticle.DatePublished = articleUpdate.DatePublished;
            existingArticle.Subject = articleUpdate.Subject;
            existingArticle.Content = articleUpdate.Content;
            existingArticle.AuthorEmail = articleUpdate.AuthorEmail;
            existingArticle.AuthorDescription = articleUpdate.AuthorDescription;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
