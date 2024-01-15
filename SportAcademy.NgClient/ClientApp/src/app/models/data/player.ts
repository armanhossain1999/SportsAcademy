import { Category } from "./category";
import { PlayerCoache } from "./playerCoach";
import { PlayerCourse } from "./playerCourse";
import { PlayerExam } from "./playerExam";
import { PlayerRolePlayer } from "./playerRolePlayer";
import { PlayerSport } from "./playerSport";
import { PlayerStatistic } from "./playerStatistic";
import { Team } from "./team";

export interface Player {
    playerId?: number;
    registrationNumber?: number;
    playerName?: string;
    birthDate?: Date | string;
    phone?: string;
    email?:  string;
    address?: string;
    picture?: string;
    teamId?: number;
    team?: Team ;
    categoryId?: number;
    category?: Category;
    playerStatistic?: PlayerStatistic[]
    playerExam?: PlayerExam[]
    playerRolePlayer?:PlayerRolePlayer[]
    playerCourse?:PlayerCourse[]
    playerCoach?: PlayerCoache[]
    playerSport?: PlayerSport[]
}
