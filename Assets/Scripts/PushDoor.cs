using UnityEngine;

public class PushDoor : MonoBehaviour
{
    private Transform doorTransform;
    private Quaternion openDoor;
    private PushDoor doorScript;

    public float doorOpenSpeed = 2f;
    public float doorOpenAngle = -10f;

    // Start is called before the first frame update
    void Start()
    {
        openDoor = Quaternion.Euler(0, doorOpenAngle, 0);
        doorTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (doorTransform.localRotation.y != openDoor.y)
        {
            doorTransform.localRotation = Quaternion.Slerp(doorTransform.localRotation, openDoor, Time.deltaTime * doorOpenSpeed);

            if (openDoor == doorTransform.localRotation)
            {
                doorScript = this.GetComponent<PushDoor>();
                doorScript.enabled = false;
            }
        }
    }
}
