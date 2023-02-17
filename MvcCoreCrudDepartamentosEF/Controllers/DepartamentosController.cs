using Microsoft.AspNetCore.Mvc;
using MvcCoreCrudDepartamentosEF.Models;
using MvcCoreCrudDepartamentosEF.Repositories;

namespace MvcCoreCrudDepartamentosEF.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryDepartamentos repo;

        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Departamento> departamentos = this.repo.GetDepartamentos();
            return View(departamentos);
        }

        public IActionResult Details(int iddepartamento)
        {
            Departamento departamento = this.repo.FindDepartamento(iddepartamento);
            return View(departamento);
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Departamento dept)
        {
            await this.repo.InsertDepartamentoAsync(dept.IdDepartamento, dept.Nombre, dept.Localidad);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int iddepartamento)
        {
            Departamento departamento = this.repo.FindDepartamento(iddepartamento);
            return View(departamento);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Departamento dept)
        {
            await this.repo.UpdateDepartamentoAsync(dept.IdDepartamento, dept.Nombre, dept.Localidad);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int iddepartamento)
        {
            await this.repo.DeleteDepartamentoAsync(iddepartamento);
            return RedirectToAction("Index");
        }
    }
}
