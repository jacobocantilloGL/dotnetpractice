//-----------------------------------------------------------------------
// <copyright file="EfDataContext.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>Yaakov</author>
// <date>2020-09-09 11:57:57</date>
// <summary>Código fuente clase EfDataContext.</summary>
//-----------------------------------------------------------------------
namespace TvCatalog.Data.Ef
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using TvCatalog.Data.Repositories;
    using TvCatalog.Entities;

    /// <summary>
    /// Proporciona la implementación del contexto de trabajo utilizando
    /// una conexió con EF Core.
    /// </summary>
    public class EfDataContext : IDataContext
    {
        #region Attributes

        /// <summary>
        /// Contiene el listado de repositorios gestionador or UOW. 
        /// </summary>
        private readonly IServiceCollection _repositoryServices;

        /// <summary>
        /// Contexto de conexión con la base de datos.
        /// </summary>
        private readonly EfDbContext _dbContext;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EfDataContext"/> class.
        /// </summary>
        /// <param name="context">Contexto de conexión a la base de dato susando EF Core.</param>
        public EfDataContext(EfDbContext context)
        {
            this._dbContext = context;
            this._repositoryServices = new ServiceCollection();
            this.CreateRepositories();
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Obtiene obtiene un repositorio que gestione al tipo de dato dado.
        /// </summary>
        /// <typeparam name="T">Tipo de dato gestionado por el repositorio.</typeparam>
        /// <typeparam name="U">Repositorio que gestiona el tipo de datos.</typeparam>
        /// <returns>Instancia del repositorio.</returns>
        public U GetRepository<T, U>()
            where T : BaseEntity, new()
            where U : IRepository<T>
        {
            IServiceProvider provider = this._repositoryServices.BuildServiceProvider();
            return provider.GetService<U>();
        }

        /// <summary>
        /// Gestiona el registro de todos los cambios en la base de datos.
        /// </summary>
        public void Commit()
        {
            try
            {
                this._dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Gestiona la liberación de recursos manejados.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        ////

        /// <summary>
        /// Gestiona la liberación de recursos manejados.
        /// </summary>
        /// <param name="disposed">True para liberar recursos, false en caso contario.</param>
        protected void Dispose(bool disposed)
        {
            if (disposed)
            {
                this._dbContext.Dispose();
            }
        }

        ////

        /// <summary>
        /// Gestiona el registro de todos los repositorios.
        /// </summary>
        private void CreateRepositories()
        {
            this.RegisterRepository<Show, IShowRepository>(new EfShowRepository(this._dbContext));
            this.RegisterRepository<Episode, IEpisodeRepository>(new EfEpisodeRepository(this._dbContext));
        }

        /// <summary>
        /// Gestiona el registro de las instancias de repositorios gestionados por el UOW.
        /// </summary>
        /// <typeparam name="T">Tipo de dato gestionado por el repositorio.</typeparam>
        /// <typeparam name="U">Repositorio que gestiona el tipo de datos.</typeparam>
        /// <param name="repository">Instancia del repositorio de tipo <typeparamref name="U"/>.</param>
        private void RegisterRepository<T, U>(U repository)
            where T : BaseEntity, new()
            where U : class, IRepository<T>
        {
            this._repositoryServices.AddSingleton<U>(x => repository);

        }

        #endregion
    }
}