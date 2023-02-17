using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFollow : MonoBehaviour
{
    [SerializeField] private float thrust = 150f;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float wallDistance = 5f;
    [SerializeField] private float minCamDistance = 3f;

    private Vector2 lastMousePos;
    

    // Update is called once per frame
    void Update()
    {
        Vector2 deltaPos = Vector2.zero;

        if(Input.GetMouseButton(0))
        {
            GameManager.singleton.StartGame();
            Vector2 currentMousePos = Input.mousePosition;

            if (lastMousePos == Vector2.zero)
                lastMousePos = currentMousePos;

            deltaPos = currentMousePos - lastMousePos;
            lastMousePos = currentMousePos;

            Vector3 force = new Vector3(deltaPos.x, 0, deltaPos.y) * thrust;
            rb.AddForce(force);
        }

        else
        {
            lastMousePos = Vector2.zero;
        }    
    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;

        if(transform.position.x < -wallDistance)
        {
            pos.x = -wallDistance;
        }

        else if (transform.position.x > wallDistance)
        {
            pos.x = wallDistance;
        }

        if(transform.position.z < Camera.main.transform.position.z + minCamDistance)
        {
            pos.z = Camera.main.transform.position.z + minCamDistance;
        }

        transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.singleton.GameEnded)
            return;

        if(collision.gameObject.tag == "BadGuy")
        {
            GameManager.singleton.EndGame(false);
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.singleton.GameEnded)
            return;
        if(GameManager.singleton.GameStarted)
        {
            rb.MovePosition(transform.position + Vector3.forward * 3 * Time.fixedDeltaTime);
        }
    }
}
