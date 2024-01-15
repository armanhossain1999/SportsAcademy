// selectionPanel.model.ts

import { Event } from "./event";
import { Coach } from "./coach";
import { MedicalAdvisor } from "./medicaladvisor";

export interface SelectionPanel {
    selectionPanelId?: number;
    selectionPanelName?: string;
    coachId?: number;
    coach?: Coach;
    medicalAdvisorId?: number;
    medicalAdvisor?: MedicalAdvisor;
    events?: Event[];
}
