//-----------------------------------------------------------------------
// <copyright file="Episode.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>Yaakov</author>
// <date>2020-09-08 15:02:56</date>
// <summary>Código fuente clase Episode.</summary>
//-----------------------------------------------------------------------
namespace TvCatalog.Entities
{
    /// <summary>
    /// Define la estructura de un episodio.
    /// </summary>
    public class Episode : BaseEntity
    {
        #region Attributes

        #endregion

        #region Constructors

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets el nombre del episodio.
        /// </summary>
        /// <value>Nombre del episodio.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets el resumen del capitulo.
        /// </summary>
        /// <value>Resumen de capítulo.</value>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets la duración en segundos del episodio.
        /// </summary>
        /// <value>Duración del episodio.</value>
        public int Duration { get; set; }

        ////

        /// <summary>
        /// Gets or sets el id del show al cual pertenece.
        /// </summary>
        /// <value>Id del show asociado al episodio.</value>
        public int ShowId { get; set; }

        /// <summary>
        /// Gets or sets datos del show al cual pertecene.
        /// </summary>
        /// <value>Datos del show al cual petenece el episodio.</value>
        public Show Show { get; set; }

        #endregion

        #region Methods And Functions

        #endregion
    }
}