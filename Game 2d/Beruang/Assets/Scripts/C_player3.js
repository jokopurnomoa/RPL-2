/*
@script RequireComponent(Rigidbody); //forces this gameObject to also have a rigibody component

//public variables

var maxAirJumpCount : int = 1; // 1 for a double jump

var normalJumpForce : float = 8; //strength of the normal jump's impulse
var airJumpForce : float = 5; //strength of the double jump's impulse

var raycastDistance : float = 1; //distance between the characters origin and the ground, 1 for a 2m high character

var xSpeed : float = 10; // horizontal speed of the character

/* These values are all ideal settings that worked for me */

//private variables
/*

private var airJumpCount : int = 0; //how many more times can the player jump?

private var xMove : float; // horizontal input (Input.GetAxisRaw("Horizontal")) *
                   // horizontal speed modifier (xSpeed)

private var isGrounded : boolean = false; //is the player on the ground?

function Update() {

    if(Physics.Raycast(transform.position, -Vector3.up, raycastDistance)) {

       isGrounded = true;
       airJumpCount = maxAirJumpCount;
    }
    else {

       isGrounded = false;
    }

    if(Input.GetKeyDown(KeyCode.Space)) {

       if(isGrounded) {
         JumpNormal();
       }
       else if(airJumpCount > 0) {

         airJumpCount -= 1;
         JumpInAir();
       }
    }

    xMove = 0;
    xMove = Input.GetAxisRaw("Horizontal") * xSpeed;

}

function FixedUpdate () {
    rigidbody.AddForce(Vector3.right*xMove);
}


function JumpNormal () { rigidbody.AddForce(Vector3.up * normalJumpForce, ForceMode.Impulse); }

function JumpInAir () { rigidbody.AddForce(Vector3.up * airJumpForce, ForceMode.Impulse); }*/