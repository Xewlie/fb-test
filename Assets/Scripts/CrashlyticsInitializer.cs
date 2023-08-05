using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Analytics;
using Firebase.Crashlytics;

public class CrashlyticsInitializer : MonoBehaviour
{
    private void Awake()
    {
        CheckForDependencies();
    } 

    private void CheckForDependencies()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => 
        {
            DependencyStatus dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                Debug.Log("Firebase dependencies are available.");
                InitializeFirebase();
            }
            else
            {
                Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}");
            }
        });
    }

    protected virtual void InitializeFirebase()
    {
        FirebaseApp app = FirebaseApp.DefaultInstance;

        if(app != null)
        {
            Debug.Log("Firebase initialized successfully.");

            // Initialize Crashlytics
            Crashlytics.SetUserId(app.Options.ProjectId);

            if(Crashlytics.IsCrashlyticsCollectionEnabled)
            {
                Debug.Log("Crashlytics has been enabled.");
            }
            else
            {
                Debug.LogError("Couldn't enable Crashlytics.");
            }
            
            // Log an event for Firebase Analytics
            FirebaseAnalytics.LogEvent("Firebase_initialized", "Firebase", "Firebase and Crashlytics initialized successfully"); 
        }
        else
        {
            Debug.LogError("Failed to initialize Firebase.");
        }
    }
}