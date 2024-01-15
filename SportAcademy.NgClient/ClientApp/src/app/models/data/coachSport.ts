import { Coach } from "./coach";
import { Sport } from "./sport";

export interface CoachSports {
    coachId?: number;
    coach?: Coach[]
    sportId?: number;
    sport?: Sport[];
}
