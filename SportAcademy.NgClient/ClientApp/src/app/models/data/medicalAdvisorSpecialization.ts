import { AdvisorSpecialization } from "./advisorSpecialization";
import { MedicalAdvisor } from "./medicaladvisor";

export interface MedicalAdvisorSpecialization {
    medicalAdvisorId?: number;
    medicalAdvisor?: MedicalAdvisor;
    advisorSpecializationId?: number;
    advisorSpecialization?: AdvisorSpecialization;

}