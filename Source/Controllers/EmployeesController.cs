// <copyright file="EmployeesController.cs" company="PK Codes">
// Copyright (c) PK Codes. All rights reserved.
// </copyright>

namespace MusicStore.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MusicStore.Models;

    /// <summary>
    /// This is the controller for employees.
    /// </summary>
    [Route("api/Employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly MusicStoreDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesController"/> class.
        /// </summary>
        /// <param name="context">The database context being injected.</param>
        public EmployeesController(MusicStoreDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// This method returns all of the employees that are listed in the database.
        /// </summary>
        /// <returns>A unit of execution that contains the type of <see cref="ActionResult"/>.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await this.context.Employees.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// This method will retrieve an employee by the ID.
        /// </summary>
        /// <param name="id">The employee ID.</param>
        /// <returns>A unit of execution that contains the type of <see cref="ActionResult"/>.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await this.context.Employees.FindAsync(id).ConfigureAwait(false);

            if (employee == null)
            {
                return this.NotFound();
            }

            return employee;
        }

        /// <summary>
        /// This method will add a new employee to the database.
        /// </summary>
        /// <param name="employee">The employee to add.</param>
        /// <returns>A unit of execution that contains a type of <see cref="ActionResult{Genre}"/>.</returns>
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            if (employee is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            this.context.Employees.Add(employee);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            return this.CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        /// <summary>
        /// This method will update an employee based on the ID and information.
        /// </summary>
        /// <param name="id">The employee ID.</param>
        /// <param name="employee">The employee information to update.</param>
        /// <returns>A unit of execution that contains the type of <see cref="IActionResult"/>.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (employee is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            if (id != employee.EmployeeId)
            {
                return this.BadRequest();
            }

            this.context.Entry(employee).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.EmployeeExists(id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.NoContent();
        }

        /// <summary>
        /// This method will delete an employee from the database based on an ID.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>A unit of execution that contains <see cref="IActionResult"/>.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await this.context.Employees.FindAsync(id).ConfigureAwait(false);
            if (employee == null)
            {
                return this.NotFound();
            }

            this.context.Employees.Remove(employee);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            return this.NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return this.context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
