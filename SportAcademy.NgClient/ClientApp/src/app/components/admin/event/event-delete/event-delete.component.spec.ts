import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventDeleteComponent } from './event-delete.component';

describe('EventDeleteComponent', () => {
  let component: EventDeleteComponent;
  let fixture: ComponentFixture<EventDeleteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EventDeleteComponent]
    });
    fixture = TestBed.createComponent(EventDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
