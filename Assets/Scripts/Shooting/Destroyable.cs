using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Destroyable : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //early exit
        if(collision.collider.gameObject.layer != LayerMask.NameToLayer("Bullet"))
        {
            return;
        }

        Debug.Log($"OnCollisionEnter Destroyable {gameObject.name} X {collision.gameObject.name}");

        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
