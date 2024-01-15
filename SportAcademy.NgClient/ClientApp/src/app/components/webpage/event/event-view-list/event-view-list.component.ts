import { Component, OnInit } from '@angular/core';
import { NotifyService } from 'src/app/services/common/notify.service';
import { EventService } from 'src/app/services/data/event.service';
import { Event } from 'src/app/models/data/event';
import { apiBaseUrl } from 'src/app/shared/app-constants';

@Component({
  selector: 'app-event-view-list',
  templateUrl: './event-view-list.component.html',
  styleUrls: ['./event-view-list.component.scss']
})
export class EventViewListComponent implements OnInit {

  events: Event[] = [];

  constructor(
    private eventService: EventService,
    private notifyService: NotifyService
  ) { }
  
  imagePath: string = apiBaseUrl + '/Pictures';

  ngOnInit(): void {
    this.getEvents();
  }

  getEvents(): void {
    this.eventService.getEvents().subscribe(
      (events: Event[]) => {
        this.events = events;
      },
      (error) => {
        console.error('Error fetching events:', error);
        // Handle error, e.g., display a notification
        this.notifyService.message("Failed to load Events data!");
      }
    );
  }
}
