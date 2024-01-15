import { ExamResult } from "./examResult";
import { TrainingSession } from "./trainingSession";

export interface PlayerStateDetail {
    playerStateDetailId?: number;
    matches?: number;
    innings?: number;
    runs?: number;
    balls?: number;
    average?: number;
    fifty?: number;
    hundred?: number;
    sixs?: number;
    fours?: number;
    highest?: number;
    ducks?: number;
    wicket?: number;
    maidens?: number;
    economy?: number;
    marks?: number;
    grade?: string;
    comment?: string;
    trainingSessionId?: number;
    trainingSession?: TrainingSession;
    examResult?: ExamResult[]
}