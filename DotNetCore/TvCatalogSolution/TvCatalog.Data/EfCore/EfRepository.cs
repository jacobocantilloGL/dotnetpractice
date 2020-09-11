//-----------------------------------------------------------------------
// <copyright file="Repository.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>Yaakov</author>
// <date>2020-09-08 17:29:48</date>
// <summary>Código fuente clase Repository.</summary>
//-----------------------------------------------------------------------
namespace TvCatalog.Data.Ef
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using TvCatalog.Entities;

    /// <summary>
    /// Repositorio base como ORM EF Core.
    /// </summary>
    /// <typeparam name="TEntity">Tipo generalizado que representa el dato
    /// gestionado por la entidad.</typeparam>
    internal abstract class EfRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        #region Attributes

        /// <summary>
        /// Instancia que gestiona la conexión con la base de datos usando EF Core.
        /// </summary>
        protected readonly EfDbContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EfRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">Contexto de conexión a la base de dato susando EF Core.</param>
        public EfRepository(EfDbContext context)
        {
            this._context = context;
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Consulta la entidad por el id asociado.
        /// </summary>
        /// <param name="id">Id de la entidad.</param>
        /// <returns>Datos de la entidad.</returns>
        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            try
            {
                return await this._context.Set<TEntity>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Gestiona a consulta de las entidades registradas.
        /// </summary>
        /// <returns>Colección de elementos de tipo <see cref="TEntity"/>.</returns>
        public virtual async Task<ICollection<TEntity>> GetAllAsync()
        {
            try
            {
                return await this._context.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Gestiona la consulta de las entidades de acuerdo a la expresión de filtro dada.
        /// </summary>
        /// <param name="expression">Filtro empleado en la búsqueda.</param>
        /// <returns>Colección de elementos de tipo <see cref="TEntity"/>.</returns>
        public virtual async Task<ICollection<TEntity>> GetAllByAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return await this._context.Set<TEntity>().Where(expression).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Añade un elemento a la base de datos.
        /// </summary>
        /// <param name="entity">Entidad que será añadida  la base de datos.</param>
        /// <returns>Instancia registrada en el sistema.</returns>
        public virtual void Add(TEntity entity)
        {
            try
            {
                this._context.Set<TEntity>().Add(entity);
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza una entidad en la base de daros.s
        /// </summary>
        /// <param name="entity">Datos de la entidad que será actualizada.</param>
        public virtual void Update(TEntity entity)
        {
            try
            {
                this._context.Set<TEntity>().Update(entity);
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina los datos de una entidad.
        /// </summary>
        /// <param name="id">Id de la entidad a eliminar.</param>
        public virtual void Delete(int id)
        {
            try
            {
                TEntity data = this._context.Set<TEntity>().Find(id);

                if (data != null)
                {
                    this._context.Set<TEntity>().Remove(data);
                }
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, ex);
            }
        }

        #endregion
    }
}