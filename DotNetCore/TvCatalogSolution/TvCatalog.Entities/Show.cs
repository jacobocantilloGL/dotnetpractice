//-----------------------------------------------------------------------
// <copyright file="Show.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>Yaakov</author>
// <date>2020-09-08 15:19:50</date>
// <summary>Código fuente clase Show.</summary>
//-----------------------------------------------------------------------
namespace TvCatalog.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// Define la estructura básica.
    /// </summary>
    public class Show : BaseEntity
    {
        #region Attributes

        #endregion

        #region Constructors

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets el nombre del show.
        /// </summary>
        /// <value>Nombre del show.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets el resumen del show.
        /// </summary>
        /// <value>Resumen del show.</value>
        public string Sumary { get; set; }

        /// <summary>
        /// Gets or sets el casting del show.
        /// </summary>
        /// <value>Casting del show.</value>
        public string Cast { get; set; }

        ////

        /// <summary>
        /// Gets or sets el listado de episodios.
        /// </summary>
        /// <value>Listado de episodios.</value>
        public ICollection<Episode> Episodes { get; set; }

        #endregion

        #region Methods And Functions

        #endregion
    }
}