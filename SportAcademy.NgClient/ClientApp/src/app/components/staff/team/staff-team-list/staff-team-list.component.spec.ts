import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StaffTeamListComponent } from './staff-team-list.component';

describe('StaffTeamListComponent', () => {
  let component: StaffTeamListComponent;
  let fixture: ComponentFixture<StaffTeamListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StaffTeamListComponent]
    });
    fixture = TestBed.createComponent(StaffTeamListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
