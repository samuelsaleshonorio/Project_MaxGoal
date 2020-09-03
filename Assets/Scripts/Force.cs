using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Force : MonoBehaviour
{
    // RigidBody Component
    private Rigidbody2D _ball;
    // Force value
    private float _force = 1000f;
    // ArrowRotation variable
    private ArrowRotation _rotation;
    // Start is called before the first frame update
    void Start()
    {
        _ball = GetComponent<Rigidbody2D>();
        _rotation = GetComponent<ArrowRotation>();
    }

    // Update is called once per frame
    void Update()
    {
        ForceAplication();
    }

    // Applicating force in the Rigidbody object
    void ForceAplication()
    {
        float x = _force * Mathf.Cos(_rotation.zRotation * Mathf.Deg2Rad);
        float y = _force * Mathf.Sin(_rotation.zRotation * Mathf.Deg2Rad);

        if(Input.GetKeyUp(KeyCode.Space))
        {
            _ball.AddForce(new Vector2(x,y)); 
        }
    }
}
