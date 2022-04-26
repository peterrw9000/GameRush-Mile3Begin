using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public float speed = 0;
    public bool followX = true;
    public bool followY = true;

    float positionA;
    float positionB;
    bool movingR;

    RaycastHit hit;
    Ray ray;

    Camera camera;

    private void Awake() {


        positionA = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
    }

    void Update() {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit)) {
            transform.LookAt(hit.transform.position);
        }

        /*        if (movingR) { 
                    transform.rotation = Quaternion.Euler(new Vector3(0f, transform.rotation.x + 10, 0f));
                } else {
                    transform.rotation = Quaternion.Euler(new Vector3(0f, transform.rotation.x - 10, 0f));
                }*/
    }

/*    void LateUpdate() {
        positionB = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        if (positionB > positionA) {
            movingR = true;
            Debug.Log("Right");
        }
        else {
            movingR = false;
            Debug.Log("Left");
        }
        positionA = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
    }


    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }*/

}

/*}    void Update() {
        //transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), speed);

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
    }*/

/*    void Update() {

        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        transform.rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }*/


    // Start is called before the first frame update
    /*    void Start() {

        }

        void Update() {
            DoFollow();
        }

        void DoFollow() {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            transform.position = Vector3.Lerp(transform.position, mousePosition, speed * Time.deltaTime);

        }

        public void SetFollowX(bool x) {
            followX = x;
        }

        public void SetFollowY(bool y) {
            followY = y;
        }
        public void SetFollowSpeed(int s) {
            speed = s;
        }
}*/
