#pragma strict
var ani: Animator;

function Start () {
    ani.enabled = false;
}

function OnTriggerEnter () {
    ani.enabled = true;
}