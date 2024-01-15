import { Manager } from "./manager";
import { SelectionPanel } from "./selectionPanel";

export interface Event {
    eventId?: number;
    eventName?: string;
    startDate?: Date;
    endDate?: Date;
    description?: string;
    location?: string;
    picture? : string;
    selectionPanelId?: number;
    selectionPanel? : SelectionPanel[];
    managerId? : number;
    manager?: Manager[];
    managerName?: string;
}