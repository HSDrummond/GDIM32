using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : monobehaviour {
    public float increase = 5f;

    private void ontriggerenter2d(collider2d collision) {
        if (collision.tag == "Player1") {
            gameobject player = collision.gameobject;
            Player1 playerscript = player.getcomponent<Player1>();

            if playerscript) {
                playerscript.movespeed += increase;
            }
        }
    }
}

