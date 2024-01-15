import { Component, Inject, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ManagersIdParams } from 'src/app/models/common/managers-id-params';
import { Manager } from 'src/app/models/data/manager';
import { NotifyService } from 'src/app/services/common/notify.service';
import { ManagerService } from 'src/app/services/data/manager.service';

@Component({
  selector: 'app-manager-dialog',
  templateUrl: './manager-dialog.component.html',
  styleUrls: ['./manager-dialog.component.scss']
})
export class ManagerDialogComponent {
  
  manager:Manager[] =[];

  dataSource: MatTableDataSource<Manager> = new MatTableDataSource(this.manager);
  columns: string[] = ['expand', 'picture', 'managerName', 'joinDate', 'email', 'phone', 'address', 'actions']
  @ViewChild(MatSort, {static:false}) sort!:MatSort;
  
  constructor(
    private managerService:ManagerService,
    private notifyService:NotifyService,
    @Inject(MAT_DIALOG_DATA) public data: ManagersIdParams
  ){}

  ngOnInit(): void {
 }
}
