import { KeyValue } from '@angular/common';
import { Component, ChangeDetectionStrategy, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Car } from 'src/app/domain/entities';

export interface EditCarData {
  entity?: Car;
  bodies: KeyValue<number, string>[];
  manufacturers: KeyValue<number, string>[];
  equipments: KeyValue<number, string>[];
  employees: KeyValue<number, string>[];
}

@Component({
  selector: 'sb-car-edit-modal',
  templateUrl: './car-edit-modal.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CarEditModalComponent {
  form: FormGroup;

  constructor(
    private fb: FormBuilder, 
    public dialogRef: MatDialogRef<CarEditModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: EditCarData) { }

  ngOnInit() {
    const entity = this.data.entity || new Car();

    this.form = this.fb.group({
      brand: [entity.brand, [Validators.required]],
      manufactureDate: [entity.manufactureDate, [Validators.required]],
      color: [entity.color, [Validators.required]],
      bodyNumber: [entity.bodyNumber, [Validators.required]],
      // characteristics: [entity.characteristics, [Validators.required]],
      price: [entity.price, [Validators.required]],
      carBodyId: [entity.carBodyId, [Validators.required]],
      manufacturerId: [entity.manufacturerId, [Validators.required]],
      equipment1Id: [entity.equipment1Id, [Validators.required]],
      equipment2Id: [entity.equipment2Id, [Validators.required]],
      equipment3Id: [entity.equipment3Id, [Validators.required]],
      employeeId: [entity.employeeId, [Validators.required]],
    });
  }

  getTitle() {
    return `${this.data.entity == null ? 'Create' : 'Edit '} Car`;
  }

  onConfirm() {
    this.form.markAllAsTouched();
    if (this.form.valid) {
      this.dialogRef.close(Car.fromJS({
        ...this.data.entity,
        ...this.form.value
      }));
    }
    else {
      console.log(this.form);
    }
  }
}
