import { ExamResult } from "./examResult";
import { ExamTypeExam } from "./examTypeExam";
import { PlayerExam } from "./playerExam";

export interface Exam{
examId?:  number;

examName?:  string;
examDate?: Date | string;
result?: number;
examResultId?: number;
examResult?: ExamResult;
playerExam?: PlayerExam[] 
examTypeExam?: ExamTypeExam[]
}