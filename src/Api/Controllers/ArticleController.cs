using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly ILogger<ArticleController> _logger;
        private readonly ApplicationDbContext _context;

        public ArticleController(ILogger<ArticleController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("add")]
        public async Task<ActionResult<ArticleController>> PostArticle(Article article)
        {
            if (article == null)
            {
                return BadRequest();
            }

            _context.Articles.Add(article);
            await _context.SaveChangesAsync();

            return Ok();

            // Return a CreatedAtAction result with the product and its URI [OPTIONAL]
            // return CreatedAtAction(nameof(GetGpsPointById), new { id = point.Id }, point);
        }

        [HttpPost("addRange")]
        public async Task<ActionResult<List<Article>>> PostList(List<Article> articles)
        {
            if (articles == null)
            {
                return BadRequest();
            }

            _context.Articles.AddRange(articles);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("getAll")]
        public async Task<ActionResult> GetAll()
        {
            var points = await _context.Articles.OrderBy(p => p.DatePublished).ToListAsync();

            return Ok(points);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Article>> GetArticleById(Guid id)
        {
            var article = await _context.Articles.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        [HttpGet("byIds")]
        public async Task<ActionResult<List<Article>>> GetArticlesById([FromQuery] List<Guid> ids)
        {
            if (ids == null || !ids.Any())
            {
                return BadRequest("No IDs provided.");
            }

            var articles = await _context.Articles
                                          .Where(g => ids.Contains(g.Id))
                                          .ToListAsync();

            if (!articles.Any())
            {
                return NotFound("No GPS points found for the provided IDs.");
            }

            return Ok(articles);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Article>> DeleteArticle(Article article)
        {
            if (article == null)
            {
                return BadRequest();
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("deleteRange")]
        public async Task<ActionResult<List<Article>>> DeleteRange(List<Article> articlesDelete)
        {
            if (articlesDelete == null)
            {
                return BadRequest();
            }

            _context.Articles.RemoveRange(articlesDelete);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateArticle(Guid id, Article article)
        {
            if (id != article.Id)
            {
                return BadRequest("ID mismatch");
            }

            var existingArticle = await _context.Articles.FindAsync(id);
            if (existingArticle == null)
            {
                return NotFound();
            }

            existingArticle.Name = article.Name;
            existingArticle.Author = article.Author;
            existingArticle.DatePublished = article.DatePublished;
            existingArticle.Subject = article.Subject;
            existingArticle.Content = article.Content;

            await _context.SaveChangesAsync();

            if (!_context.Articles.Any(e => e.Id == id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
