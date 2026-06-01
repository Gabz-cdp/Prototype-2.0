using UnityEngine;
using Unity.Cinemachine;

public class CameraManager : MonoBehaviour
{
    private void OnEnable()
    {

        GameObject avatar = GameObject.FindWithTag("Player");

        if (avatar != null)
        {
            // Get the Cinemachine component
            var vcam = GetComponent<CinemachineCamera>(); 

            if (vcam != null)
            {
                // Assign the avatar transform to Follow
                vcam.Follow = avatar.transform;
            }
        }
    }
}
