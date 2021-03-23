import { Gender, Position } from ".";


export class Employee {
    public id: number;
    public fullName: string;
    public age: number;
    public gender: Gender;
    public address: string;
    public phone: string;
    public passport: string;

    public positionId: number;
    public position: Position;

    public static fromJS(data: any = {}): Employee {
        const entity = new Employee();
        
        entity.id = data.id;
        entity.fullName = data.fullName;
        entity.age = data.age;
        entity.gender = data.gender;
        entity.address = data.address;
        entity.phone = data.phone;
        entity.passport = data.passport;
        entity.positionId = data.positionId;
        entity.position = data.position;

        return entity;
    }
}