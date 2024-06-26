﻿using Microsoft.AspNetCore.Mvc;
using Servicio;
using Entidades;
using System.Text.Json;

namespace EmployeeService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GeneroController : ControllerBase
{
    private readonly IServicioGenero _generoService;

    public GeneroController(IServicioGenero generoService)
    {
        _generoService = generoService;
    }

    [HttpPost]
    public async Task<IActionResult> CargarGenero([FromBody] JsonElement jsonElement)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            Genero genero = JsonSerializer.Deserialize<Genero>(jsonElement);
            await _generoService.cargarGenero(genero);
            return Ok(new { Message = "Género agregado correctamente." });
        }
        catch (Exception ex)
        {
            var innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "Detalles no disponibles.";
            return StatusCode(500, $"Error interno del servidor: {innerExceptionMessage}");
        }
    }

    [HttpGet("GetGeneros")]
    public async Task<IActionResult> GetGeneros()
    {
        try
        {
            var generos = await _generoService.ObtenerGeneros();
            return Ok(generos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }

    }
}
