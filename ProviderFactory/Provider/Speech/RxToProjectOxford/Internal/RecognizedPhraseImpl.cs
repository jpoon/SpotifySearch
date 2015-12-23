//
// Copyright Microsoft Corporation.  All rights reserved.
// ericroz - Sept 2015
//


using Microsoft.ProjectOxford.SpeechRecognition;

namespace ProviderFactory.Speech.RxToProjectOxford.Internal
{
    abstract class RecognizedPhraseImpl : IRecognizedPhrase
    {
        private RecognizedPhraseImpl(string lexicalForm)
        {
            LexicalForm = lexicalForm;
        }

        public string LexicalForm { get; }

        public abstract RecognizedPhraseKind Kind { get; }

        public abstract Confidence Confidence { get; }

        public abstract string DisplayText { get; }

        public abstract string InverseTextNormalizationResult { get; }

        public abstract string MaskedInverseTextNormalizationResult { get; }

        public abstract string Intent { get; set;  }

        public static IRecognizedPhrase CreateIntermediate(RecognizedPhrase phrase)
        {
            return new OxfordPhraseImpl(phrase, RecognizedPhraseKind.Intermediate);
        }

        public static IRecognizedPhrase CreateSuccess(RecognizedPhrase phrase)
        {
            return new OxfordPhraseImpl(phrase, RecognizedPhraseKind.Success);
        }

        public static IRecognizedPhrase CreatePartial(string partialResult)
        {
            return new PartialPhraseImpl(partialResult);
        }

        class OxfordPhraseImpl : RecognizedPhraseImpl
        {
            public OxfordPhraseImpl(RecognizedPhrase phrase, RecognizedPhraseKind kind)
                : base(phrase.LexicalForm)
            {
                Kind = kind;
                Confidence = phrase.Confidence;
                DisplayText = phrase.DisplayText;
                InverseTextNormalizationResult = phrase.InverseTextNormalizationResult;
                MaskedInverseTextNormalizationResult = phrase.MaskedInverseTextNormalizationResult;
            }

            public override RecognizedPhraseKind Kind { get; }

            public override Confidence Confidence { get; }

            public override string DisplayText { get; }

            public override string InverseTextNormalizationResult { get; }

            public override string MaskedInverseTextNormalizationResult { get; }

            public override string Intent { get; set; }
        }

        class PartialPhraseImpl : RecognizedPhraseImpl
        {
            public PartialPhraseImpl(string partialResult)
                : base(partialResult)
            {
            }

            public override RecognizedPhraseKind Kind => RecognizedPhraseKind.Partial;

            public override Confidence Confidence => Confidence.None;

            public override string DisplayText => null;

            public override string InverseTextNormalizationResult => null;

            public override string MaskedInverseTextNormalizationResult => null;

            public override string Intent { get; set; }
        }
    }
}
