import { Employee } from ".";

export class Manufacturer
{
    public id: number;
    public name: string;
    public country: string;
    public address : string;
    public description: string;
    
    public employeeId: number;
    public employee: Employee;

    public static fromJS(data: any = {}): Manufacturer {
        const entity = new Manufacturer();
        
        entity.id = data.id
        entity.name = data.name
        entity.country = data.country
        entity.address = data.address
        entity.description = data.description
        entity.employeeId = data.employeeId
        entity.employee = data.employee

        return entity;
    }
}