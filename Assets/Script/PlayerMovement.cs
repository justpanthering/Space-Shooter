using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private float maxSpeed = 5f;
    private float rotSpeed = 180f;

    private float ObjRadius = 1f;

    private Vector3 pos;
    private Quaternion rot;

    private float ScreenRatio;
    private float widthOrtho;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        pos = transform.position;
        rot = transform.rotation;
        PlayerRotate();
        PlayerMove();
        LimitBoundary();
	}

    void PlayerMove()
    {
        pos += rot * new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
    }

    void PlayerRotate()
    {
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;
    }

    void LimitBoundary()
    {
        //Vertical
        if (pos.y + ObjRadius > Camera.main.orthographicSize)
            pos.y = Camera.main.orthographicSize - ObjRadius;
            
        if (pos.y - ObjRadius < -Camera.main.orthographicSize)
            pos.y = -Camera.main.orthographicSize + ObjRadius;

        //Horizontal
        ScreenRatio = (float)Screen.width / (float)Screen.height;
        widthOrtho = Camera.main.orthographicSize * ScreenRatio;

        if (pos.x + ObjRadius > widthOrtho)
            pos.x = widthOrtho - ObjRadius;
        if (pos.x - ObjRadius < -widthOrtho)
            pos.x = -widthOrtho + ObjRadius;
        transform.position = pos;
    }
}
