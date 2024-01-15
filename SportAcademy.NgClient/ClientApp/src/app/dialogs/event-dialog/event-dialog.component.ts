import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { EventsIdParams } from 'src/app/models/common/events-id-params';
import { NotifyService } from 'src/app/services/common/notify.service';
import { EventService } from 'src/app/services/data/event.service';

@Component({
  selector: 'app-event-dialog',
  templateUrl: './event-dialog.component.html',
  styleUrls: ['./event-dialog.component.scss']
})
export class EventDialogComponent implements OnInit{

  events:Event[] =[];

  eventsDataSource:MatTableDataSource<Event> = new MatTableDataSource(this.events);
  eventsColumns: string[] = ['eventName','startDate','endDate','description','locations','actions'];  
  @ViewChild(MatSort, {static:false}) sort!:MatSort;
  
  constructor(
    private eventService:EventService,
    private notifyService:NotifyService,
    @Inject(MAT_DIALOG_DATA) public data: EventsIdParams
  ){}

  ngOnInit(): void {
 }
}
