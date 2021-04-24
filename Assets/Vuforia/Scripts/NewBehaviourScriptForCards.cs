/*==============================================================================
Copyright (c) 2019 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using System;
using UnityEngine.Video;
using UnityEngine;
/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
///
/// Changes made to this file could be overwritten when upgrading the Vuforia version.
/// When implementing custom event handler behavior, consider inheriting from this class instead.
/// </summary>
public class NewBehaviourScriptForCards : MonoBehaviour, ITrackableEventHandler
{
    #region PROTECTED_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;



    // public AudioSource asource;
    // public AudioClip aclip;

    public Animator animator;
    public Transform wolf;

    // public Transform playbtn;
    public AudioSource asource;
    public AudioClip aclip;
    public Transform canvas;


    // Animation anim;
    public static string name1;

    #endregion // PROTECTED_MEMBER_VARIABLES


    #region UNITY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        //videoplayer = GetComponent<VideoPlayer>();
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        //anim = GetComponent<Animation>();
        animator = wolf.GetComponent<Animator>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        canvas.gameObject.SetActive(false);
    }

    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName +
                  " " + mTrackableBehaviour.CurrentStatus +
                  " -- " + mTrackableBehaviour.CurrentStatusInfo);

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();

            name1 = mTrackableBehaviour.TrackableName;
            if (mTrackableBehaviour.TrackableName == "wolf")
            {
               
                animator.Play("Wolf3", -1, 0f);
                animator.speed = 1;
                asource.PlayOneShot(aclip);
            }
        
          
  

        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            OnTrackingLost();

            if (mTrackableBehaviour.TrackableName == "wolf")
            {
                animator.speed = 0;

                asource.Stop();
                // asource.Stop();
                //anim.Stop();
            }
        
         
      
        


        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
            if (mTrackableBehaviour.TrackableName == "wolf")
            {
                animator.speed = 0;
                asource.Stop();
                // asource.Stop();
                //anim.Stop();
            }
        

        }
    }


    #endregion // PUBLIC_METHODS
    public static string trackablename()
    {
        return name1;
    }


    #region PROTECTED_METHODS

    protected virtual void OnTrackingFound()
    {
        if (mTrackableBehaviour)
        {
            var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
            var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
            var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);

            // Enable rendering:
            foreach (var component in rendererComponents)
                component.enabled = true;

            // Enable colliders:
            foreach (var component in colliderComponents)
                component.enabled = true;

            // Enable canvas':
            foreach (var component in canvasComponents)
                component.enabled = true;
        }
        canvas.gameObject.SetActive(true);
    }


    protected virtual void OnTrackingLost()
    {
        if (mTrackableBehaviour)
        {
            var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
            var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
            var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);

            // Disable rendering:
            foreach (var component in rendererComponents)
                component.enabled = false;

            // Disable colliders:
            foreach (var component in colliderComponents)
                component.enabled = false;

            // Disable canvas':
            foreach (var component in canvasComponents)
                component.enabled = false;
        }
        canvas.gameObject.SetActive(false);
    
    }

    #endregion // PROTECTED_METHODS

}

