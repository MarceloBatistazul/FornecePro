using FornecePro.Data;
using FornecePro.Models;
using Microsoft.AspNetCore.Mvc;

namespace FornecePro.Controllers
{
    public class CadastroController : Controller
    {
        readonly private AplicationDbContext _db;
        public CadastroController(AplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<CadastroModels> cadastros = _db.Cadastros;

            return View(cadastros);
        }
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            CadastroModels cadastro = _db.Cadastros.FirstOrDefault(x => x.Id == id);

            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        [HttpPost]
        public IActionResult Editar(CadastroModels cadastros)
        {
            if (ModelState.IsValid)
            {
                _db.Cadastros.Update(cadastros);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(cadastros);
        }


        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastroModels cadastros)

        {
            if (ModelState.IsValid)
            {
                _db.Cadastros.Add(cadastros);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            CadastroModels cadastro = _db.Cadastros.FirstOrDefault(x => x.Id == id);

            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        [HttpPost]
        public IActionResult Excluir(CadastroModels cadastros)
        {
            if (cadastros.Id != 0) // Verifica se o ID é válido
            {
                var cadastro = _db.Cadastros.Find(cadastros.Id); // Busca o registro pelo ID
                if (cadastro != null)
                {
                    _db.Cadastros.Remove(cadastro); // Remove o registro rastreado
                    _db.SaveChanges(); // Persiste a alteração no banco
                    return RedirectToAction("Index");
                }
            }
            return NotFound(); // Retorna erro se o ID for inválido ou não encontrado
        }

    }
}
