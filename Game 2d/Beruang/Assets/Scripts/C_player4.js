#pragma strict

var rapides : float = 6.0;
    var gravedad : float = 20.0;
    var velocidadSalto : float = 8.0;
    var velocidadSalto2 : float = 8.0;
    var esperarSalto : boolean;
    var esperarSalto2 : boolean;
    var dobleSalto : int = 0;
    var dobleSalto2 : int = 0;
 
    private var moveDirection : Vector3 = Vector3.zero;
 
    //undap
    function Update()
    {
    if( Input.GetKeyDown(KeyCode.Space) && esperarSalto == false)
    {
    Jump();
    }
    var controller : CharacterController = GetComponent(CharacterController);
    if (controller.isGrounded) {
    // We are grounded, so recalculate
    // move direction directly from axes
    moveDirection = Vector3(Input.GetAxis("Horizontal"), 0,
    Input.GetAxis("Vertical"));
    moveDirection = transform.TransformDirection(moveDirection);
    moveDirection *= rapides;
 
    if (Input.GetButton ("Jump")&& esperarSalto2 == false) {
    moveDirection.y = velocidadSalto;
    Jump2();
    }
    }
 
    // Apply gravity
    moveDirection.y -= gravedad * Time.deltaTime;
 
    // Move the controller
    controller.Move(moveDirection * Time.deltaTime);
    }
    //undap
 
    function Jump()
    {
    if (dobleSalto <= 1)
    {
    moveDirection.y = velocidadSalto;
    jumpTimer();
    }
    }
 
    function jumpTimer()
    {
    if (Input.GetButton ("Jump"))
    {
    dobleSalto ++;
    }
 
    if (dobleSalto > 1)
    {
    dobleSalto = 0;
    esperarSalto = true;
    yield WaitForSeconds (1.8);
    esperarSalto = false;
    }
    }
    //exra
    function Jump2()
    {
    if (dobleSalto2 <= 1)
    {
    jumpTimer2();
    }
    }
 
    function jumpTimer2()
    {
    if (Input.GetButton ("Jump"))
    {
    dobleSalto2 ++;
    }
 
    if (dobleSalto2 > 1)
    {
    dobleSalto2 = 0;
    esperarSalto2 = true;
    yield WaitForSeconds (1.5);
    esperarSalto2 = false;
    }
    } 