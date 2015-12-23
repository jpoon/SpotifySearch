//
// Copyright Microsoft Corporation.  All rights reserved.
// ericroz - Sept 2015
//

using System;
using System.Runtime.Serialization;

namespace ProviderFactory.Speech.RxToProjectOxford.Exceptions
{
    /// <summary>
    /// Exception throw when end of dictation silence timeout occurs.
    /// </summary>
    [Serializable]
    public class DictationEndTimeoutException : SpeechTimeoutException
    {
        /// <summary>
        /// Default constructor for <see cref="DictationEndTimeoutException"/>.
        /// </summary>
        public DictationEndTimeoutException() { }

        /// <summary>
        /// Message constructor for <see cref="DictationEndTimeoutException"/>.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public DictationEndTimeoutException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Message and inner exception constructor for <see cref="DictationEndTimeoutException"/>.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        public DictationEndTimeoutException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Serialization context constructor for <see cref="DictationEndTimeoutException"/>.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The serialization context.</param>
        protected DictationEndTimeoutException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
