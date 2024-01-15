import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ConfirmDeleteComponent } from 'src/app/dialogs/confirm-delete/confirm-delete.component';
import { Manager } from 'src/app/models/data/manager';
import { NotifyService } from 'src/app/services/common/notify.service';
import { EventService } from 'src/app/services/data/event.service';
import { ManagerService } from 'src/app/services/data/manager.service';
import { Event } from 'src/app/models/data/event';

@Component({
  selector: 'app-manager-event',
  templateUrl: './manager-event.component.html',
  styleUrls: ['./manager-event.component.scss']
})
export class ManagerEventComponent implements OnInit {

  @Input() events: Event[] = [];

  managers: Manager[] = [];

  dataSource: MatTableDataSource<Event> = new MatTableDataSource(this.events);
  columns: string[] = ['eventName', 'startDate', 'endDate', 'location','selectionPanel','actions'];

  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;
  @Output() detailDeleted: EventEmitter<{ managerId: number, detailId: number }> = new EventEmitter<{ managerId: number, detailId: number }>();

  constructor(
    private eventsService: EventService,
    private notifyService: NotifyService,
    private matDialog: MatDialog,
  ) { }

  @Input() managerName = '';
 
  @Input() set event(value: Event[]) {
    this.events = value;
    console.log(value)
    this.dataSource.data = this.events;
  }

  @Output() childOutputProperty:EventEmitter<number> = new EventEmitter();

  get event(): Event[] {
    return this.events;
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
    // Initialization logic here
  }
}
