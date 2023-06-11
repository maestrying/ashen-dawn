using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phoneScript : MonoBehaviour
{
    CircleCollider2D circleCollider;
    public void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    public void changePhoneState()
    {
        circleCollider.enabled = !circleCollider.enabled;
    }

}
