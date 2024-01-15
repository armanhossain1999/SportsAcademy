import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class NotifyService {
  constructor(
    private snackBar: MatSnackBar
  ) { }
  message(message:string, action:string = 'DISMISS'){
    let config: MatSnackBarConfig = {
      duration: 3000,
      panelClass: []
     // horizontalPosition: 'right',
     // verticalPosition: 'top'
    };
    this.snackBar.open(message, action,config);
  }
}

