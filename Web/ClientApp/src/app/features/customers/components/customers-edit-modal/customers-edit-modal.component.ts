import { KeyValue } from '@angular/common';
import { Component, ChangeDetectionStrategy, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Customer } from 'src/app/domain/entities';

export interface EditCustomerData {
  entity?: Customer;
  cars: KeyValue<number, string>[];
  employees: KeyValue<number, string>[];
}

@Component({
  selector: 'sb-customer-edit-modal',
  templateUrl: './customers-edit-modal.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CustomersEditModalComponent {
  form: FormGroup;

  constructor(
    private fb: FormBuilder, 
    public dialogRef: MatDialogRef<CustomersEditModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: EditCustomerData) { }

  ngOnInit() {
    const entity = this.data.entity || new Customer();
    
    this.form = this.fb.group({
      name: [entity.name, [Validators.required]],
      address: [entity.address, [Validators.required]],
      phone: [entity.phone, [Validators.required]],
      passport: [entity.passport, [Validators.required]],
      orderDate: [entity.orderDate, [Validators.required]],
      saleDate: [entity.saleDate, [Validators.required]],
      isDone: [entity.isDone || false, [Validators.required]],
      isPayment: [entity.isPayment || false, [Validators.required]],
      prepaymentPercentage: [entity.prepaymentPercentage || 0, [Validators.required]],
      carId: [entity.carId, [Validators.required]],
      employeeId: [entity.employeeId, [Validators.required]],
    });
  }

  getTitle() {
    return `${this.data.entity == null ? 'Create' : 'Edit '} Customer`;
  }

  onConfirm() {
    this.form.markAllAsTouched();
    if (this.form.valid) {
      this.dialogRef.close(Customer.fromJS({
        ...this.data.entity,
        ...this.form.value
      }));
    }
    else {
      console.log(this.form);
    }
  }
}
