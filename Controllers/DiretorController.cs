using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class DiretorController : ControllerBase {
    private readonly ApplicationDbContext _context;
private readonly DiretorService _diretorService;
    public DiretorController(ApplicationDbContext context, IDiretorService diretorService) {
        _context = context;
        _diretorService = diretorService;
    }
    
    /// <summary>
    /// Busca todos os diretores do sistema
    /// </summary>
    /// <param name="nome">Nome do diretor</param>
    /// <returns>Exibe os diretores</returns>
    /// <response code="200">Sucesso ao buscar todos os diretores</response>
    /// <response code="404">Não existe nenhum diretor cadastrado</response>
    /// <response code="500">Ocorreu erro no servidor.</response>
    
    // GET api/diretores
    [HttpGet]
    public async Task<ActionResult<DiretorListOutputGetAllDTO>> Get(CancellationToken cancellationToken, int limit = 5, int page = 1) {
        return await _diretorService.GetByPageAsync(limit, page, cancellationToken);
        
        }

    /// <summary>
    /// Busca um diretor pelo seu Id
    /// </summary>
    /// <param name="nome">Id do diretor</param>
    /// <returns>Exibe o diretor buscado</returns>
    /// <response code="200">Sucesso ao retornar o diretor</response>
    /// <response code="404">Não existe diretor com esse Id informado</response>
    /// <response code="500">Ocorreu erro no servidor.</response>

    // GET api/diretores/1
    [HttpGet("{id}")]
    public async Task<ActionResult<DiretorOutputGetByIdDTO>> Get(long id) {
        var diretor = await _diretorService.GetById(id);    

        var outputDto = new DiretorOutputGetByIdDTO(diretor.Id, diretor.Nome);
        return Ok(outputDto);
    }

    /// <summary>
    /// Cria um diretor
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /diretor
    ///     {
    ///        "nome": "Teste diretor",
    ///     }
    ///
    /// </remarks>
    /// <param name="nome">Nome do diretor</param>
    /// <returns>O diretor foi criado com sucesso</returns>
    /// <response code="200">O diretor foi criado com sucesso</response>
    /// <response code="400">Não foi possível cadastrar um diretor</response>
    /// <response code="500">Ocorreu um erro no servidor.</response>

    // POST api/diretores
    [HttpPost]
    public async Task<ActionResult<DiretorOutputPostDTO>> Post([FromBody] DiretorInputPostDTO diretorInputDto) {
        var diretor = await _diretorService.Cria(new Diretor(diretorInputDto.Nome));

        var diretorOutputDto = new DiretorOutputPostDTO(diretor.Id, diretor.Nome);
        return Ok(diretorOutputDto);
    }

    /// <summary>
    /// Atualiza um diretor
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /diretor
    ///     {
    ///        "nome": "Teste diretor 2",
    ///     }
    ///
    /// </remarks>
    /// <param name="diretorId">Id do diretor</param>
    /// <param name="nome">Nome do diretor</param>
    /// <returns>O diretor foi atualizado com sucesso</returns>
    /// <response code="200">O diretor foi atualizado com sucesso</response>
    /// <response code="400">Não foi possível atualizar o diretor com o Id informado</response>
    /// <response code="500">Ocorreu erro no servidor.</response>
    
    // PUT api/diretores/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult<DiretorOutputPutDTO>> Put(long id, [FromBody] DiretorInputPutDTO diretorInputDto) {
        var diretor = await _diretorService.Atualiza(new Diretor(diretorInputDto.Nome), id);

        var diretorOutputDto = new DiretorOutputPutDTO(diretor.Id, diretor.Nome);
        return Ok(diretorOutputDto);
    }

    /// <summary>
    /// Exclui um diretor
    /// </summary>
    /// <param name="diretorId">Id do diretor</param>
    /// <returns>Diretor excluidoO diretor foi excluido com sucesso</returns>
    /// <response code="200">O diretor foi excluido com sucesso</response>
    /// <response code="404">Não foi possível excluir o diretor com o Id informado</response>
    /// <response code="500">Ocorreu erro no servidor.</response>

    // DELETE api/diretores/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id) {
        await _diretorService.Exclui(id);

        return Ok();
    }
}