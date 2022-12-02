﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q
{
    public class PowerUps
    {
        bool inUse;
        Effects effect;
        List<Effects> effectsList;
        Players owner;
        Players playerAffected;
        string name;


        public void apply()
        {

        }
        public PowerUps newPowerUp(powerUpName powerupname)
        {
            PowerUps powerUp = new PowerUps();
            powerUp.inUse = false;

            switch (powerupname)
            {
                case powerUpName.ShootYourNeighbour:
                    powerUp.name = "ShootYourNeighbour";
                    effect = Effects.MissTurn;
                    powerUp.effects = effects;
                    break;

                case powerUpName.ShootanOpponent:
                    powerUp.name = "ShootanOpponent";
                    //Effects effects = new Effects(effectType.MissTurn);
                    //powerUp.effects = effects;
                    break;
            }

            return powerUp;
        }
    }

    public enum powerUpName
    {
        ShootYourNeighbour, // Next person misses a turn
        ShootanOpponent, // Choose someone to miss a turn
        GoWithout, // You skip a turn
        Bomb, // everyone misses a turn

    }
}
