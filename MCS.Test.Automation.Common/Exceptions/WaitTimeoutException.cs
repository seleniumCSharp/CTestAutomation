﻿// <copyright file="WaitTimeoutException.cs" company="MCS">
// Copyright (c) MCS. All rights reserved.
// </copyright>
namespace MCS.Test.Automation.Common.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The exception that is thrown when the time for a process or operation has expired.
    /// </summary>
    public class WaitTimeoutException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WaitTimeoutException"/> class.
        /// </summary>
        public WaitTimeoutException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WaitTimeoutException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public WaitTimeoutException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WaitTimeoutException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public WaitTimeoutException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WaitTimeoutException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected WaitTimeoutException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
