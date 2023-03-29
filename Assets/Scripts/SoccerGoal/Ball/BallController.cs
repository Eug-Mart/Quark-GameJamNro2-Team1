using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float horizontal, vertical;
    private Vector3 target;
    [SerializeField] float force;

    private Touch myTouch;

    private Vector2 startPos;


    void Start()
    {
        horizontal = transform.position.x;
        vertical = transform.position.y;        
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Almacenar la posición del toque inicial 
            startPos = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        { 
            // Obtener la posición final del toque
            Vector2 endPos = Input.GetTouch(0).position;

            Vector2 direction = (endPos - startPos).normalized;
            float distance = Vector2.Distance(startPos, endPos);

            // Aplicar la fuerza al tiro
            //float force = Mathf.Clamp(distance * 10f, 0f, 20); // Ajusta la fuerza según tu juego
            GetComponent<Rigidbody>().AddForce(new Vector3(direction.x, direction.y, gameObject.transform.forward.z) * force, ForceMode.Impulse);
        }
    }

    // -- escribir función que calcule vector3 a partir del mouse position - global camera

    public void Shoot()
    {
        target = new Vector3(-myTouch.position.x, myTouch.position.y, 0).normalized;
        Vector3 startVector3 = new Vector3(horizontal, vertical, 0);

        //Vector3 shoot = new Vector3(target.x, target.y, 0);
        Vector3 shoot = target - startVector3;

        Debug.Log(shoot);

        //GetComponent<Rigidbody>().AddForce(shoot * force, ForceMode.Impulse);
    }
}
