import { MedicalAdvisorSpecialization } from "./medicalAdvisorSpecialization";

export interface AdvisorSpecialization {
advisorSpecializationId?: number;
advisorSpecializedIn?: string;
medicalAdvisorSpecialization?: MedicalAdvisorSpecialization[]
}