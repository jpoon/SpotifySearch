//
// Copyright Microsoft Corporation.  All rights reserved.
// ericroz - Sept 2015
//

namespace ProviderFactory.Speech.RxToProjectOxford
{
    /// <summary>
    /// Kinds of recognized phrases returned in the response observable.
    /// </summary>
    public enum RecognizedPhraseKind
    {
        /// <summary>
        /// A partial recognized phrase.
        /// </summary>
        Partial,

        /// <summary>
        /// An intermediate recognized phrase.
        /// </summary>
        Intermediate,

        /// <summary>
        /// A successfully recognized phrase.
        /// </summary>
        Success,
    }
}
