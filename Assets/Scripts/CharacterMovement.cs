using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    public float m_CharacterMovementSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-0.2f * m_CharacterMovementSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0.2f * m_CharacterMovementSpeed, 0, 0);
        }
    }
}
