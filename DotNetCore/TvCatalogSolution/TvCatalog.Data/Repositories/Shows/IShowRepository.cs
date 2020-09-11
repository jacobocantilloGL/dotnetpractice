//-----------------------------------------------------------------------
// <copyright file="IShowRepository.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>Yaakov</author>
// <date>2020-09-09 11:23:31</date>
// <summary>Código fuente clase IShowRepository.</summary>
//-----------------------------------------------------------------------
namespace TvCatalog.Data.Repositories
{
    using TvCatalog.Entities;

    /// <summary>
    /// Define el comportamiento base del repositorio de las entidades de tipo <see cref="Show"/>.
    /// </summary>
    public interface IShowRepository : IRepository<Show>
    {
    }
}