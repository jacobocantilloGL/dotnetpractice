//-----------------------------------------------------------------------
// <copyright file="BaseEntity.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>Yaakov</author>
// <date>2020-09-11 09:14:12</date>
// <summary>Código fuente clase BaseEntity.</summary>
//-----------------------------------------------------------------------
namespace TvCatalog.Entities
{
    /// <summary>
    /// Define la clase base de las entidades del sistema.
    /// </summary>
    public abstract class BaseEntity
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntity"/> class.
        /// </summary>
        public BaseEntity()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets el id de la entidad.
        /// </summary>
        /// <value>Id de la entidad.</value>
        public int Id { get; set; }

        #endregion

        #region Methods And Functions

        #endregion
    }
}