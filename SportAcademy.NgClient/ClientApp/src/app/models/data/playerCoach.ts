import { Coach } from "./coach";
import { Player } from "./player";

export interface PlayerCoache{
    playerId?: number;
    player?: Player;
    coachId?: number;
    coach?: Coach;
}