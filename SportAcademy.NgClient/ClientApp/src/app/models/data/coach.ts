import { CoachSpecializaton } from "./coachSpecialization";
import { CoachSports } from "./coachSport";
import { CoachTeams } from "./coachTeams";
import { CoachType } from "./coachType";

export interface Coach {
    coachId?: number;
    coachName?: string;
    joinDate?: Date| string;
    email?: string;
    phone?: string;
    address?: string;
    picture?: string;
    coachTypeId?: number;
    coachType?: CoachType;
    coachSport?: CoachSports[]
    coachTeams?: CoachTeams[]
    coachSpecializations?: CoachSpecializaton[]
}
