using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {
    private Animator playerAni;

    public bool isWalk;
    public bool isRun;
    public bool isJump;

    private float targetRun;

    private void Awake() {
        playerAni = transform.GetChild(0).GetComponent<Animator>();
    }

    private void Update() {
        isWalk = Input.GetKey(KeyCode.W);
        isRun = Input.GetKey(KeyCode.LeftShift);
        isJump = Input.GetKey(KeyCode.Space);
        float targetRun = isWalk ? (isRun ? 2f : 1f) : 0f;
        playerAni.SetFloat("move", Mathf.Lerp(playerAni.GetFloat("move"),targetRun,0.5f));
        if (isJump) {
            playerAni.SetTrigger("jump");
        }
    }
}
