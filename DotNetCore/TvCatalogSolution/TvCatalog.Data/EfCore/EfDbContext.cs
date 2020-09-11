//-----------------------------------------------------------------------
// <copyright file="EfDbContext.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>Yaakov</author>
// <date>2020-09-08 15:53:30</date>
// <summary>Código fuente clase EfDbContext.</summary>
//-----------------------------------------------------------------------
namespace TvCatalog.Data.Ef
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using TvCatalog.Entities;

    /// <summary>
    /// Define el contexto de conexión con la base de datos.
    /// </summary>
    public class EfDbContext : DbContext
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EfDbContext"/> class.
        /// </summary>
        /// <param name="options">Opciones de contexto.</param>
        public EfDbContext(DbContextOptions options)
            : base(options)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Gets or sets los shows registrados en el sistema.
        /// </summary>
        /// <value>Shows del sistema.</value>
        public DbSet<Show> Shows { get; set; }

        /// <summary>
        /// Gets or sets los episodios del sistema.
        /// </summary>
        /// <value>Episodios del sistema.</value>
        public DbSet<Episode> Episodes { get; set; }

        #endregion
    }
}