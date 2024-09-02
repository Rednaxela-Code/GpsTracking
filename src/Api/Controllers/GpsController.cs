using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System.Globalization;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GpsController : ControllerBase
    {
        private readonly ILogger<GpsController> _logger;
        private readonly ApplicationDbContext _context;

        public GpsController(ILogger<GpsController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("add")]
        public async Task<ActionResult<GpsPoint>> PostGpsPoint(GpsPoint point)
        {
            if (point == null)
            {
                return BadRequest();
            }

            _context.GpsPoints.Add(point);
            await _context.SaveChangesAsync();

            return Ok();

            // Return a CreatedAtAction result with the product and its URI [OPTIONAL]
            // return CreatedAtAction(nameof(GetGpsPointById), new { id = point.Id }, point);
        }

        [HttpPost("addRange")]
        public async Task<ActionResult<List<GpsPoint>>> PostList(List<GpsPoint> points)
        {
            if (points == null)
            {
                return BadRequest();
            }

            _context.GpsPoints.AddRange(points);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("getAll")]
        public async Task<ActionResult> GetAll()
        {
            var points = await _context.GpsPoints.OrderBy(p => p.Timestamp).ToListAsync();

            return Ok(points);
        }

        [HttpGet("id")]
        public async Task<ActionResult<GpsPoint>> GetGpsPointById(Guid id)
        {
            var gpsPoint = await _context.GpsPoints.FindAsync(id);

            if (gpsPoint == null)
            {
                return NotFound();
            }

            return Ok(gpsPoint);
        }

        [HttpGet("byIds")]
        public async Task<ActionResult<List<GpsPoint>>> GetGpsPointsById([FromQuery] List<Guid> ids)
        {
            if (ids == null || !ids.Any())
            {
                return BadRequest("No IDs provided.");
            }

            var gpsPoints = await _context.GpsPoints
                                          .Where(g => ids.Contains(g.Id))
                                          .ToListAsync();

            if (!gpsPoints.Any())
            {
                return NotFound("No GPS points found for the provided IDs.");
            }

            return Ok(gpsPoints);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<GpsPoint>> DeleteGpsPoint(GpsPoint deletePoint)
        {
            if (deletePoint == null)
            {
                return BadRequest();
            }

            _context.GpsPoints.Remove(deletePoint);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("deleteRange")]
        public async Task<ActionResult<List<GpsPoint>>> DeleteRange(List<GpsPoint> pointsDelete)
        {
            if (pointsDelete == null)
            {
                return BadRequest();
            }

            _context.GpsPoints.RemoveRange(pointsDelete);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateGpsPoint(Guid id, GpsPoint gpsPoint)
        {
            if (id != gpsPoint.Id)
            {
                return BadRequest("ID mismatch");
            }

            var existingPoint = await _context.GpsPoints.FindAsync(id);
            if (existingPoint == null)
            {
                return NotFound();
            }

            existingPoint.Latitude = gpsPoint.Latitude;
            existingPoint.Longitude = gpsPoint.Longitude;
            existingPoint.Altitude = gpsPoint.Altitude;
            existingPoint.SatelliteCount = gpsPoint.SatelliteCount;
            existingPoint.Timestamp = gpsPoint.Timestamp;

            await _context.SaveChangesAsync();

            if (!_context.GpsPoints.Any(e => e.Id == id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("LoadFromString")]
        public async Task<IActionResult> LoadDataFromStringAsync(string fileContent)
        {
            var gpsPoints = new List<GpsPoint>();

            using (var reader = new StringReader(fileContent))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    var columns = line.Split(',');

                    if (columns.Length >= 5)
                    {
                        try
                        {
                            GpsPoint gpsPoint = new(

                                double.Parse(columns[0], CultureInfo.InvariantCulture),
                                double.Parse(columns[1], CultureInfo.InvariantCulture),
                                double.Parse(columns[2], CultureInfo.InvariantCulture),
                                int.Parse(columns[3]),
                                ParseDateTime(columns[4], columns[5])
                            );

                            gpsPoints.Add(gpsPoint);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine($"Error parsing line: {line}. Exception: {ex.Message}");
                            return BadRequest(ex.Message);
                        }
                    }
                }
            }
            try
            {
                await _context.AddRangeAsync(gpsPoints);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private DateTime ParseDateTime(string date, string time)
        {
            string dateTimeString = $"{date} {time}";
            return DateTime.ParseExact(dateTimeString, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        }


    }
}
