using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Collider))]
public class TowerDown : MonoBehaviour
{
    public Transform fromDownPos;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            other.transform.position = fromDownPos.position;
            Tower.GoDown();
        }
    }
}
