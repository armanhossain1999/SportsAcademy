import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StaffEventListComponent } from './staff-event-list.component';

describe('StaffEventListComponent', () => {
  let component: StaffEventListComponent;
  let fixture: ComponentFixture<StaffEventListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StaffEventListComponent]
    });
    fixture = TestBed.createComponent(StaffEventListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
