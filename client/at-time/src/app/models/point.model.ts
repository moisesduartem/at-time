import { User } from "./user.model";

export class Point {
    public id!: number;
    public time!: Date;
    public authorId!: number;
    public author?: User;

    public constructor(data: any = {}) {
        this.id = data.id;
        this.time = new Date(data.time);
        this.authorId = data.authorId;
        this.author = data.author;
    }

    public get justTime(): string {
        return this.time.toLocaleTimeString();
    }

    public toString() {
        return this.time.toLocaleString();
    }
}