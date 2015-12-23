//
// Copyright Microsoft Corporation.  All rights reserved.
// ericroz - Sept 2015
//

using Microsoft.ProjectOxford.SpeechRecognition;

namespace ProviderFactory.Speech.RxToProjectOxford
{
    /// <summary>
    /// An interface for recognized phrases.
    /// </summary>
    public interface IRecognizedPhrase
    {
        /// <summary>
        /// The kind of recognized phrase.
        /// </summary>
        RecognizedPhraseKind Kind { get; }

        /// <summary>
        /// The confidence level for the recognized phrase.
        /// </summary>
        /// <remarks>
        /// This is <see cref="Confidence.None"/> for partial results.
        /// </remarks>
        Confidence Confidence { get; }

        /// <summary>
        /// The display text for the recognized phrase.
        /// </summary>
        /// <remarks>
        /// This is <value>null</value> for partial results.
        /// </remarks>
        string DisplayText { get; }

        /// <summary>
        /// The lexical form for the recognized phrase.
        /// </summary>
        string LexicalForm { get; }

        /// <summary>
        /// The inverse text normalization result.
        /// </summary>
        /// <remarks>
        /// This is <value>null</value> for partial results.
        /// </remarks>
        string InverseTextNormalizationResult { get; }

        /// <summary>
        /// The masked inverse text normalization result.
        /// </summary>
        /// <remarks>
        /// This is <value>null</value> for partial results.
        /// </remarks>
        string MaskedInverseTextNormalizationResult { get; }

        string Intent { get; set; }
    }
}
