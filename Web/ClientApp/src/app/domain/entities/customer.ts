import { Car, Employee } from ".";

export class Customer {
    public id: string;
    public name : string;
    public address : string;
    public phone : string;
    public passport: string;
    public orderDate: Date;
    public saleDate: Date;
    public isDone: boolean;
    public isPayment: boolean;
    public prepaymentPercentage: number;
    
    public carId: number | null;
    public car: Car;
    
    public employeeId: number | null;
    public employee: Employee;

    public static fromJS(data: any = {}): Customer {
        const entity = new Customer();
        
        entity.id = data.id;
        entity.name = data.name;
        entity.address = data.address;
        entity.phone = data.phone;
        entity.passport = data.passport;
        entity.orderDate = data.orderDate;
        entity.saleDate = data.saleDate;
        entity.isDone = data.isDone;
        entity.isPayment = data.isPayment;
        entity.prepaymentPercentage = data.prepaymentPercentage;
        entity.carId = data.carId;
        entity.car = data.car;
        entity.employeeId = data.employeeId;
        entity.employee = data.employee;

        return entity;
    }
}