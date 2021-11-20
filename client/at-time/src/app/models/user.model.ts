import { UserRole } from "../enums/user-role.enum";
import { Point } from "./point.model";

export class User {
    public id!: number;
    public fullName!: string;
    public email!: string;
    public role!: UserRole;
    public roleName!: string;
    public points: Point[] = [];
}