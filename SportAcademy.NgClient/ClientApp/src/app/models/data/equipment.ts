import { TrainingSession } from "./trainingSession";

export interface Equipment{
    equipmentId?: number;
    equipmentName?: string;
    trainingSessionId?: number;
    trainingSession?: TrainingSession;   
}