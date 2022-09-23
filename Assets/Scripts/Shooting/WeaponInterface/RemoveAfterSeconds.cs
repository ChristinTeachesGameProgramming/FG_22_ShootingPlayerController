using UnityEngine;

public class RemoveAfterTime : MonoBehaviour
{
    public void Init(float time)
    {
        Invoke("Destroy", time);
    }
}