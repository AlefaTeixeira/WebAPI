using FluentValidation;

public class FilmeInputPutDTO {
    public long Id { get; set; }
    public string Titulo { get; set; }
    public long DiretorId { get; set; }
    public FilmeInputPutDTO(long id, string titulo, long diretorId) {
        Id = id;
        Titulo = titulo;
        DiretorId = diretorId;
    }
}
public class FilmeInputPuttDTOValidator : AbstractValidator<FilmeInputPutDTO> {
    public FilmeInputPutDTOValidator() {
        RuleFor(filmes => filmes.Titulo).NotNull().NotEmpty();
        RuleFor(filmes => filmes.Titulo).Length(2,250).WithMessage("Tamanho invalido");
        RuleFor(filmes => filmes.DiretorId).NotNull().NotEmpty();
        RuleFor(filmes => filmes.Id).NotNull().NotEmpty();
    }
}