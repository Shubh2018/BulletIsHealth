using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        Vector3 moveInput = new Vector3(hInput, 0.0f, vInput).normalized;

        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
        {
            Vector3 lookDirection = hitInfo.point;
            lookDirection.y = this.transform.position.y;

            transform.LookAt(lookDirection);

            if(moveInput.magnitude > 0.1f)
            {
                transform.Translate(moveInput * speed * Time.deltaTime);
            }
        }
    }
}
