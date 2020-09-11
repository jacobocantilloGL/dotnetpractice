//-----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>Yaakov</author>
// <date>2020-09-08 17:20:51</date>
// <summary>Código fuente clase IRepository.</summary>
//-----------------------------------------------------------------------
namespace TvCatalog.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using TvCatalog.Entities;

    /// <summary>
    /// Define el comportamiento báse de un repositorio.
    /// </summary>
    /// <typeparam name="TEntity">Tipo generalizado que representa el tipo de dato
    /// gestionar por la clase.</typeparam>
    public interface IRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        /// <summary>
        /// Consulta la entidad por el id asociado.
        /// </summary>
        /// <param name="id">Id de la entidad.</param>
        /// <returns>Datos de la entidad.</returns>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// Gestiona a consulta de las entidades registradas.
        /// </summary>
        /// <returns>Colección de elementos de tipo <see cref="TEntity"/>.</returns>
        Task<ICollection<TEntity>> GetAllAsync();

        /// <summary>
        /// Gestiona la consulta de las entidades de acuerdo a la expresión de filtro dada.
        /// </summary>
        /// <param name="expression">Filtro empleado en la búsqueda.</param>
        /// <returns>Colección de elementos de tipo <see cref="TEntity"/>.</returns>
        Task<ICollection<TEntity>> GetAllByAsync(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Añade un elemento a la base de datos.
        /// </summary>
        /// <param name="entity">Entidad que será añadida  la base de datos.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Actualiza una entidad en la base de daros.s
        /// </summary>
        /// <param name="entity">Datos de la entidad que será actualizada.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Elimina los datos de una entidad.
        /// </summary>
        /// <param name="id">Id de la entidad a eliminar.</param>
        void Delete(int id);
    }
}