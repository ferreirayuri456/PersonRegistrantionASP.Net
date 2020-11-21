using cadastroPessoa.Models;
using cadastroPessoa.Repository;
using System.Web.Mvc;

namespace cadastroPessoa.Controllers
{
    public class PessoasController : Controller
    {
        private PessoaRepository repository = new PessoaRepository();

        // GET: Pessoas
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(int id)
        {
            return View(repository.GetById(id));
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        [HttpPost]
        public ActionResult Create(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                repository.Save(pessoa);
                return RedirectToAction("Index");
            }
            else
            {
                return View(pessoa);
            }
        }

        // GET: Pessoas/Editar/5
        public ActionResult Editar(int id)
        {
            var pessoa = repository.GetById(id);

            if(pessoa == null)
            {
                return HttpNotFound();
            }

            return View(pessoa);
        }

        // POST: Pessoas/Editar/5
        [HttpPost]
        public ActionResult Editar(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                repository.Update(pessoa);
                return RedirectToAction("Index");
            }
        
                return View(pessoa);
            
        }
        // POST: Pessoas/Delete/5
        public ActionResult Delete(int id)
        {
            var pessoa = repository.GetById(id);
            if(pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }


        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Excluir")]
        public ActionResult DeleteConfirmado(int id)
        {
              // repository.DeleteById(id);
              // return RedirectToAction("Index");

            repository.DeleteById(id);
            return Json(repository.GetAll());


        }
    }
}
