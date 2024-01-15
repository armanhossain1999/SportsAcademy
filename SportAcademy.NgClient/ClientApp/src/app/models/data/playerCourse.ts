import { Course } from "./course";
import { Player } from "./player";

export interface PlayerCourse{
    playerCourseId?: number;
    playerId?: number;
    player?: Player;
    courseId?: number;
    course?: Course;
}