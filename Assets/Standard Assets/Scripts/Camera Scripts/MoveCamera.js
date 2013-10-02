#pragma strict

var moveSpeed  : float = 2.0;
function Update()
{
   transform.localPosition.x += moveSpeed * Time.deltaTime;
}