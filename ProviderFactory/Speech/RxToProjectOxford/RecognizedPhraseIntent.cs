//
// Copyright Microsoft Corporation.  All rights reserved.
// ericroz - Sept 2015
//


using System.Collections.Generic;

namespace ProviderFactory.Speech.RxToProjectOxford
{
    /// <summary>
    /// Kinds of recognized phrases returned in the response observable.
    /// </summary>
    public class RecognizedPhraseIntent
    {
        public string Query;
        public IEnumerable<LuisIntent> Intents;
        public IEnumerable<LuisEntity> Entities;
    }

    public class LuisIntent
    {
        public string Intent;
        public float Score;

    }

    public class LuisEntity
    {
        public string Entity;
        public string Type;
        public float Score;
    }
}
