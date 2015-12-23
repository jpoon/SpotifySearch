//
// Copyright Microsoft Corporation.  All rights reserved.
// ericroz - Sept 2015
//

using System;
using System.Runtime.Serialization;

namespace ProviderFactory.Speech.RxToProjectOxford.Exceptions
{
    /// <summary>
    /// Exception thrown when timeout period exceeded for background noise.
    /// </summary>
    [Serializable]
    public class BabbleTimeoutException : SpeechTimeoutException
    {
        /// <summary>
        /// Default constructor for <see cref="BabbleTimeoutException"/>.
        /// </summary>
        public BabbleTimeoutException() { }

        /// <summary>
        /// Message constructor for <see cref="BabbleTimeoutException"/>.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public BabbleTimeoutException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Message and inner exception constructor for <see cref="BabbleTimeoutException"/>.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        public BabbleTimeoutException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Serialization context constructor for <see cref="BabbleTimeoutException"/>.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The serialization context.</param>
        protected BabbleTimeoutException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
