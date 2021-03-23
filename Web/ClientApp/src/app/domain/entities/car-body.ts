export class CarBody {
    public id: number;
    public name: string;
    public description: string;

    public static fromJS(data: any = {}): CarBody {
        const entity = new CarBody();
        
        entity.id = data.id;
        entity.name = data.name;
        entity.description = data.description;

        return entity;
    }
}