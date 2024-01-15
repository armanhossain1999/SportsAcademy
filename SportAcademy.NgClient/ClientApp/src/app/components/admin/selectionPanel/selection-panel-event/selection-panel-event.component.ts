import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ConfirmDeleteComponent } from 'src/app/dialogs/confirm-delete/confirm-delete.component';
import { SelectionPanel } from 'src/app/models/data/selectionPanel';
import { NotifyService } from 'src/app/services/common/notify.service';
import { EventService } from 'src/app/services/data/event.service';
import { Event } from 'src/app/models/data/event';
import { Manager } from 'src/app/models/data/manager';
import { ManagerService } from 'src/app/services/data/manager.service';

@Component({
  selector: 'app-selection-panel-event',
  templateUrl: './selection-panel-event.component.html',
  styleUrls: ['./selection-panel-event.component.scss']
})
export class SelectionPanelEventComponent implements OnInit {

  @Input() events: Event[] = [];
  managers : Manager [] = []

  selectionPanel: SelectionPanel[] = [];

  dataSource: MatTableDataSource<Event> = new MatTableDataSource(this.events);
  managerDataSource: MatTableDataSource<Manager> = new MatTableDataSource(this.managers);

  columns: string[] = ['eventName','managerName', 'startDate', 'endDate', 'location','actions'];

  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;
  @Output() detailDeleted: EventEmitter<{ managerId: number, detailId: number }> = new EventEmitter<{ managerId: number, detailId: number }>();

  constructor(
    private eventsService: EventService,
    private managerService : ManagerService,
    private notifyService: NotifyService,
    private matDialog: MatDialog,
  ) { }

  @Input() selectionPanelName = '';
 
  @Input() set event(value: Event[]) {
    this.events = value;
    console.log(value)
    this.dataSource.data = this.events;
  }

  @Output() childOutputProperty:EventEmitter<number> = new EventEmitter();

  get event(): Event[] {
    return this.events;
  }

  getManagerName(managerId: number | undefined): string {
    if (managerId !== undefined) {
      const manager = this.managers.find(m => m.managerId === managerId);
      return manager?.managerName || 'N/A';
    }
    return 'N/A';
  }

  confirmDelete(event: Event) {
    this.matDialog.open(ConfirmDeleteComponent, {
      width: '450px'
    }).afterClosed()
      .subscribe(confirm => {
        if (confirm) {
          this.eventsService.delete(<number>event.eventId)
            .subscribe({
              next: r => {
                this.dataSource.data = this.dataSource.data.filter(x => x.eventId != event.eventId);
                this.notifyService.message('Event deleted successfully.');
                this.childOutputProperty.emit(<number>this.event.length)
              },
              error: err => {
                this.notifyService.message('Failed to delete event.');
                console.log(err.message || err);
              }
            });
        }
      });
  }

  ngOnInit(): void {
    this.managerService.getManagers().subscribe({
        next: r => {
          this.managers = r;
          this.managerDataSource.data = this.managers;
          this.managerDataSource.sort = this.sort;
          this.managerDataSource.paginator = this.paginator;               
        },
        error: err => {
          console.log(err.message || err);
          this.notifyService.message("Failed to load Manager data!");
        }
      });
  }
}

