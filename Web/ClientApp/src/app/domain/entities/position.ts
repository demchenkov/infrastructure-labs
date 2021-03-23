export class Position {
    public id: number;
    public name: string;
    public salary: number;
    public responsibilities: string;
    public requirements: string;

    public static fromJS(data: any = {}): Position {
        const entity = new Position();
        
        entity.id = data.id;
        entity.name = data.name;
        entity.salary = data.salary;
        entity.responsibilities = data.responsibilities;
        entity.requirements = data.requirements;

        return entity;
    }
}