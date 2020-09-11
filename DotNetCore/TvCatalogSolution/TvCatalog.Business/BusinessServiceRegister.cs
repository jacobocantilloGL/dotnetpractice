//-----------------------------------------------------------------------
// <copyright file="BusinessServiceRegister.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>Yaakov</author>
// <date>2020-09-09 16:29:50</date>
// <summary>Código fuente clase BusinessServiceRegister.</summary>
//-----------------------------------------------------------------------
namespace TvCatalog.Business
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Gestiona el registro de los servicios de la aplicación.
    /// </summary>
    public static class BusinessServiceRegister
    {
        #region Methods And Functions

        /// <summary>
        /// Gestiona el registro de los servicios de la aplicacion.
        /// </summary>
        /// <param name="services">Colección de registros del sistema.</param>
        public static void RegisterBusinessServices(IServiceCollection services)
        {
            services.AddTransient<IShowService, ShowService>();
            services.AddTransient<IEpisodeService, EpisodeService>();
        }

        #endregion
    }
}