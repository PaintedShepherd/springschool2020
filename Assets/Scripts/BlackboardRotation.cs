using System.Collections;
using UnityEngine;

public class BlackboardRotation : MonoBehaviour
{
     public int rotationSpeedInSeconds = 2;
     public int breakAfterRotation = 5;
     public float rotationInDegree = 180.0f;

     void Start()
     {
          StartCoroutine(RotateObject(rotationInDegree, Vector3.up, rotationSpeedInSeconds));
     }

     IEnumerator RotateObject(float angle, Vector3 axis, float inTime)
     {
          // calculate rotation speed
          float rotationSpeed = angle / inTime;

          while (true)
          {
               // save starting rotation position
               Quaternion startRotation = transform.rotation;

               float deltaAngle = 0;

               // rotate until reaching angle
               while (deltaAngle < angle)
               {
                    deltaAngle += rotationSpeed * Time.deltaTime;
                    deltaAngle = Mathf.Min(deltaAngle, angle);

                    transform.rotation = startRotation * Quaternion.AngleAxis(deltaAngle, axis);

                    yield return null;
               }

               // delay here
               yield return new WaitForSeconds(breakAfterRotation);
          }
     }
}
