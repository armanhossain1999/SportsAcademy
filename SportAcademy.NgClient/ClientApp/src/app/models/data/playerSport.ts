import { Player } from "./player";
import { Sport } from "./sport";

export interface PlayerSport {
    playerId?: number;
    player?: Player;
    sportId?: number;
    sport?: Sport;
}