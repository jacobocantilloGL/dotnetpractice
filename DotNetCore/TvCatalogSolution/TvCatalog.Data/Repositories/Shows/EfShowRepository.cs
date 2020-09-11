//-----------------------------------------------------------------------
// <copyright file="EfShowRepository.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>Yaakov</author>
// <date>2020-09-09 11:30:17</date>
// <summary>Código fuente clase EfShowRepository.</summary>
//-----------------------------------------------------------------------
namespace TvCatalog.Data.Repositories
{
    using TvCatalog.Data.Ef;
    using TvCatalog.Entities;

    /// <summary>
    /// Proporciona la implementación básica del repositorio EF Core de la entidad <see cref="Show"/>.
    /// </summary>
    internal class EfShowRepository : EfRepository<Show>, IShowRepository
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EfShowRepository"/> class.
        /// </summary>
        /// <param name="context">Contexto de conexión a la base de dato susando EF Core.</param>
        public EfShowRepository(EfDbContext context)
            : base(context)
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functions

        #endregion
    }
}