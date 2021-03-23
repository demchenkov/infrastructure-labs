import { Injectable } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';

import { ConfirmComponent } from './confirm.component';
import { filter, take, map } from 'rxjs/operators';
import { Observable } from 'rxjs';

export interface ConfirmOptions {
  title: string;
  template: string[];
  confirmText?: string;
  cancelText?: string;
  requirePrompt?: boolean;
}

export interface AlertOptions {
  template: string[];
  confirmText?: string;
}

@Injectable({providedIn: 'root'})
export class ConfirmService {

  constructor(public dialog: MatDialog) {
  }

  confirm(options: Partial<ConfirmOptions>, matDialogConfig?: MatDialogConfig) {
    return this.dialog.open(ConfirmComponent, {
      minWidth: '448px',
      maxWidth: '600px',
      panelClass: 'confirm-dialog',
      data: {
        confirmText: 'Proceed',
        cancelText: 'Cancel',
        ...options
      },
      ...matDialogConfig
    }).afterClosed().pipe(take(1), filter(Boolean));
  }

  confirmWithResult(options: Partial<ConfirmOptions>, matDialogConfig?: MatDialogConfig): Observable<boolean> {
    return this.dialog.open(ConfirmComponent, {
      minWidth: '448px',
      maxWidth: '600px',
      panelClass: 'confirm-dialog',
      data: {
        confirmText: 'Proceed',
        cancelText: 'Cancel',
        ...options
      },
      ...matDialogConfig
    }).afterClosed().pipe(take(1), map(res => !!res));
  }

  alert(options: AlertOptions, title = 'Something went wrong' , matDialogConfig?: MatDialogConfig) {
    return this.dialog.open(ConfirmComponent, {
      minWidth: '448px',
      width: '448px',
      maxWidth: '600px',
      panelClass: 'confirm-dialog',
      data: {
        cancelText: '',
        confirmText: 'Proceed',
        title,
        ...options
      },
      ...matDialogConfig
    });
  }
}
