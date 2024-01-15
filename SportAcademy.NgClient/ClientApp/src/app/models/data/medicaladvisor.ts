import { MedicalAdvisorSpecialization } from "./medicalAdvisorSpecialization";

export interface MedicalAdvisor {
    medicalAdvisorId?: number;
    medicalAdvisorName?: string;
    designation?: string;
    joinDate?: Date | string;
    email?: string;
    phone?: string;
    address?: string;
    picture?: string;
    medicalAdvisorSpecialization?: MedicalAdvisorSpecialization[]

}
