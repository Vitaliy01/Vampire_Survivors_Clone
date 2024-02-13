using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchWeapon : MonoBehaviour
{
    public float rotateSpeed;

    public Transform holder;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        holder.rotation = Quaternion.Euler(0f, 0f, holder.rotation.eulerAngles.z + (rotateSpeed * Time.deltaTime));
    }
}
