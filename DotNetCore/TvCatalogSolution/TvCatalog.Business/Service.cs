//-----------------------------------------------------------------------
// <copyright file="Service.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>Yaakov</author>
// <date>2020-09-09 15:10:25</date>
// <summary>Código fuente clase Service.</summary>
//-----------------------------------------------------------------------
namespace TvCatalog.Business
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using TvCatalog.Common;
    using TvCatalog.Data;
    using TvCatalog.Entities;

    /// <summary>
    /// Define la clase base de los servicios del sistema.
    /// </summary>
    /// <typeparam name="TEntity">Tipo generalizado que representa el tipo de dato
    /// gestionar por la clase.</typeparam>
    internal abstract class Service<TEntity, TRepository> : IService<TEntity, TRepository>
        where TEntity : BaseEntity, new()
        where TRepository : IRepository<TEntity>
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{TEntity, TRepository}"/> class.
        /// </summary>
        /// <param name="uoW">Instancia de <see cref="IDataContext"/>.</param>
        public Service(IDataContext context)
        {
            this.Context = context;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets el contexto de conexión con la base de datos.
        /// </summary>
        /// <value>Contexto de conexion con la base de datos.</value>
        protected IDataContext Context { get; private set; }

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
                return await this.GetRepository().GetByIdAsync(id);
            }
            catch (DataException ex)
            {
                throw new TechnicalException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new GeneralException(ErrorMessages.GeneralError, ex);
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
                return await this.GetRepository().GetAllAsync();
            }
            catch (DataException ex)
            {
                throw new TechnicalException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new GeneralException(ErrorMessages.GeneralError, ex);
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
                return await this.GetRepository().GetAllByAsync(expression);
            }
            catch (DataException ex)
            {
                throw new TechnicalException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new GeneralException(ErrorMessages.GeneralError, ex);
            }
        }

        /// <summary>
        /// Añade un elemento a la base de datos.
        /// </summary>
        /// <param name="entity">Entidad que será añadida  la base de datos.</param>
        public virtual void Add(TEntity entity)
        {
            try
            {
                this.GetRepository().Add(entity);
                this.Context.Commit();
            }
            catch (DataException ex)
            {
                throw new TechnicalException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new GeneralException(ErrorMessages.GeneralError, ex);
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
                this.GetRepository().Update(entity);
                this.Context.Commit();
            }
            catch (DataException ex)
            {
                throw new TechnicalException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new GeneralException(ErrorMessages.GeneralError, ex);
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
                this.GetRepository().Delete(id);
                this.Context.Commit();
            }
            catch (DataException ex)
            {
                throw new TechnicalException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new GeneralException(ErrorMessages.GeneralError, ex);
            }
        }

        ////

        /// <summary>
        /// Obtiene la instancia del repositorio principal.
        /// </summary>
        /// <returns>Instancia del repositorio <see cref="TRepository"/>.</returns>
        protected TRepository GetRepository()
        {
            return this.Context.GetRepository<TEntity, TRepository>();
        }

        #endregion
    }
}