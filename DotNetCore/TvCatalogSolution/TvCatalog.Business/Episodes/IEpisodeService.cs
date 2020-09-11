//-----------------------------------------------------------------------
// <copyright file="IEpisodeService.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>Yaakov</author>
// <date>2020-09-09 16:24:10</date>
// <summary>Código fuente clase IEpisodeService.</summary>
//-----------------------------------------------------------------------
namespace TvCatalog.Business
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TvCatalog.Data.Repositories;
    using TvCatalog.Entities;

    /// <summary>
    /// IEpisodeService interface.
    /// </summary>
    public interface IEpisodeService : IService<Episode, IEpisodeRepository>
    {
        /// <summary>
        /// Gestiona la consulta de los episodios asociados al id del show dado.
        /// </summary>
        /// <param name="showId">Id del show.</param>
        /// <returns>Colección de episodios asociados al show dado.</returns>
        Task<ICollection<Episode>> GetByShowIdAsync(int showId);
    }
}