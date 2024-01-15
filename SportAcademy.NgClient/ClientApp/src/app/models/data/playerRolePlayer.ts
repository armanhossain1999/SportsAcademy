import { Player } from "./player";
import { PlayerRole } from "./playerRole";

export interface PlayerRolePlayer{
    playerId?: number;
    player?: Player;
    playerRoleId?: number;
    playerRole?: PlayerRole;
}