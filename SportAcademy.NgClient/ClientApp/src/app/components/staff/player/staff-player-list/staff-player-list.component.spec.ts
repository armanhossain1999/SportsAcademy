import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StaffPlayerListComponent } from './staff-player-list.component';

describe('StaffPlayerListComponent', () => {
  let component: StaffPlayerListComponent;
  let fixture: ComponentFixture<StaffPlayerListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StaffPlayerListComponent]
    });
    fixture = TestBed.createComponent(StaffPlayerListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
