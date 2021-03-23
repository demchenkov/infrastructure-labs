export class Equipment {
    public id: number;
    public name: string;
    public characteristics : string;
    public price: number;

    public static fromJS(data: any = {}): Equipment {
        const entity = new Equipment();
        
        entity.id = data.id;
        entity.name = data.name;
        entity.characteristics = data.characteristics;
        entity.price = data.price;

        return entity;
    }
}