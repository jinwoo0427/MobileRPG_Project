using UnityEngine;
using UnityEngine.EventSystems;

public class CamRotate : MonoBehaviour, IBeginDragHandler, IDragHandler
{

    public Transform camPivot;
    public float rotationSpeed = 0.4f;

    //첫 터지 포지션
    private Vector3 beginPos;
    //드래그 포지션
    private Vector3 draggingPos;

    private float yAngle;
    private float yAngleTemp;

    private void Start()
    {
        yAngle = camPivot.rotation.eulerAngles.y;
    }

    //터치드래그 시작
    public void OnBeginDrag(PointerEventData beginPoint)
    {
        beginPos = beginPoint.position;

        yAngleTemp = yAngle;
    }
    //드래그중
    public void OnDrag(PointerEventData draggingPoint)
    {
        Debug.Log("CameraRotate OnDrag");
        draggingPos = draggingPoint.position;

        yAngle = yAngleTemp + (draggingPos.x - beginPos.x) * Screen.height / 1440 * rotationSpeed * Time.deltaTime;


        camPivot.rotation = Quaternion.Euler(0.0f, yAngle, 0.0f);

        Debug.Log(camPivot.rotation + " : " + yAngle);
    }
}