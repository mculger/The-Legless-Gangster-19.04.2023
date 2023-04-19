using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 offSet; //karakterin neresine g�re hareket etti�imizi belirlicek.
    public Transform player;


    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offSet, moveSpeed * Time.deltaTime);//bir pozisyonu a noktas�ndan b noktas�na belli bir s�reyle lerpleyebiliriz.



    }

}
