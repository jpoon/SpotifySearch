//
// Copyright Microsoft Corporation.  All rights reserved.
// ericroz - Sept 2015
//

using System;
using System.Runtime.Serialization;

namespace ProviderFactory.Speech.RxToProjectOxford.Exceptions
{
    /// <summary>
    /// Exception for speech recognition timeouts.
    /// </summary>
    [Serializable]
    public class SpeechTimeoutException : Exception
    {
        /// <summary>
        /// Default constructor for <see cref="SpeechTimeoutException"/>.
        /// </summary>
        public SpeechTimeoutException() { }

        /// <summary>
        /// Message constructor for <see cref="SpeechTimeoutException"/>.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public SpeechTimeoutException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Message and inner exception constructor for <see cref="SpeechTimeoutException"/>.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        public SpeechTimeoutException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Serialization context constructor for <see cref="SpeechTimeoutException"/>.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The serialization context.</param>
        protected SpeechTimeoutException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
