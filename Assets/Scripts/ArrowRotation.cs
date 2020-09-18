using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowRotation : MonoBehaviour
{
    // Defining initial position
    [SerializeField]private Transform initialPosition;
    // Arrow sprite control
    [SerializeField]private Image arrowSprite;
    // Angle
    public float zRotation;
    public bool RotationLiberation = false;
    public bool ForceLiberation = false;
    // Start is called before the first frame update
    void Start()
    {
        PositionArrow();
        PositionBall();
    }

    // Update is called once per frame
    void Update()
    {
        ArrowsRotation();
        InputRotation();
        LimitedRotation();
    }

    void PositionArrow()
    {
        arrowSprite.rectTransform.position = initialPosition.position;
    }

    void PositionBall()
    {
        this.gameObject.transform.position = initialPosition.position;
    }

    void ArrowsRotation()
    {
        arrowSprite.rectTransform.eulerAngles = new Vector3 (0,0,zRotation);
    }

    // Mouse/Touch input configuration
    void InputRotation()
    {
        if(RotationLiberation)
        {
            float yMove = Input.GetAxis ("Mouse Y");

            if(zRotation < 90)
            {
                if(yMove > 0)
                {
                    zRotation += 2.5f;
                }
            }

            if(zRotation > 0)
            {
                if(yMove < 0)
                {
                    zRotation -= 2.5f;
                }
            }            
        }
    }

    // Limiting de arrow rotation
    void LimitedRotation()
    {
        if(zRotation >= 90)
        {
            zRotation = 90;
        }

        if(zRotation <= 0)
        {
            zRotation = 0;
        }
    }

    void OnMouseDown()
    {
        RotationLiberation = true;
    }

    void OnMouseUp()
    {
        RotationLiberation = false;
        ForceLiberation = true;
    }
}
