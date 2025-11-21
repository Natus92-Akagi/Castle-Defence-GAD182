using UnityEngine;

public class enemyBounce : MonoBehaviour
{
    public float enemyRotation;
    public bool turnSwitch = true;
    public float rotationSpeed;
    public enemyControl enemyControl;

    [Header("Enemy Rotation Speeds")]
    public float rotationSpeedFootsoldier;
    public float rotationSpeedFlyer;
    public float rotationSpeedGiant;
    public float rotationRandom;

    void Start()
    {
        rotationRandom = Random.Range(1,11);

        if (enemyControl.enemyType == 1)
        {
            rotationSpeed = rotationSpeedFootsoldier;
        }
        if (enemyControl.enemyType == 2)
        {
            rotationSpeed = rotationSpeedFlyer;
        }
        if (enemyControl.enemyType == 3)
        {
            rotationSpeed = rotationSpeedGiant;
        }

        rotationSpeed += rotationRandom;
    }

    void Update()
    {
        Vector3 euler = transform.eulerAngles;
        float enemyRotation = NormalizeAngle(transform.eulerAngles.z);
        Debug.Log("Rotation is " + euler);

        if (turnSwitch == true)
        {
            Quaternion target = Quaternion.Euler(0, 0, -16);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target, rotationSpeed * Time.deltaTime);
            if (enemyRotation <= -15f)
            {
            turnSwitch = false;
            }
        }
        if (turnSwitch == false)
        {
            Quaternion target = Quaternion.Euler(0, 0, 16);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target, rotationSpeed * Time.deltaTime);
            if (enemyRotation >= 15f)
            {
            turnSwitch = true;
            }
        }

        float NormalizeAngle(float angle)
        {
            if (angle > 180f)
            angle -= 360f;
            return angle;
        }

        //transform.position += Vector3.up * projectileSpeed * Time.deltaTime;
    }
}
