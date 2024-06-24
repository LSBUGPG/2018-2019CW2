using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMouseLook : MonoBehaviour {

    Vector2 mouselook;// how much movement the camera have made (total)
    Vector2 smoothV;// smooth down the movement of the mouse
    public float sensitivity = 5.0f;// mouse sensetivity
    public float smoothing = 2.0f;// how much smoothing do you want?

    GameObject character;

    // Use this for initialization
    void Start()
    {
        character = this.transform.parent.gameObject;// the parent that the object is connected to is the character
    }

    // Update is called once per frame
    void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouselook += smoothV;
        mouselook.y = Mathf.Clamp(mouselook.y, -90f, 90f); // clampin the looking up and down

        transform.localRotation = Quaternion.AngleAxis(-mouselook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouselook.x, character.transform.up);
    }
}
