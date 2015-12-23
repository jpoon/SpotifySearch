//
// Copyright Microsoft Corporation.  All rights reserved.
// ericroz - Sept 2015
//

using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace ProviderFactory.Speech.RxToProjectOxford.Exceptions
{
    /// <summary>
    /// Exception thrown when a speech recognition error occurs.
    /// </summary>
    [Serializable]
    public class SpeechRecognitionException : Exception
    {
        /// <summary>
        /// Default constructor for <see cref="SpeechRecognitionException"/>.
        /// </summary>
        public SpeechRecognitionException() { }

        /// <summary>
        /// Initializes the <see cref="SpeechRecognitionException"/> with an error code and text.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorText">The error text.</param>
        public SpeechRecognitionException(int errorCode, string errorText)
            : this(CreateMessage(errorCode, errorText))
        {
            ErrorCode = errorCode;
            ErrorText = errorText;
        }

        /// <summary>
        /// Message constructor for <see cref="SpeechRecognitionException"/>.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public SpeechRecognitionException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Message and inner exception constructor for <see cref="SpeechRecognitionException"/>.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        public SpeechRecognitionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Serialization context constructor for <see cref="SpeechRecognitionException"/>.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The serialization context.</param>
        protected SpeechRecognitionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// The error code.
        /// </summary>
        public int ErrorCode { get; }

        /// <summary>
        /// The error text.
        /// </summary>
        public string ErrorText { get; }

        /// <summary>
        /// Gets the object data for the exception.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The serialization context.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        private static string CreateMessage(int errorCode, string errorText)
        {
            return string.Format(CultureInfo.InvariantCulture, "Speech recognition failed with error code '{0}' with message '{1}'.", errorCode, errorText);
        }
    }
}
