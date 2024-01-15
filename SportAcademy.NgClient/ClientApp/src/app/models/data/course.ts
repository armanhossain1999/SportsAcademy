import { PlayerCourse } from "./playerCourse";

export interface Course{
    courseId?: number;
    courseName?: string;
    semester?: string;
    startDate?: Date| string;
    endDate?: Date| string;
    description?: String;
    playerCourse?: PlayerCourse[]

}