#pragma strict

var blood : GameObject;

function Start () {
    blood.SetActive(false);
}

function OnTriggerEnter () {
    blood.SetActive(true);
}

function OnTriggerExit () {
    blood.SetActive(true);
}
