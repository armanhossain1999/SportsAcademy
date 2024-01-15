import { PlayerRolePlayer } from "./playerRolePlayer";

export interface PlayerRole{
    playerRoleId?: number;
    roleName?: string;
    playerRolePlayer?: PlayerRolePlayer[]
}