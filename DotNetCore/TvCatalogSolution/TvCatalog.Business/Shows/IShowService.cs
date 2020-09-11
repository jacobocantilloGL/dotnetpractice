//-----------------------------------------------------------------------
// <copyright file="IShowService.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>Yaakov</author>
// <date>2020-09-09 16:14:04</date>
// <summary>Código fuente clase IShowService.</summary>
//-----------------------------------------------------------------------
namespace TvCatalog.Business
{
    using TvCatalog.Data.Repositories;
    using TvCatalog.Entities;

    /// <summary>
    /// IShowService interface.
    /// </summary>
    public interface IShowService : IService<Show, IShowRepository>
    {
    }
}