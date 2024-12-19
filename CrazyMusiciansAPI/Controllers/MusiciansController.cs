using CrazyMusiciansAPI.Models;
using CrazyMusiciansAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MusiciansController : ControllerBase
{
    private readonly MusicianRepository _repository = new MusicianRepository();

    [HttpGet]
    public IActionResult GetAllMusicians()
    {
        var musicians = _repository.GetAllMusicians();
        return Ok(musicians);
    }

    [HttpGet("{id}")]
    public IActionResult GetMusicianById(int id)
    {
        var musician = _repository.GetMusicianById(id);
        if (musician == null) return NotFound();
        return Ok(musician);
    }

    [HttpPost]
    public IActionResult AddMusician([FromBody] Musician musician)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _repository.AddMusician(musician);
        return CreatedAtAction(nameof(GetMusicianById), new { id = musician.Id }, musician);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMusician(int id, [FromBody] Musician musician)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var existing = _repository.GetMusicianById(id);
        if (existing == null) return NotFound();
        musician.Id = id;
        _repository.UpdateMusician(musician);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult PartialUpdateMusician(int id, [FromBody] Musician musician)
    {
        var existing = _repository.GetMusicianById(id);
        if (existing == null) return NotFound();

        if (!string.IsNullOrWhiteSpace(musician.Name)) existing.Name = musician.Name;
        if (!string.IsNullOrWhiteSpace(musician.Profession)) existing.Profession = musician.Profession;
        if (!string.IsNullOrWhiteSpace(musician.FunFeature)) existing.FunFeature = musician.FunFeature;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMusician(int id)
    {
        var musician = _repository.GetMusicianById(id);
        if (musician == null) return NotFound();
        _repository.DeleteMusician(id);
        return NoContent();
    }
}
