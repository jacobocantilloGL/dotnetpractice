//-----------------------------------------------------------------------
// <copyright file="EpisodeService.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>Yaakov</author>
// <date>2020-09-09 16:24:21</date>
// <summary>Código fuente clase EpisodeService.</summary>
//-----------------------------------------------------------------------
namespace TvCatalog.Business
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TvCatalog.Common;
    using TvCatalog.Data;
    using TvCatalog.Data.Repositories;
    using TvCatalog.Entities;

    /// <summary>
    /// EpisodeService class.
    /// </summary>
    internal class EpisodeService : Service<Episode, IEpisodeRepository>, IEpisodeService
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EpisodeService"/> class.
        /// </summary>
        /// <param name="uoW">Instancia de <see cref="IDataContext"/>.</param>
        public EpisodeService(IDataContext uoW)
            : base(uoW)
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
                return await this.GetRepository().GetByShowIdAsync(showId);
            }
            catch (GeneralException ex)
            {
                throw new TechnicalException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new GeneralException(ErrorMessages.GeneralError, ex);
            }
        }

        #endregion
    }
}