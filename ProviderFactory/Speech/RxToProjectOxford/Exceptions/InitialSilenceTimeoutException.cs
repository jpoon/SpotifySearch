//
// Copyright Microsoft Corporation.  All rights reserved.
// ericroz - Sept 2015
//

using System;
using System.Runtime.Serialization;

namespace ProviderFactory.Speech.RxToProjectOxford.Exceptions
{
    /// <summary>
    /// Exception thrown when initial silence in the audio exceeded the maximum limit.
    /// </summary>
    [Serializable]
    public class InitialSilenceTimeoutException : SpeechTimeoutException
    {
        /// <summary>
        /// Default constructor for <see cref="InitialSilenceTimeoutException"/>.
        /// </summary>
        public InitialSilenceTimeoutException() { }

        /// <summary>
        /// Message constructor for <see cref="InitialSilenceTimeoutException"/>.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public InitialSilenceTimeoutException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Message and inner exception constructor for <see cref="InitialSilenceTimeoutException"/>.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        public InitialSilenceTimeoutException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Serialization context constructor for <see cref="InitialSilenceTimeoutException"/>.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The serialization context.</param>
        protected InitialSilenceTimeoutException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
