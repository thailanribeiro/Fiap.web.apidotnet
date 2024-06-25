namespace Fiap.web.apidotnet.Models
{
    public class ColetaModel
    {
        public int ColetaId { get; set; }
        public string? ColetaNome { get; set; }
        public string? ColetaDescricao { get; set; }
        public string? Email { get; set; }
        public DateTime DataColeta { get; set; }
        public string?   Observacao { get; set; }   
        public int RepresentanteId { get; set; }    
        public RepresentanteModel? Representante { get; set; }  

    }
}
