[![Build status](https://ci.appveyor.com/api/projects/status/c9rg0o0tyq3prqwa/branch/master?svg=true)](https://ci.appveyor.com/project/jpoon/spotifysearch/branch/master)

# SpotifySearch

Use natural language commands to play music from Spotify. A sample application powered by [Project Oxford Speech APIs](https://www.projectoxford.ai/) and [Project Oxford LUIS](https://www.projectoxford.ai/luis).

![Screenshot](/images/spotify_search.gif)

## Installation/Setup

1. Fork and clone the repo
2. Create a [Project Oxford Speech APIs subscription](https://www.projectoxford.ai/Account/Login?callbackUrl=/Subscription/Index?productId=/products/54f0354049c3f70a50e79b7e). You can manage your Oxford subscriptions [here](https://www.projectoxford.ai/Subscription); the main dashboard shows the primary and secondary keys that will be needed in the SDKs.
3. Create a [Project LUIS application](https://www.luis.ai/) and import [this model](https://github.com/jpoon/SpotifySearch/blob/master/Luis/SpotifySearch.json)
4. Update the web.config of the `SpotifySearch` project with your own keys obtained through steps 2 and 3 above.
    ```
    <add key="luisAppId" value="" />
    <add key="luisSubscriptionId" value=""/>
    <add key="oxfordSpeechSubscriptionId" value=""/>
    ```

5. Run and say some commands like: "I want to listen to Ellie Goulding's Lights".

## How

All is explained in the case study [here](http://catalystcode.github.io/case-studies/2015/12/16/Speech-Intent-with-Project-Luis.html).

## License

Copyright (c) Microsoft Corporation, licensed under [The MIT License (MIT)](https://raw.githubusercontent.com/jpoon/SpotifySearch/master/LICENSE).
