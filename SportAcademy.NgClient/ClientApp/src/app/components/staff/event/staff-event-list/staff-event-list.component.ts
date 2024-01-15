import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ConfirmDeleteComponent } from 'src/app/dialogs/confirm-delete/confirm-delete.component';
import { Manager } from 'src/app/models/data/manager';
import { Event } from 'src/app/models/data/event';
import { SelectionPanel } from 'src/app/models/data/selectionPanel';
import { NotifyService } from 'src/app/services/common/notify.service';
import { EventService } from 'src/app/services/data/event.service';
import { ManagerService } from 'src/app/services/data/manager.service';
import { SelectionPanelService } from 'src/app/services/data/selectionPanel.service';
import { apiBaseUrl } from 'src/app/shared/app-constants';

@Component({
  selector: 'app-staff-event-list',
  templateUrl: './staff-event-list.component.html',
  styleUrls: ['./staff-event-list.component.scss']
})
export class StaffEventListComponent implements OnInit {
  @Input() totalEvents: number = 0; // Receive the numberOfTeams as input

  events : Event[] = [];
  managers : Manager[] = [];
  selectionPanels : SelectionPanel [] = [] ;
  searchTerm: string = '';

  dataSource: MatTableDataSource<Event> = new MatTableDataSource(this.events);
  managerDataSource: MatTableDataSource<Manager> = new MatTableDataSource(this.managers);
  selectionPanelDataSource: MatTableDataSource<SelectionPanel> = new MatTableDataSource(this.selectionPanels);

  columns: string[] = ['picture', 'eventName','managerName','selectionPanelName', 'startDate', 'endDate', 'location', 'actions'];
  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;

  imagePath: string = apiBaseUrl + '/Pictures';
  expandedElement: Event | null = null;

  constructor(
    private eventService: EventService,
    private managerService : ManagerService,
    private selectionPanelService : SelectionPanelService,
    private notifyService: NotifyService,
    private matDialog: MatDialog
  ) { }

  getManagerName(managerId: number | undefined): string {
    if (managerId !== undefined) {
      const manager = this.managers.find(m => m.managerId === managerId);
      return manager?.managerName || 'N/A';
    }
    return 'N/A';
  }
  getSelectionPanelName(selectionPanelId: number | undefined): string {
    if (selectionPanelId !== undefined) {
      const selectionPanel = this.selectionPanels.find(m => m.selectionPanelId === selectionPanelId);
      return selectionPanel?.selectionPanelName || 'N/A';
    }
    return 'N/A';
  }

  confirmDelete(event: Event) {
    this.matDialog.open(ConfirmDeleteComponent, {
      "width": "450px"
    }).afterClosed()
      .subscribe(confirm => {
        if (confirm) {
          this.eventService.delete(<number>event.eventId)
            .subscribe({
              next: r => {
                this.dataSource.data = this.dataSource.data.filter(x => x.eventId != event.eventId);
              },
              error: err => {
                this.notifyService.message("Failed to delete");
                console.log(err.message || err);
              }
            });
        }
      });
  }

  ngOnInit() {
    this.eventService.getEvents()
      .subscribe({
        next: events => {
          this.events = events;
          console.log(this.events);
          this.dataSource.data = this.events;
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;

          this.dataSource.filterPredicate = (data, filter) => {
            const searchTermLowerCase = filter.toLowerCase();

            // Use nullish coalescing operator to handle possible undefined values
            return (
              (data.eventName ?? '').toLowerCase().includes(searchTermLowerCase) ||
              (data.location ?? '').toLowerCase().includes(searchTermLowerCase)
            );
          };
        },
        error: err => {
          console.log(err.message || err);
          this.notifyService.message("Failed to load Events data!");
        }
      });
      this.managerService.getManagers().subscribe({
        next: r => {
          this.managers = r;
          this.managerDataSource.data = this.managers;
          this.managerDataSource.sort = this.sort;
          

          this.dataSource.filterPredicate = (data, filter) => {
            const searchTermLowerCase = filter.toLowerCase();

            // Use nullish coalescing operator to handle possible undefined values
            return (
              (data.managerName ?? '').toLowerCase().includes(searchTermLowerCase) ||
              (data.location ?? '').toLowerCase().includes(searchTermLowerCase)
                    
            );
          };
          
        },
        error: err => {
          console.log(err.message || err);
          this.notifyService.message("Failed to load Category data!");
        }
      });
      this.selectionPanelService.getSelectionPanels().subscribe({
        next: r => {
          this.selectionPanels = r;
          this.selectionPanelDataSource.data = this.selectionPanels;
          this.selectionPanelDataSource.sort = this.sort;
        },
        error: err => {
          console.log(err.message || err);
          this.notifyService.message("Failed to load SelectionPanel data!");
        }
      });
  }
  applyFilter() {
    this.dataSource.filter = this.searchTerm.trim().toLowerCase();
  }
}