using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Force : MonoBehaviour
{
    // RigidBody Component
    [SerializeField]private Rigidbody2D _ball;
    // Force value
    [SerializeField]private float _force = 0f;
    // ArrowRotation variable
    [SerializeField]private ArrowRotation _rotation;
    public Image arrowSprite2;
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
        ForceControl();
    }

    // Applicating force in the Rigidbody object
    void ForceAplication()
    {
        float x = _force * Mathf.Cos(_rotation.zRotation * Mathf.Deg2Rad);
        float y = _force * Mathf.Sin(_rotation.zRotation * Mathf.Deg2Rad);

        if(_rotation.ForceLiberation)
        {
            _ball.AddForce(new Vector2(x,y)); 
            _rotation.ForceLiberation = false;
        }
    }

    void ForceControl()
    {
        if(_rotation.RotationLiberation)
        {
            float xMove = Input.GetAxis ("Mouse X");
            if(xMove < 0)
            {
                arrowSprite2.fillAmount += 1 * Time.deltaTime;
                _force = arrowSprite2.fillAmount * 1000;
            }

            if(xMove > 0)
            {
                arrowSprite2.fillAmount -= 1 * Time.deltaTime;
                _force = arrowSprite2.fillAmount * 1000;
            }
        }
    }
}
