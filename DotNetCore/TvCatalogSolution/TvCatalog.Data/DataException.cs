﻿//-----------------------------------------------------------------------
// <copyright file="DataException.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>Yaakov</author>
// <date>2020-09-11 09:05:33</date>
// <summary>Código fuente clase DataException.</summary>
//-----------------------------------------------------------------------
namespace TvCatalog.Data
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Define la base para las excepciones de tipo de datos.
    /// </summary>
    public class DataException : Exception
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataException"/> class.
        /// </summary>
        public DataException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the System.Exception class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public DataException(string? message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the System.Exception class with a specified error message and a reference
        /// to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null
        /// reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public DataException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the System.Exception class with serialized data.
        /// </summary>
        /// <param name="info">The System.Runtime.Serialization.SerializationInfo that holds the serialized
        /// object data about the exception being thrown.</param>
        /// <param name="context">The System.Runtime.Serialization.StreamingContext that contains contextual
        /// information about the source or destination.</param>
        protected DataException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functions

        #endregion
    }
}