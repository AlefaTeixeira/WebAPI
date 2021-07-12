using FluentValidation;

public class FilmeInputPostDTO {
    public string Titulo { get; set; }
    public long DiretorId { get; set; }
    public FilmeInputPostDTO(string titulo, long diretorId) {
        Titulo = titulo;
        DiretorId = diretorId;
        
    }
}
    public class FilmeInputPostDTOValidator : AbstractValidator<FilmeInputPostDTO> {
    public FilmeInputPostDTOValidator() {
        RuleFor(filmes => filmes.Titulo).NotNull().NotEmpty();
        RuleFor(filmes => filmes.Titulo).Length(2,250).WithMessage("Tamanho invalido");
        RuleFor(filmes => filmes.DiretorId).NotNull().NotEmpty();
    }
}
