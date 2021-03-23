import { ChangeDetectionStrategy, Component, Inject } from '@angular/core';

import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ConfirmOptions } from './confirm.service';

@Component({
  selector: 'ui-widget-confirm',
  templateUrl: './confirm.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ConfirmComponent {

  prompted = false;

  constructor(
    public dialogRef: MatDialogRef<ConfirmComponent>,
    @Inject(MAT_DIALOG_DATA) public options: ConfirmOptions
  ) {
  }

  onCancel() {
    this.dialogRef.close(false);
  }

  onClose() {
    this.dialogRef.close(true);
  }
}
