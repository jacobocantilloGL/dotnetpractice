//-----------------------------------------------------------------------
// <copyright file="EfEpisodeRepository.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>Yaakov</author>
// <date>2020-09-09 11:32:31</date>
// <summary>Código fuente clase EfEpisodeRepository.</summary>
//-----------------------------------------------------------------------
namespace TvCatalog.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TvCatalog.Data.Ef;
    using TvCatalog.Entities;

    /// <summary>
    /// Proporciona la implementación básica del repositorio EF Core de la entidad <see cref="Show"/>.
    /// </summary>
    internal class EfEpisodeRepository : EfRepository<Episode>, IEpisodeRepository
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EfEpisodeRepository"/> class.
        /// </summary>
        /// <param name="context">Contexto de conexión a la base de dato susando EF Core.</param>
        public EfEpisodeRepository(EfDbContext context)
            : base(context)
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Gestiona la consulta de los episodios asociados al id del show dado.
        /// </summary>
        /// <param name="showId">Id del show.</param>
        /// <returns>Colección de episodios asociados al show dado.</returns>
        public async Task<ICollection<Episode>> GetByShowIdAsync(int showId)
        {
            try
            {
                return await this.GetAllByAsync(x => x.ShowId == showId);
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, ex);
            }
        }

        #endregion
    }
}