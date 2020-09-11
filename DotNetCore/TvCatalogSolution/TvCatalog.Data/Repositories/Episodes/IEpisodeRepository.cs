//-----------------------------------------------------------------------
// <copyright file="IEpisodeRepository.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>Yaakov</author>
// <date>2020-09-09 11:24:56</date>
// <summary>Código fuente clase IEpisodeRepository.</summary>
//-----------------------------------------------------------------------
namespace TvCatalog.Data.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TvCatalog.Entities;

    /// <summary>
    /// Define el comportamiento base del repositorio de las entidades de tipo <see cref="Episode"/>.
    /// </summary>
    public interface IEpisodeRepository : IRepository<Episode>
    {
        /// <summary>
        /// Gestiona la consulta de los episodios asociados al id del show dado.
        /// </summary>
        /// <param name="showId">Id del show.</param>
        /// <returns>Colección de episodios asociados al show dado.</returns>
        Task<ICollection<Episode>> GetByShowIdAsync(int showId);
    }
}