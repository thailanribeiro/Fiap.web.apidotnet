using Fiap.web.apidotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; // importando o SelectList
namespace Fiap.Web.apidotnet.Controllers
{
    public class ColetaController : Controller
    {
        //Lista para armazenar os clientes
        public IList<ColetaModel> coletas { get; set; }
        //Lista para armazenar os representantes
        public IList<RepresentanteModel> representantes { get; set; }
        public ColetaController()
        {
            //Simula a busca de clientes no banco de dados
            coletas = GerarColetasMocados();
            representantes = GerarRepresentantesMocados();
        }
        public IActionResult Index()
        {
            // Evitando valores null 
            if (coletas == null)
            {
                coletas = new List<ColetaModel>();
            }
            return View(coletas);
        }
        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public IActionResult Create()
        {
            Console.WriteLine("Executou a Action Cadastrar()");
            //Cria a variável para armazenar o SelectList
            var selectListRepresentantes =
                new SelectList(representantes,
                                nameof(RepresentanteModel.RepresentanteId),
                                nameof(RepresentanteModel.NomeRepresentante));
            //Adiciona o SelectList a ViewBag para se enviado para a View
            //A propriedade Representantes é criada de forma dinâmica na ViewBag
            ViewBag.Representantes = selectListRepresentantes;
            // Retorna para a View Create um 
            // objeto modelo com as propriedades em branco 
            return View(new ColetaModel());
        }
        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        public IActionResult Create(ColetaModel coletaModel)
        {
            // Simila que os dados foram gravados.
            Console.WriteLine("Gravando a Coleta");
            //Criando a mensagem de sucesso que será exibida para o Cliente
            TempData["mensagemSucesso"] = $"A coleta {coletaModel.ColetaNome} foi cadastrado com suceso";
            // Substituímos o return View() 
            // pelo método de redirecionamento
            return RedirectToAction(nameof(Index));
            // O trecho nameof(Index) poderia ser usado da forma abaixo
            // return RedirectToAction("Index");
        }
        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Console.WriteLine("Executou a Action Cadastrar()");
            //Cria a variável para armazenar o SelectList
            var selectListRepresentantes =
                new SelectList(representantes,
                                nameof(RepresentanteModel.RepresentanteId),
                                nameof(RepresentanteModel.NomeRepresentante));
            //Adiciona o SelectList a ViewBag para se enviado para a View
            //A propriedade Representantes é criada de forma dinâmica na ViewBag
            ViewBag.Representantes = selectListRepresentantes;

            var coletaConsultado = coletas.Where(c => c.ColetaId == id).FirstOrDefault();

            // Retorna para a View Create um 
            // objeto modelo com as propriedades em branco 
            return View(coletaConsultado);
        }
        // Anotação de uso do Verb HTTP Get
        [HttpPost]
        public IActionResult Edit(ColetaModel coletaModel)
        {/*
            Console.WriteLine("Executou a Action Cadastrar()");
            //Cria a variável para armazenar o SelectList
            var selectListRepresentantes =
                new SelectList(representantes,
                                nameof(RepresentanteModel.RepresentanteId),
                                nameof(RepresentanteModel.NomeRepresentante));
            //Adiciona o SelectList a ViewBag para se enviado para a View
            //A propriedade Representantes é criada de forma dinâmica na ViewBag
            ViewBag.Representantes = selectListRepresentantes;

            var representanteConsultado = representantes.Where(c => c.ColetaId == id).();

            // Retorna para a View Create um 
            // objeto modelo com as propriedades em branco 
            return View(representanteConsultado);
        */
            TempData["mensagemSucesso"] = $"Os dados da Coleta {coletaModel.ColetaId} Foram alterados com sucesso";
            return RedirectToAction(nameof(Index));
        }
        
        public static List<RepresentanteModel> GerarRepresentantesMocados()
        {
            var representantes = new List<RepresentanteModel>
            {
                new RepresentanteModel { RepresentanteId = 1, NomeRepresentante = "Representante 1", Cpf = "111.111.111-11" },
                new RepresentanteModel { RepresentanteId = 2, NomeRepresentante = "Representante 2", Cpf = "222.222.222-22" },
                new RepresentanteModel { RepresentanteId = 3, NomeRepresentante = "Representante 3", Cpf = "333.333.333-33" },
                new RepresentanteModel { RepresentanteId = 4, NomeRepresentante = "Representante 4", Cpf = "444.444.444-44" }
            };
            return representantes;
        }
   
        public static List<ColetaModel> GerarColetasMocados()
        {
            var coletas = new List<ColetaModel>();
            for (int i = 1; i <= 5; i++)
            {
                var coleta = new ColetaModel
                {
                    ColetaId = i,
                    ColetaNome = "Coleta" + i,
                    ColetaDescricao = "Descrição" + i,
                    Email = "coleta" + i + "@example.com",
                    DataColeta = DateTime.Now.AddYears(-30),
                    Observacao = "Observação do coleta " + i,
                    RepresentanteId = i,
                    Representante = new RepresentanteModel
                    {
                        RepresentanteId = i,
                        NomeRepresentante = "Representante" + i,
                        Cpf = "00000000191"
                    }
                };
                coletas.Add(coleta);
            }
            return coletas;
        }
    }
}