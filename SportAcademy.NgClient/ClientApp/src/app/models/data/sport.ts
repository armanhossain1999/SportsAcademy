import { CoachSports } from "./coachSport";
import { PlayerSport } from "./playerSport";
import { Team } from "./team";

export interface Sport {
    sportId?: number;
    sportsName?: string;
    teams?:Team[];
    coachSport?: CoachSports[]
    playerSport?: PlayerSport[]
}
