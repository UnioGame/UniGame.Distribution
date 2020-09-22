# UniGame.Distribution

Tools for distribute your game into store from Unity3D Editor

## Supported platforms & Features

### Platforms

Right now support only *Google Play Store*

## Upload to Google Play Store

Editor Distribution Window

![](https://github.com/UniGameTeam/UniGame.Distribution/blob/master/GitAssets/distribution1.png)

- Package Name: 

![](https://github.com/UniGameTeam/UniGame.Distribution/blob/master/GitAssets/distribution2.png)

- Json Path: Path to your Google Service account Api key json file linked with project. (https://developers.google.com/android-publisher)
- Artifact Path: Build Atrifact location. APK or AAB (App Bundle) file. Expansion files supported only for APK
- RecentChangedLang: PatchNotes language
- Recent Changes Text: PatchNotes 
- TrackBranch: [Track API](https://developers.google.com/android-publisher/tracks). Supported options: 

```
"internal", "alpha", "beta", "production"
```

- ReleaseName: Name of your release version at Google Play Store.
- TrackStatus: [Track Status Info](https://developers.google.com/android-publisher/tracks#apk_workflow_example)
- UserFraction: percent of your users that your publish for the update

UniGame.Distribution references: 

- [Google Publishing API for .NET](https://developers.google.com/api-client-library/dotnet/apis/playcustomapp/v1)


## Publishing With CI Builds

Auto publishing command can be used with:
1. Scriptable Build Pipeline for unity [Build Pipeline](https://github.com/UniGameTeam/UniBuild)
2. Additional Build Pipeline Commands [Build Commands](https://github.com/UniGameTeam/UniBuild.Commands) (contains Google Play Distribution)
