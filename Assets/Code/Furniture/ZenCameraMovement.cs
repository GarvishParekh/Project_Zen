using UnityEngine;

public class ZenCameraMovement : MonoBehaviour
{
    [SerializeField] private Transform cameraHolderTransform;

    [Space]
    [SerializeField] private Vector2 minMaxValue;
    [SerializeField] private float desireRotation;
    [SerializeField] private float cameraRotationValue;

    [SerializeField] private float timer = 10;

    private void Start()
    {
        cameraRotationValue = Random.Range(minMaxValue.x, minMaxValue.y);
    }

    private void Update()
    {
        Clock();
        desireRotation = Mathf.MoveTowards(desireRotation, cameraRotationValue, 0.5f * Time.deltaTime);
        cameraHolderTransform.rotation = Quaternion.Euler(0, desireRotation, 0);
    }

    private void Clock()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 10;
            cameraRotationValue = Random.Range(minMaxValue.x, minMaxValue.y);
        }
    }
}
