import { Coach } from "./coach";
import { Team } from "./team";

export interface CoachTeams {
    coachId?: number;
    coach?: Coach[]
    teamId?: number;
    team?: Team[]
}
