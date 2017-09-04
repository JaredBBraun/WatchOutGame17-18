#pragma strict

var ani: Animator;

function Start () {
    ani.enabled = false;
}

function OnTriggerExit () {
    ani.enabled = false;
}