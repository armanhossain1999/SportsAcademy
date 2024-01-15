import { Player } from "./player";

export interface Category {
    categoryId?: number;
    categoryName ?: string;
    player?: Player[]
}