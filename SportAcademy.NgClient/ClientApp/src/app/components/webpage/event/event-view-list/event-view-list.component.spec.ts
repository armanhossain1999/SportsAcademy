import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventViewListComponent } from './event-view-list.component';

describe('EventViewListComponent', () => {
  let component: EventViewListComponent;
  let fixture: ComponentFixture<EventViewListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EventViewListComponent]
    });
    fixture = TestBed.createComponent(EventViewListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
