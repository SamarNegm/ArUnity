using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif
public class PermissionRequest : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
#if PLATFORM_ANDROID
        //if (Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        //{
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        //}
#endif

    }





}
