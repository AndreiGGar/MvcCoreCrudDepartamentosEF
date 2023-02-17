using MvcCoreCrudDepartamentosEF.Data;
using MvcCoreCrudDepartamentosEF.Models;

namespace MvcCoreCrudDepartamentosEF.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentosContext context;

        public RepositoryDepartamentos(DepartamentosContext context)
        {
            this.context = context;

        }

        public List<Departamento> GetDepartamentos()
        {
            var consulta = from datos in this.context.Departamentos
                           select datos;
            return consulta.ToList();
        }

        public Departamento FindDepartamento(int iddepartamento)
        {
            var consulta = from datos in this.context.Departamentos
                           where datos.IdDepartamento == iddepartamento
                           select datos;
            return consulta.FirstOrDefault();
        }

        public async Task InsertDepartamentoAsync (int iddepartamento, string nombre, string localidad)
        {
            Departamento departamento = new Departamento();
            departamento.IdDepartamento = iddepartamento;
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            this.context.Departamentos.Add(departamento);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateDepartamentoAsync(int iddepartamento, string nombre, string localidad)
        {
            Departamento departamento = this.FindDepartamento(iddepartamento);
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteDepartamentoAsync(int iddepartamento)
        {
            Departamento departamento = this.FindDepartamento(iddepartamento);
            this.context.Remove(departamento);
            await this.context.SaveChangesAsync();
        }
    }
}
