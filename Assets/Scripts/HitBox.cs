using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitBox : MonoBehaviour
{
    public UnityAction<int> HungerAdded;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<BulletController>(out BulletController _bullet))
        {
            HungerAdded?.Invoke(_bullet.HungerValue);
            Destroy(_bullet.gameObject);
        }
    }
}
