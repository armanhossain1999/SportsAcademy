import { Player } from "./player";
import { PlayerStateDetail } from "./playerStateDetail";

export interface PlayerStatistic {
    playerStatisticId?: number;
    matches?: number | null;
    innings?: number | null;
    runs?: number | null;
    balls?: number | null;
    average?: number | null;
    fifty?: number | null;
    hundred?: number | null;
    sixs?: number | null;
    fours?: number | null;
    highest?: number | null;
    ducks?: number | null;
    wicket?: number | null;
    maidens?: number | null;
    economy?: number | null;
    playerId?: number;
    player?: Player;
    playerStateDetails?: PlayerStateDetail[];  // Adjusted property name
}
