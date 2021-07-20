namespace ConsoleGPlayAPITool
{
    using System.Collections.Generic;
    using Google.Apis.AndroidPublisher.v3;
    using Google.Apis.AndroidPublisher.v3.Data;
    using UnityEngine;

    public static class AndroidPublisherExtensions{

        public static Track LoadTrackBranch(
            this AndroidPublisherService androidPublisherService, 
            IAndroidDistributionSettings configs,
            AppEdit edit)
        {
            var track = androidPublisherService.Edits.Tracks.Get(configs.PackageName, edit.Id, configs.TrackBranch)
                .Execute();
            Debug.Log($"Load TrackBranch:{track.TrackValue}");
            return track;
        }
        
        public static void UpdateTrackInformation(this Track track,int? versionCode, IAndroidDistributionSettings configs)
        {
            var apkVersionCodes = new List<long?> {versionCode};

            var releaseNotes = new List<LocalizedText>();
            if (!string.IsNullOrEmpty(configs.RecentChangesLang) && !string.IsNullOrEmpty(configs.RecentChangesLang))
            {
                releaseNotes.Add(new LocalizedText()
                {
                    Language = configs.RecentChangesLang,
                    Text     = configs.RecentChanges,
                });
            }
                
            var release = new TrackRelease
            {
                Name = configs.ReleaseName,
                ReleaseNotes = releaseNotes,
                Status       = configs.TrackStatus,
                VersionCodes = apkVersionCodes,
            };
            
            if (configs.TrackStatus != "completed")
                release.UserFraction = configs.UserFraction;
            
            track.Releases.Add(release);

            Debug.Log("Update Track information (Without Commit).");
        }

        
    }
}