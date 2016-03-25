using UnityEngine;
using System.Collections;
using System;


[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour {

    [Serializable]
    public class InputManager
    {
        public float verticalInput, horizontalInput;
        public bool sprintInput;

        public void Update()
        {
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");
            sprintInput = Input.GetKey(KeyCode.LeftShift);
        }
    }
    public InputManager inputManager;

    private Animator playerAnimator;
    private float playerVerticalDirection; //forward = 1, backward = -1

	// Use this for initialization
	void Start () {
        playerAnimator = gameObject.GetComponent<Animator>();
        inputManager = new InputManager();

        playerVerticalDirection = 1f;
        playerAnimator.SetFloat("Direction", playerVerticalDirection);
    }
	
	// Update is called once per frame
	void Update () {
        inputManager.Update();
        UpdateMovement();
	}

    private void UpdateMovement()
    {
        if (inputManager.verticalInput != 0)
        {
            if (Mathf.Sign(playerVerticalDirection) != Mathf.Sign(inputManager.verticalInput))
            {
                playerVerticalDirection = Mathf.Sign(inputManager.verticalInput);
                playerAnimator.SetFloat("Direction", playerVerticalDirection);
                playerAnimator.SetTrigger("Turn Around");
            }
        }
        
        playerAnimator.SetFloat("VSpeed", inputManager.verticalInput);
        playerAnimator.SetFloat("HSpeed", inputManager.horizontalInput);

        playerAnimator.SetBool("Run", (inputManager.verticalInput != 0) ? true : false);
        playerAnimator.SetBool("Sprint", inputManager.sprintInput);

    }

}
