//-----------------------------------------------------------------------
// <copyright file="IDataContext.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>Yaakov</author>
// <date>2020-09-09 11:54:55</date>
// <summary>Código fuente clase IDataContext.</summary>
//-----------------------------------------------------------------------
namespace TvCatalog.Data
{
    using System;
    using TvCatalog.Entities;

    /// <summary>
    /// Define el contexto de trabajo para gestionar de forma unificada de los repositorios.
    /// </summary>
    public interface IDataContext : IDisposable
    {
        /// <summary>
        /// Obtiene obtiene un repositorio que gestione al tipo de dato dado.
        /// </summary>
        /// <typeparam name="T">Tipo de dato gestionado por el repositorio.</typeparam>
        /// <typeparam name="U">Repositorio que gestiona el tipo de datos.</typeparam>
        /// <returns>Instancia del repositorio.</returns>
        U GetRepository<T, U>()
            where T : BaseEntity, new()
            where U : IRepository<T>;

        /// <summary>
        /// Gestiona el registro de todos los cambios en la base de datos.
        /// </summary>
        void Commit();
    }
}