using UnityEngine;

public static class MousePosition
{
    public static Vector3 GetMousePosInWorldSpace(){
        Vector3 screenPosition = Input.mousePosition;
        screenPosition.z = Camera.main.nearClipPlane + 1;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    } 
}
