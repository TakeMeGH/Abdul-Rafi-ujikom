using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXPlayer : MonoBehaviour
{
    public static VFXPlayer Instance;
    [SerializeField] AudioSource AudioSource;
    private void Awake()
    {
        Instance = this;
    }

    void PlayVFX(Vector3 pos)
    {

    }

    public void PlaySFX()
    {
        AudioSource.Play();
    }

}
