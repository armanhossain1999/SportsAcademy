import { TrainingSession } from "./trainingSession";

export interface Attendence{
    attendenceId?: number;
    isPresent?: boolean;
    date?: Date| string;
    trainingSessionId?: number;
    trainingSession?: TrainingSession;
}