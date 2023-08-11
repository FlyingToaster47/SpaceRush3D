using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorFollow : MonoBehaviour {

    [SerializeField] private Canvas parentCanvas;
    [SerializeField] private RawImage mouseCursor;

    Vector3 mousePos;

    private void Start() {
        mouseCursor.color = Color.blue;
        Cursor.visible = false;
    }

    private void Update() {
        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform,
            Input.mousePosition, parentCanvas.worldCamera,
            out movePos);

        mousePos = parentCanvas.transform.TransformPoint(movePos);

        //Set fake mouse Cursor
        mouseCursor.transform.position = mousePos;

        Ray p1 = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit rayHit;
        if (Physics.SphereCast(p1, 2f, out rayHit, 150f)) {
            if (rayHit.collider.tag == "Enemy") {
                mouseCursor.color = Color.red;
            } else {
                mouseCursor.color = Color.blue;
            }
        } else {
            mouseCursor.color = Color.blue;
        }
    }

}
