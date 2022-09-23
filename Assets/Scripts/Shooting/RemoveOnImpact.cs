using UnityEngine;

public class RemoveOnImpact : MonoBehaviour
{
    private void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.layer == gameObject.layer)
        {
            return;
        }

        Debug.Log($"OnCollisionEnter RemoveOnImpact {gameObject.name} X {collision.gameObject.name}");

        gameObject.GetComponent<Rigidbody>().Sleep();
        Invoke("DestroyMe", 0.2f);
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}
