import { Exam } from "./exam";

export interface ExamResult{
    examResultId?: number;
    examTitle?: string;
    exam?: Exam[]
}