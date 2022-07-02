using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject follow;

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            Vector3 cameraPos = transform.position;
            Vector3 followPos = follow.transform.position;

            if (GameManager.S.gameState == GameState.playing)
            {
                cameraPos.x = followPos.x; //Mathf.SmoothDamp(cameraPos.x, followPos.x, ref xVelocity, 0.5f);
                if (followPos.y > 0)
                {
                    cameraPos.y = followPos.y;
                }

                transform.position = cameraPos;
            }
        }
        else
        {
            follow = GameManager.S.GetMallow();
        }
    }
}
