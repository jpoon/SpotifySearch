[![Build status](https://ci.appveyor.com/api/projects/status/c9rg0o0tyq3prqwa/branch/master?svg=true)](https://ci.appveyor.com/project/jpoon/spotifysearch/branch/master)

# SpotifySearch

Use natural language commands to play music from Spotify. A sample application powered by [Project Oxford Speech APIs](https://www.projectoxford.ai/) and [Project Oxford LUIS](https://www.projectoxford.ai/luis).

![Screenshot](/images/spotify_search.gif)

## Installation/Setup

1. Fork and clone the repo
2. Create a subscription for [Project Oxford Speech APIs](https://www.projectoxford.ai/Account/Login?callbackUrl=/Subscription/Index?productId=/products/54f0354049c3f70a50e79b7e). The [main dashboard](https://www.projectoxford.ai/Subscription) will show the primary key that will be needed to configure the `SpotifySearch` application.
3. Login to [Project LUIS](https://www.luis.ai/) and **import an existing application** using the following [this](https://github.com/jpoon/SpotifySearch/blob/master/Luis/SpotifySearch.json). Once imported, train the model, and publish the web service. The web service URL will look like this: `https://api.projectoxford.ai/luis/v1/application?id=[LUIS-APP-ID]&subscription-key=[LUIS-SUBSCRIPTION-ID]&q=`. The `[LUIS-APP-ID]` and `[LUIS-SUBSCRIPTION-ID]` will be used to configure the `SpotifySearch` application.
4. Update the web.config of the `SpotifySearch` project with your own keys obtained through steps 2 and 3 above.

    ```
    <add key="luisAppId" value="" />
    <add key="luisSubscriptionId" value=""/>
    <add key="oxfordSpeechSubscriptionId" value=""/>
    ```

5. Run and say some commands/utterances like: "I want to listen to Ellie Goulding's Lights".

## How

All is explained in the case study [here](https://www.microsoft.com/developerblog/real-life-code/2015/12/16/Speech-Intent-with-Project-Luis.html).

## License

Copyright (c) Microsoft Corporation, licensed under [The MIT License (MIT)](https://raw.githubusercontent.com/jpoon/SpotifySearch/master/LICENSE).
