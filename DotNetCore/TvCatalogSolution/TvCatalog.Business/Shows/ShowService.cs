//-----------------------------------------------------------------------
// <copyright file="ShowService.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>Yaakov</author>
// <date>2020-09-09 15:09:34</date>
// <summary>Código fuente clase ShowService.</summary>
//-----------------------------------------------------------------------
namespace TvCatalog.Business
{
    using TvCatalog.Data;
    using TvCatalog.Data.Repositories;
    using TvCatalog.Entities;

    /// <summary>
    /// Proporciona el comportamiento requerido por el servicio que
    /// gestiona los datos de la entidad <see cref="Show"/>.
    /// </summary>
    internal class ShowService : Service<Show, IShowRepository>, IShowService
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ShowService"/> class.
        /// </summary>
        /// <param name="uoW">Instancia de <see cref="IDataContext"/>.</param>
        public ShowService(IDataContext uoW)
            : base(uoW)
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functions

        #endregion
    }
}