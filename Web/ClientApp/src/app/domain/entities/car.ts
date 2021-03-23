import { CarBody, Employee, Equipment, Manufacturer } from ".";

export class Car {
    public id: number;
    public brand: string;
    public manufactureDate: Date;
    public color: string;
    public bodyNumber: string;
    public characteristics: string;
    public price: number;

    public carBodyId: number;
    public carBody: CarBody;
    
    public manufacturerId: number;
    public manufacturer: Manufacturer;
    
    public equipment1Id: number | null;
    public equipment1: Equipment;
    
    public equipment2Id: number | null;
    public equipment2: Equipment;
    
    public equipment3Id: number | null;
    public equipment3: Equipment;

    public employeeId: number | null;
    public employee: Employee;

    public static fromJS(data: any = {}): Car {
        const entity = new Car();
        
        entity.id = data.id;
        entity.brand = data.brand;
        entity.manufactureDate = data.manufactureDate;
        entity.color = data.color;
        entity.bodyNumber = data.bodyNumber;
        entity.characteristics = data.characteristics;
        entity.price = data.price;
        entity.carBodyId = data.carBodyId;
        entity.carBody = data.carBody;
        entity.manufacturerId = data.manufacturerId;
        entity.manufacturer = data.manufacturer;
        entity.equipment1Id = data.equipment1Id;
        entity.equipment1 = data.equipment1;
        entity.equipment2Id = data.equipment2Id;
        entity.equipment2 = data.equipment2;
        entity.equipment3Id = data.equipment3Id;
        entity.equipment3 = data.equipment3;
        entity.employeeId = data.employeeId;
        entity.employee = data.employee;

        return entity;
    }
}
