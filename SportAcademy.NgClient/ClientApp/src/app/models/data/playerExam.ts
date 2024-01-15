import { Exam } from "./exam";
import { Player } from "./player";

export interface PlayerExam{
    playerExamId?: number;
    playerId?: number;
    player?: Player;
    examId?: number;
    exam?: Exam;
}