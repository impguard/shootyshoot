using UnityEngine;

public class Util
{
    public static CameraController GetCameraController()
    {
        return Camera.main.GetComponent<CameraController>();
    }
}