import { User } from "./user.model";

export class Point {
    public id!: number;
    public time!: Date;
    public authorId!: number;
    public author?: User;
}