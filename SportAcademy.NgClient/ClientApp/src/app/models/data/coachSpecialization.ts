import { Coach } from "./coach";

export interface CoachSpecializaton {
    coachSpecializationId?: number;
    specializedIn?: string;
    coachId?: number;
    coach?: Coach[];
}
