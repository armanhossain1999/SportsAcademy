import { ExamTypeExam } from "./examTypeExam";

export interface ExamType{
    examTypeId?: number;
    typeName?: string;
    examTypeExam?: ExamTypeExam[]
}