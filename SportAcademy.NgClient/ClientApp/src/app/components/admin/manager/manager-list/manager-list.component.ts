import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ConfirmDeleteComponent } from 'src/app/dialogs/confirm-delete/confirm-delete.component';
import { Manager } from 'src/app/models/data/manager';
import { NotifyService } from 'src/app/services/common/notify.service';
import { ManagerService } from 'src/app/services/data/manager.service';
import { apiBaseUrl } from 'src/app/shared/app-constants';


@Component({
  selector: 'app-manager-list',
  templateUrl: './manager-list.component.html',
  styleUrls: ['./manager-list.component.scss']
})
export class ManagerListComponent implements OnInit {

  managers: Manager[] = [];
  events: Event[] = [];
  searchTerm: string = '';

  dataSource: MatTableDataSource<Manager> = new MatTableDataSource(this.managers);
  columns: string[] = ['expand', 'picture', 'managerName', 'joinDate', 'email', 'phone', 'address', 'actions'];
  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;

  imagePath: string = apiBaseUrl + '/Pictures';
  expandedElement: Manager | null = null;

  eventCount : number = 0;
  
  receivesDataFromChild(eventCount : number){
    this.managerService.getManagersWithEvents()
    .subscribe({
      next : r => {
        this.managers = r;
        console.log(this.managers);
        this.dataSource.data = this.managers;
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      }, 
      error: err => {
        this.notifyService.message("Failed to delete");
        console.log(err.message || err);
      }
    });
  }

  constructor(
    private managerService: ManagerService,
    private notifyService: NotifyService,
    private matDialog: MatDialog
  ) { }

  
  ngOnInit(): void {
    
    this.managerService.getManagersWithEvents()
      .subscribe({
        next: managers => {
          this.managers = managers;
          console.log(this.managers);
          this.dataSource.data = this.managers;
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;

            // Define filter predicate here
            this.dataSource.filterPredicate = (data, filter) => {
            const searchTermLowerCase = filter.toLowerCase();

            // Use nullish coalescing operator to handle possible undefined values
            return (
              (data.managerName ?? '').toLowerCase().includes(searchTermLowerCase) ||
              (data.email ?? '').toLowerCase().includes(searchTermLowerCase) || 
              (data.address ?? '').toLowerCase().includes(searchTermLowerCase)

            );
          };
        },
        error: err => {
          console.log(err.message || err);
          this.notifyService.message("Failed to load Managers data!");
        }
      });
  }

  applyFilter() {
    this.dataSource.filter = this.searchTerm.trim().toLowerCase();
  }


  confirmDelete(manager: Manager) {
    this.matDialog.open(ConfirmDeleteComponent, {
      "width": "450px"
    }).afterClosed()
      .subscribe(confirm => {
        if (confirm) {
          this.managerService.delete(<number>manager.managerId)
            .subscribe({
              next: r => {
                this.dataSource.data = this.dataSource.data.filter(x => x.managerId != manager.managerId);
              },
              error: err => {
                this.notifyService.message("Failed to delete");
                console.log(err.message || err);
              }
            });
        }
      });
  }

  handleDetailDeleted(event: { managerId: number; detailId: number }): void {
    // Perform any actions here based on the deleted detail
    console.log(`Detail deleted for Manager ID: ${event.managerId}, Detail ID: ${event.detailId}`);
  }
}