using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase{
   private readonly IFilmeService _filmeService;

    public FilmeController(IFilmeService filmeService) {
        _filmeService = filmeService;
    }

    /// <summary>
    /// Busca os filmes
    /// </summary>
    /// <returns>Lista de filmes criados </returns>
    /// <response code="200">Sucesso ao buscar os filmes</response>
    /// <response code="404">Não existe nenhum filme cadastrado</response>
    /// <response code="500">Ocorreu erro no servidor.</response>

    // GET api/filmes
    [HttpGet]
        public async Task<ActionResult<FilmeListOutputGetAllDTO>> Get(CancellationToken cancellationToken, int limit = 5, int page = 1) {
        return await _filmeService.GetByPageAsync(limit, page, cancellationToken);        
    }

    /// <summary>
    /// Busca um filme via ID
    /// </summary>
    /// <returns>Sucesso ao buscar o filme pelo Id Informado</returns>
    /// <param name="titulo">Titulo do filme</param>
    /// <response code="200">Busca um filme pelo Id informado</response>
    /// <response code="404">Não foi possível buscar o filme pelo Id informado</response>
    /// <response code="500">Ocorreu erro no servidor.</response>

    // GET api/filmes/1
    [HttpGet("{id}")]
    public async Task<ActionResult<FilmeOutputGetByIdDTO>> Get(long id) {
        var filme = await _filmeService.GetById(id);

        var outputDTO = new FilmeOutputGetByIdDTO(filme.Id, filme.Titulo, filme.Diretor.Nome);
        return Ok(outputDTO);
    }

    /// <summary>
    /// Cadastra um novo gilme
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /filme
    ///     {
    ///        "titulo": "Filme 1",
    ///        "ano": "2010",
    ///        "genero": "Comedia",
    ///        "diretorId": 1
    ///     }
    /// </remarks>
    /// <param name="nome">Titulo do filme</param>
    /// <param name="ano">Ano do filme</param>
    /// <param name="genero">Gênero do filme</param>
    /// <param name="diretor">Diretor do filme</param>
    /// <returns>O filme foi cadastrado corretament</returns>
    /// <response code="200">O filme foi cadastrado corretamente</response>
    /// <response code="400">Não foi possível cadastrar o filme</response>
    /// <response code="500">Ocorreu erro no servidor.</response>

    // POST api/filmes
    [HttpPost]
    public async Task<ActionResult<FilmeOutputPostDTO>> Post([FromBody] FilmeInputPostDTO inputDTO) {
        var filme = await _filmeService.Cria(new Filme(inputDTO.Titulo, inputDTO.DiretorId));

        var outputDTO = new FilmeOutputPostDTO(filme.Id, filme.Titulo);
        return Ok(outputDTO);
    }

/// <summary>
    /// Cadastra um novo gilme
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /filme
    ///     {
    ///        "titulo": "Filme 1",
    ///        "ano": "2010",
    ///        "genero": "Comedia",
    ///     }
    /// </remarks>
    /// <param name="nome">Titulo do filme</param>
    /// <param name="ano">Ano do filme</param>
    /// <param name="genero">Gênero do filme</param>
    /// <param name="diretor">Diretor do filme</param>
    /// <returns>O filme foi cadastrado corretament</returns>
    /// <response code="200">O filme foi cadastrado corretamente</response>
    /// <response code="400">Não foi possível cadastrar o filme</response>
    /// <response code="500">Ocorreu erro no servidor.</response>

    // PUT api/filmes/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult<FilmeOutputPutDTO>> Put(long id, [FromBody] FilmeInputPutDTO inputDTO) {
        var filme = new Filme(inputDTO.Titulo, inputDTO.DiretorId);

        await _filmeService.Atualiza(filme, filme.Id);

        var outputDTO = new FilmeOutputPutDTO(filme.Id, filme.Titulo);
        return Ok(outputDTO);
    }

    /// <summary>
    /// Exclui um filme
    /// </summary>
    /// <returns>Exclui um filme</returns>
    /// <param name="filmeId">Id do filme</param>
    /// <response code="200">O filme foi excluido com sucesso</response>
    /// <response code="500">Ocorreu erro no servidor.</response>

    // DELETE api/filmes/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id) {
        await _filmeService.Exclui(id);
        return Ok(filme);
    }
}