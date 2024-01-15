import { Exam } from "./exam";
import { ExamType } from "./examType";

export interface ExamTypeExam{
    examTypeExamId?: number;
    examId?: number;
    exam?: Exam;
    examTypeId?: number;
    examType?: ExamType;
}