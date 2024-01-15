import { Event } from "./event";

export interface Manager {
    managerId?: number;
    managerName?: string;
    joinDate?: Date;
    email?: string;
    phone?: string;
    address?: string;
    picture?: string;
    events?: Event[];
}