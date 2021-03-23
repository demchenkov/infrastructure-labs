import { KeyValue } from '@angular/common';
import { Component, ChangeDetectionStrategy, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Employee } from 'src/app/domain/entities';

export interface EditEmployeeData {
  entity?: Employee;
  positions: KeyValue<number, string>[];
  genders: KeyValue<number, string>[];

}

@Component({
  selector: 'sb-employee-edit-modal',
  templateUrl: './employee-edit-modal.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EmployeeEditModalComponent {
  form: FormGroup;

  constructor(
    private fb: FormBuilder, 
    public dialogRef: MatDialogRef<EmployeeEditModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: EditEmployeeData) { }

  ngOnInit() {
    const entity = this.data.entity || new Employee();

    this.form = this.fb.group({
      fullName: [entity.fullName, [Validators.required]],
      age: [entity.age, [Validators.required]],
      gender: [entity.gender, [Validators.required]],
      address: [entity.address, [Validators.required]],
      phone: [entity.phone, [Validators.required]],
      passport: [entity.passport, [Validators.required]],
      positionId: [entity.positionId, [Validators.required]],
    });
  }

  getTitle() {
    return `${this.data.entity == null ? 'Create' : 'Edit '} Employee`;
  }

  onConfirm() {
    this.form.markAllAsTouched();
    if (this.form.valid) {
      this.dialogRef.close(Employee.fromJS({
        ...this.data.entity,
        ...this.form.value
      }));
    }
    else {
      console.log(this.form);
    }
  }
}
