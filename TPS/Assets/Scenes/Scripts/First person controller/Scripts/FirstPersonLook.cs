using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    Transform character;
    Vector2 currentMouseLook;
    Vector2 appliedMouseDelta;
    public float sensitivity = 1;
    public float smoothing = 2;
    public float mouselookIyI1 = -30;
    public float mouselookIyI2 = 30;
    public float mouselookIxI1 = -90;
    public float mouselookIxI2 = 90;



    void Reset()
    {
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get smooth mouse look.
        Vector2 smoothMouseDelta = Vector2.Scale(new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")), Vector2.one * sensitivity * smoothing);
        appliedMouseDelta = Vector2.Lerp(appliedMouseDelta, smoothMouseDelta, 1 / smoothing);
        currentMouseLook += appliedMouseDelta;
        //меняешь - 90 и 90(но про минус не забудь) для того что бы поменять на сколько камера не может поворачиваться вверх и вниз
        currentMouseLook.y = Mathf.Clamp(currentMouseLook.y, mouselookIyI1, mouselookIyI2);
        //меняешь -90 и 90 (но про минус не забудь) для того что бы поменять на сколько камера не может поворачиваться на право и лево
        currentMouseLook.x = Mathf.Clamp(currentMouseLook.x, mouselookIxI1, mouselookIxI2); 

        // Rotate camera and controller.
        //transform.localRotation =  Quaternion.AngleAxis(-currentMouseLook.y, Vector3.right);
        transform.localRotation = Quaternion.Euler(new Vector3(-currentMouseLook.y, currentMouseLook.x, transform.localRotation.z));
        //transform.localRotation = Quaternion.AngleAxis(currentMouseLook.x, Vector3.up);
    }
}
