﻿using Microsoft.EntityFrameworkCore;
using NetCoreSeguridadEmpleados.Data;
using NetCoreSeguridadEmpleados.Models;

namespace NetCoreSeguridadEmpleados.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;

        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            return await this.context.Empleados.ToListAsync();
        }

        public async Task<Empleado> FindEmpleadoAsync(int idEmpleado)
        {
            return await this.context.Empleados.FindAsync(idEmpleado);
        }

        public async Task<List<Empleado>> GetEmpleadosDepartamentoAsync
            (int idDepartamento)
        {
            return await this.context.Empleados
                .Where(d => d.IdDepartamento == idDepartamento)
                .ToListAsync();
        }

        public async Task UpdateSalarioEmpleadosAsync
            (int idDepartamento, int incremento)
        {
            List<Empleado> empleados = await
                this.GetEmpleadosDepartamentoAsync(idDepartamento);
            foreach(Empleado emp in empleados)
            {
                emp.Salario += incremento;
            }
            await this.context.SaveChangesAsync();
        }
    }
}
