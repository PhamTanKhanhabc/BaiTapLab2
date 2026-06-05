using Microsoft.AspNetCore.Mvc;
using DapperApi.Models;
using DapperApi.Repositories;

namespace DapperApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentRepository _repo;

    public StudentsController(IStudentRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_repo.GetAll());

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        var student = _repo.GetById(id);
        return student is null ? NotFound() : Ok(student);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Student student)
    {
        _repo.Create(student);
        return CreatedAtAction(nameof(Get), new { id=student.Id }, student);
    }

    [HttpPut]
    public IActionResult Update([FromBody] Student student)
    {
        _repo.Update(student);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        _repo.Delete(id);
        return NoContent();
    }

    [HttpGet("courses")]
    public IActionResult GetAllWithCourses() => Ok(_repo.GetAllWithCourses());
}