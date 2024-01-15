import { PlayerTrainingSession } from "./PlayerTrainingSession";
import { Attendence } from "./attendence";
import { Coach } from "./coach";
import { Equipment } from "./equipment";
import { PlayerStateDetail } from "./playerStateDetail";

export interface TrainingSession{
    trainingSessionId?: number;
    title?: string;
    description?: string;
    sessionTime?: Date| string;
    coachId?: number;
    coach?: Coach;
    playerTrainingSession?: PlayerTrainingSession[]
    equipment?: Equipment[]
    Attendance?: Attendence[]
    playerStateDetail?: PlayerStateDetail[]
}