import { Player } from "./player";
import { TrainingSession } from "./trainingSession";

export interface PlayerTrainingSession{
    PlayerTrainingSessionId?: number;
    playerId?: number;
    player?: Player;
    trainingSessionId?: number;
    trainingSession?: TrainingSession;
}